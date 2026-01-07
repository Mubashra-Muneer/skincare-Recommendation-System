using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace SkinMetaConsole
{
    public partial class routine : Form
    {
        private SqlConnection con = DatabaseHelper.GetConnection();
        private DateTime selectedDate;
        private DateTime cycleStartDate;
        private int cycleLength = 28; // Default cycle length
        private int currentUserId;
        private Dictionary<string, List<ProductInfo>> morningProducts;
        private Dictionary<string, List<ProductInfo>> nightProducts;
        private List<string> cleansers = new List<string>();
        private List<string> toners = new List<string>();
        private List<string> serums = new List<string>();
        private List<string> moisturizers = new List<string>();
        private List<string> sunscreens = new List<string>();
        public routine(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            morningProducts = new Dictionary<string, List<ProductInfo>>();
            nightProducts = new Dictionary<string, List<ProductInfo>>();

            // Initialize product category dictionaries
            morningProducts["cleansers"] = new List<ProductInfo>();
            morningProducts["toners"] = new List<ProductInfo>();
            morningProducts["serums"] = new List<ProductInfo>();
            morningProducts["moisturizers"] = new List<ProductInfo>();
            morningProducts["sunscreens"] = new List<ProductInfo>();

            nightProducts["cleansers"] = new List<ProductInfo>();
            nightProducts["toners"] = new List<ProductInfo>();
            nightProducts["serums"] = new List<ProductInfo>();
            nightProducts["moisturizers"] = new List<ProductInfo>();
            nightProducts["sunscreens"] = new List<ProductInfo>();

            LoadUserProducts();
            SetupRoutineSteps();

            // Create back button
            CreateBackButton();
        }

        private void CreateBackButton()
        {
            // Create back button
            Button backButton = new Button
            {
                Text = "Back",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(80, 30),
                Location = new Point(10, 10), // Position at top left
                BackColor = Color.FromArgb(255, 182, 193), // Light pink
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            // Make the button corners rounded
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 10, 10, 180, 90);
            path.AddArc(backButton.Width - 10, 0, 10, 10, 270, 90);
            path.AddArc(backButton.Width - 10, backButton.Height - 10, 10, 10, 0, 90);
            path.AddArc(0, backButton.Height - 10, 10, 10, 90, 90);
            path.CloseAllFigures();
            backButton.Region = new Region(path);

            // Add click event handler
            backButton.Click += (sender, e) =>
            {
                UserProfile profile = new UserProfile(currentUserId);
                profile.Show();
                this.Hide();
            };

            // Add button to form
            this.Controls.Add(backButton);

            // Bring button to front to ensure visibility
            backButton.BringToFront();
        }

        private void LoadUserProducts()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                string query = @"
                        SELECT p.ProductID, p.Name, p.Brand, p.SkinType, p.Ingredients, p.Description, pc.prodCategoryName
                        FROM UserProducts up
                        JOIN Products p ON up.ProductID = p.ProductID
                        JOIN prodCategories pc ON p.prodCategoryID = pc.prod_CategoryID
                        WHERE up.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@UserID", currentUserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductInfo product = new ProductInfo
                            {
                                ProductId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Brand = reader.GetString(2),
                                SkinType = reader.GetString(3),
                                Ingredients = reader.GetString(4),
                                Description = reader.GetString(5),
                                Category = reader.GetString(6)
                            };

                            // Categorize product by type and time of day
                            CategorizeProduct(product);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategorizeProduct(ProductInfo product)
        {
            // Convert category name to lowercase for consistency
            string category = product.Category.ToLower();

            switch (category)
            {
                case "cleanser":
                    // Most cleansers can be used both morning and night
                    morningProducts["cleansers"].Add(product);
                    nightProducts["cleansers"].Add(product);
                    cleansers.Add($"{product.Brand} {product.Name}");
                    break;

                case "toner":
                    // Most toners can be used both morning and night
                    morningProducts["toners"].Add(product);
                    nightProducts["toners"].Add(product);
                    toners.Add($"{product.Brand} {product.Name}");
                    break;

                case "serum":
                    // Categorize serums based on ingredients or description
                    if (ContainsKeywords(product, new[] { "vitamin c", "brightening", "antioxidant", "glow", "radiance" }))
                    {
                        morningProducts["serums"].Add(product);
                        serums.Add($"{product.Brand} {product.Name} (Morning)");
                    }
                    else if (ContainsKeywords(product, new[] { "retinol", "anti-aging", "repair", "night", "regenerating" }))
                    {
                        nightProducts["serums"].Add(product);
                        serums.Add($"{product.Brand} {product.Name} (Night)");
                    }
                    else
                    {
                        // If no specific keywords, add to both routines
                        morningProducts["serums"].Add(product);
                        nightProducts["serums"].Add(product);
                        serums.Add($"{product.Brand} {product.Name}");
                    }
                    break;

                case "moisturizer":
                    // Most moisturizers can be used both morning and night
                    // But heavier ones are better for night
                    if (ContainsKeywords(product, new[] { "night", "rich", "heavy", "deep" }))
                    {
                        nightProducts["moisturizers"].Add(product);
                        moisturizers.Add($"{product.Brand} {product.Name} (Night)");
                    }
                    else if (ContainsKeywords(product, new[] { "day", "light", "gel", "oil-free" }))
                    {
                        morningProducts["moisturizers"].Add(product);
                        moisturizers.Add($"{product.Brand} {product.Name} (Day)");
                    }
                    else
                    {
                        morningProducts["moisturizers"].Add(product);
                        nightProducts["moisturizers"].Add(product);
                        moisturizers.Add($"{product.Brand} {product.Name}");
                    }
                    break;

                case "sunscreen":
                    // Sunscreens are used in the morning/daytime only
                    morningProducts["sunscreens"].Add(product);
                    sunscreens.Add($"{product.Brand} {product.Name}");
                    break;
            }
        }

        private bool ContainsKeywords(ProductInfo product, string[] keywords)
        {
            string textToSearch = (product.Name + " " + product.Description + " " + product.Ingredients).ToLower();

            foreach (string keyword in keywords)
            {
                if (textToSearch.Contains(keyword.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        private void SetupRoutineSteps()
        {
            // Create panel containers with scrolling capability
            Panel morningContainer = CreateScrollablePanel(guna2Panel1);
            Panel nightContainer = CreateScrollablePanel(guna2Panel2);

            // Add Morning Routine Label
            Label morningLabel = new Label
            {
                Text = "MORNING ROUTINE",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(morningContainer.Width - 20, 30),
                ForeColor = Color.DeepPink,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(255, 240, 245) // Very light pink background
            };
            morningContainer.Controls.Add(morningLabel);

            // Create step panels for morning routine with offset for the header and increased spacing
            int yOffsetMorning = 50;
            int stepSpacing = 75; // Increased spacing between steps

            CreateStepPanel(morningContainer, "STEP 1: Cleanser",
                morningProducts["cleansers"].Count > 0 ?
                GetFirstProduct(morningProducts["cleansers"]) :
                "", yOffsetMorning);

            CreateStepPanel(morningContainer, "STEP 2: Toner",
                morningProducts["toners"].Count > 0 ?
                GetFirstProduct(morningProducts["toners"]) :
                "", yOffsetMorning + stepSpacing);

            CreateStepPanel(morningContainer, "STEP 3: Serum",
                morningProducts["serums"].Count > 0 ?
                GetFirstProduct(morningProducts["serums"]) :
                "", yOffsetMorning + (stepSpacing * 2));

            CreateStepPanel(morningContainer, "STEP 4: Moisturizer",
                morningProducts["moisturizers"].Count > 0 ?
                GetFirstProduct(morningProducts["moisturizers"]) :
                "", yOffsetMorning + (stepSpacing * 3));

            CreateStepPanel(morningContainer, "STEP 5: Sunscreen",
                morningProducts["sunscreens"].Count > 0 ?
                GetFirstProduct(morningProducts["sunscreens"]) :
                "", yOffsetMorning + (stepSpacing * 4));

            // Add Night Routine Label
            Label nightLabel = new Label
            {
                Text = "NIGHT ROUTINE",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(nightContainer.Width - 20, 30),
                ForeColor = Color.MidnightBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(240, 240, 255) // Very light blue background
            };
            nightContainer.Controls.Add(nightLabel);

            // Create step panels for night routine with offset for the header and increased spacing
            int yOffsetNight = 50;

            CreateStepPanel(nightContainer, "STEP 1: Cleanser",
                nightProducts["cleansers"].Count > 0 ?
                GetFirstProduct(nightProducts["cleansers"]) :
                "", yOffsetNight);

            CreateStepPanel(nightContainer, "STEP 2: Toner",
                nightProducts["toners"].Count > 0 ?
                GetFirstProduct(nightProducts["toners"]) :
                "", yOffsetNight + stepSpacing);

            CreateStepPanel(nightContainer, "STEP 3: Serum",
                nightProducts["serums"].Count > 0 ?
                GetFirstProduct(nightProducts["serums"]) :
                "", yOffsetNight + (stepSpacing * 2));

            CreateStepPanel(nightContainer, "STEP 4: Moisturizer",
                nightProducts["moisturizers"].Count > 0 ?
                GetFirstProduct(nightProducts["moisturizers"]) :
                "", yOffsetNight + (stepSpacing * 3));

            CreateStepPanel(nightContainer, "STEP 5: Occlusive",
                "", yOffsetNight + (stepSpacing * 4)); // Empty for night - no sunscreen needed
        }

        private string GetFirstProduct(List<ProductInfo> products)
        {
            if (products.Count > 0)
            {
                // Format the product name in a more readable way
                return $"{products[0].Brand} {products[0].Name}";
            }
            return "";
        }

        private Panel CreateScrollablePanel(Panel parentPanel)
        {
            // Clear the parent panel first
            parentPanel.Controls.Clear();

            // Create a panel that will be contained in a scrollable area
            Panel contentPanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                BackColor = parentPanel.BackColor
            };

            parentPanel.Controls.Add(contentPanel);
            return contentPanel;
        }

        private void CreateStepPanel(Panel parentPanel, string stepText, string productName, int yPos)
        {
            // Create wider, taller rounded step panel with proper styling to accommodate product names
            Panel stepPanel = new Panel
            {
                Width = 380,  // Wider to accommodate product name
                Height = 60,  // Taller to fit product name better
                Location = new Point(10, yPos),
                BackColor = Color.FromArgb(255, 182, 193) // Light pink
            };

            // Make the panel corners rounded
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(stepPanel.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(stepPanel.Width - 20, stepPanel.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, stepPanel.Height - 20, 20, 20, 90, 90);
            path.CloseAllFigures();
            stepPanel.Region = new Region(path);

            // Add checkbox on the left side
            CheckBox checkBox = new CheckBox
            {
                Location = new Point(15, 22),  // Centered vertically
                Size = new Size(15, 15),
                BackColor = Color.Transparent
            };

            // Add step text
            Label lblStep = new Label
            {
                Text = stepText,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Location = new Point(40, 12),  // Moved up to make room for product
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Add product name if available
            if (!string.IsNullOrEmpty(productName))
            {
                // Create a label with proper text wrapping for product name
                Label lblProduct = new Label
                {
                    Text = productName,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    Location = new Point(40, 32),  // Position below step text
                    Size = new Size(320, 20),      // Fixed width with enough height
                    BackColor = Color.Transparent,
                    AutoEllipsis = true,          // Shows "..." if text is too long
                    UseMnemonic = false           // Prevents "&" from being interpreted as shortcut
                };
                stepPanel.Controls.Add(lblProduct);

                // Change cursor to indicate there's more info
                stepPanel.Cursor = Cursors.Hand;

                // Add tooltip to show full product name when hovered
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(lblProduct, productName);
            }
            else
            {
                // Visual indication that there are no products for this step
                lblStep.ForeColor = Color.Gray;
                checkBox.Enabled = false;

                // For night routine step 5 (sunscreen), explain why it's not needed
                if (stepText.Contains("STEP 5") && parentPanel.Controls.Contains(guna2Panel2))
                {
                    Label noProductLabel = new Label
                    {
                        Text = "Not needed at night",
                        Font = new Font("Arial", 10, FontStyle.Italic),
                        Location = new Point(40, 32),  // Position below step text
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        BackColor = Color.Transparent
                    };
                    stepPanel.Controls.Add(noProductLabel);
                }
            }

            stepPanel.Controls.Add(checkBox);
            stepPanel.Controls.Add(lblStep);
            parentPanel.Controls.Add(stepPanel);
        }

        // Product info class to store product details
        private class ProductInfo
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            public string SkinType { get; set; }
            public string Ingredients { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }

        private void SaveUserCycleSettings()
        {
            // Save the cycle start date to your database or settings
            // This is where you would implement persistence of user settings
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Event handler for checkbox
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Additional event handler for calendar
        }
    }
}