using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkinMetaConsole
{
    public partial class productCatalog : Form
    {
        private SqlConnection con = DatabaseHelper.GetConnection();
        private int currentUserId;
        private Panel ProductPanel;
        private Panel AlertPanel; // New panel for ingredient alerts
        private Dictionary<int, ImageCheckBox> productCheckboxes = new Dictionary<int, ImageCheckBox>();
        private Dictionary<string, string> ingredientSideEffects = new Dictionary<string, string>(); // Cache for ingredient side effects

        public productCatalog(int id)
        {
            InitializeComponent();
            SetupProductPanel();
            SetupAlertPanel(); // Set up the new alert panel
            LoadProductImages();
            LoadIngredientSideEffects(); // Load ingredient side effects into cache
            currentUserId = id;
        }

        // Load all ingredient side effects into memory for quick lookup
        private void LoadIngredientSideEffects()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT Name, SideEffects FROM Ingredients";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string sideEffects = reader.GetString(1);
                            ingredientSideEffects[name] = sideEffects;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ingredient side effects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Set up the alert panel similar to the product panel
        private void SetupAlertPanel()
        {
            // Create and set up sliding alert panel
            AlertPanel = new Panel
            {
                Width = 300,
                Height = this.Height,
                BackColor = Color.FromArgb(255, 255, 240), // Light yellow for alerts
                Location = new Point(this.Width, 0),
                Visible = false,
                Dock = DockStyle.None
            };

            // Add a label title for the panel
            Label titleLabel = new Label
            {
                Text = "Ingredient Alerts",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = AlertPanel.Width,
                Height = 40,
                Location = new Point(0, 10)
            };

            // Add a back button at the bottom of the panel
            Button backButton = new Button
            {
                Text = "Close",
                Width = 80,
                Height = 30,
                BackColor = Color.LightCoral,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point((AlertPanel.Width - 80) / 2, AlertPanel.Height - 45)
            };
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += (s, e) => SlideAlertPanel(false);

            // Add panel for alerts with clearly defined properties
            Panel scrollPanel = new Panel
            {
                AutoScroll = true,
                Width = AlertPanel.Width - 10,
                Height = AlertPanel.Height - 120, // Make room for the back button
                Location = new Point(5, 50),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            AlertPanel.Controls.Add(titleLabel);
            AlertPanel.Controls.Add(scrollPanel);
            AlertPanel.Controls.Add(backButton);

            // Add to form and make sure it's at the front of the z-order
            this.Controls.Add(AlertPanel);
            AlertPanel.BringToFront();
        }

        private void SetupProductPanel()
        {
            // Create and set up sliding product panel
            ProductPanel = new Panel
            {
                Width = 300,
                Height = this.Height,
                BackColor = Color.FromArgb(255, 240, 240),
                Location = new Point(this.Width, 0),
                Visible = false,
                Dock = DockStyle.None
            };

            // Add a label title for the panel
            Label titleLabel = new Label
            {
                Text = "Your Selected Products",
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Width = ProductPanel.Width,
                Height = 40,
                Location = new Point(0, 10)
            };

            // Add a smaller back button at the bottom of the panel
            Button backButton = new Button
            {
                Text = "Back",
                Width = 120,  // Same width as "Check"
                Height = 35,
                BackColor = Color.LightCoral,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(160, ProductPanel.Height - 50)  // Right side (30 + 120 + 10 spacing)
            };
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Click += (s, e) => SlidePanel(false);

            // Add panel for products with clearly defined properties
            Panel scrollPanel = new Panel
            {
                AutoScroll = true,
                Width = ProductPanel.Width - 10,
                Height = ProductPanel.Height - 110,  // Reduced to fit buttons
                Location = new Point(5, 50),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Add a button to check ingredient alerts
            Button checkIngredientsButton = new Button
            {
                Text = "Check",
                Width = 120,  // Slightly narrower to fit side by side
                Height = 35,
                BackColor = Color.LightCoral,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(30, ProductPanel.Height - 50)  // Left side
            };
            checkIngredientsButton.FlatAppearance.BorderSize = 0;
            checkIngredientsButton.Click += CheckIngredientAlerts;

            ProductPanel.Controls.Add(titleLabel);
            ProductPanel.Controls.Add(scrollPanel);
            ProductPanel.Controls.Add(backButton);
            ProductPanel.Controls.Add(checkIngredientsButton); // Add the new button

            // Add to form and make sure it's at the front of the z-order
            this.Controls.Add(ProductPanel);
            ProductPanel.BringToFront();
        }

        // Event handler for the Check Ingredients button
        private void CheckIngredientAlerts(object sender, EventArgs e)
        {
            // Get the currently selected products from the ProductPanel
            List<int> selectedProductIds = new List<int>();

            // Find the scroll panel in the ProductPanel
            Panel scrollPanel = null;
            foreach (Control control in ProductPanel.Controls)
            {
                if (control is Panel && control.Location.Y == 50)
                {
                    scrollPanel = (Panel)control;
                    break;
                }
            }

            if (scrollPanel != null)
            {
                // Each product card should have the ProductId stored in its Tag property
                foreach (Control control in scrollPanel.Controls)
                {
                    if (control is Panel productCard && productCard.Tag != null)
                    {
                        if (int.TryParse(productCard.Tag.ToString(), out int productId))
                        {
                            selectedProductIds.Add(productId);
                        }
                    }
                }
            }

            if (selectedProductIds.Count == 0)
            {
                MessageBox.Show("No products selected to check.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowIngredientAlerts(selectedProductIds);
        }

        // Show ingredient alerts for selected products
        private void ShowIngredientAlerts(List<int> productIds)
        {
            // Find the scroll panel in the AlertPanel
            Panel alertScrollPanel = null;
            foreach (Control control in AlertPanel.Controls)
            {
                if (control is Panel && control.Location.Y == 50)
                {
                    alertScrollPanel = (Panel)control;
                    break;
                }
            }

            if (alertScrollPanel == null)
            {
                MessageBox.Show("Alert scroll panel not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear existing alerts
            alertScrollPanel.Controls.Clear();

            try
            {
                Dictionary<string, List<string>> productIngredients = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> ingredientProducts = new Dictionary<string, List<string>>();

                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                        SELECT p.ProductID, p.Name AS ProductName, i.Name AS IngredientName, i.SideEffects
                        FROM Products p
                        CROSS JOIN Ingredients i
                        WHERE p.ProductID IN (" + string.Join(",", productIds) + @")
                        AND p.Ingredients LIKE '%' + i.Name + '%'";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int yPosition = 10;
                        bool hasAlerts = false;

                        while (reader.Read())
                        {
                            hasAlerts = true;
                            int productId = reader.GetInt32(0);
                            string productName = reader.GetString(1);
                            string ingredientName = reader.GetString(2);
                            string sideEffects = reader.GetString(3);

                            // Skip ingredients with "None" side effects
                            if (sideEffects.Equals("None", StringComparison.OrdinalIgnoreCase))
                                continue;

                            // Create an alert panel for this ingredient
                            Panel alertCard = CreateAlertCard(productName, ingredientName, sideEffects);
                            alertCard.Location = new Point(10, yPosition);
                            alertScrollPanel.Controls.Add(alertCard);
                            yPosition += alertCard.Height + 10;
                        }

                        // If no alerts were found
                        if (!hasAlerts)
                        {
                            Label noAlerts = new Label
                            {
                                Text = "No ingredient concerns detected for your products.",
                                AutoSize = true,
                                Location = new Point(10, 10),
                                Font = new Font("Arial", 10)
                            };
                            alertScrollPanel.Controls.Add(noAlerts);
                        }
                    }
                }

                // Show the alert panel
                SlideAlertPanel(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking ingredients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create an alert card for displaying ingredient side effects
        private Panel CreateAlertCard(string productName, string ingredientName, string sideEffects)
        {
            Panel panel = new Panel
            {
                Width = 260,
                Height = 120,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Warning icon
            PictureBox warningIcon = new PictureBox
            {
                Width = 32,
                Height = 32,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10)
            };

            // Set warning icon with a simple drawn triangle
            Bitmap warningBitmap = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(warningBitmap))
            {
                g.Clear(Color.Transparent);
                g.FillPolygon(Brushes.Gold, new Point[] {
                    new Point(16, 2), // Top
                    new Point(2, 30),  // Bottom left
                    new Point(30, 30)  // Bottom right
                });
                g.DrawPolygon(Pens.DarkGoldenrod, new Point[] {
                    new Point(16, 2), // Top
                    new Point(2, 30),  // Bottom left
                    new Point(30, 30)  // Bottom right
                });
                g.FillRectangle(Brushes.Black, 15, 12, 2, 10); // Exclamation mark vertical line
                g.FillRectangle(Brushes.Black, 15, 24, 2, 2);  // Exclamation mark dot
            }
            warningIcon.Image = warningBitmap;

            // Product name label
            Label lblProduct = new Label
            {
                Text = productName,
                Font = new Font("Arial", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(50, 10)
            };

            // Ingredient name label
            Label lblIngredient = new Label
            {
                Text = $"Contains: {ingredientName}",
                Font = new Font("Arial", 8.5f, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(50, 30)
            };

            // Side effects label
            Label lblSideEffects = new Label
            {
                Text = $"Potential effects: {sideEffects}",
                Font = new Font("Arial", 8, FontStyle.Italic),
                ForeColor = Color.DarkRed,
                AutoSize = false,
                Width = 200,
                Height = 60,
                Location = new Point(50, 50)
            };

            panel.Controls.Add(warningIcon);
            panel.Controls.Add(lblProduct);
            panel.Controls.Add(lblIngredient);
            panel.Controls.Add(lblSideEffects);

            return panel;
        }

        // Modified LoadUserProducts to store product ID in panel's Tag
        private void LoadUserProducts()
        {
            // Find the scroll panel in the ProductPanel
            Panel scrollPanel = null;
            foreach (Control control in ProductPanel.Controls)
            {
                if (control is Panel && control.Location.Y == 50)
                {
                    scrollPanel = (Panel)control;
                    break;
                }
            }

            if (scrollPanel == null)
            {
                MessageBox.Show("Scroll panel not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear existing products
            scrollPanel.Controls.Clear();

            try
            {
                // Create a fresh connection using DatabaseHelper
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT up.UserProductID, up.ProductId, p.Name, pc.prodCategoryName, i.ImageData 
                FROM UserProducts up 
                JOIN Products p ON up.ProductId = p.ProductID
                JOIN prodCategories pc ON p.prodCategoryID = pc.prod_CategoryID
                JOIN Images i ON up.ProductId = i.ProductId
                WHERE up.UserID = @userId";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    int yPosition = 10;
                    int productCount = 0;

                    while (reader.Read())
                    {
                        productCount++;
                        int userProductId = reader.GetInt32(0);
                        int productId = reader.GetInt32(1);
                        string productName = reader.GetString(2);
                        string category = reader.GetString(3);
                        byte[] imageData = (byte[])reader["ImageData"];

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(ms);
                            Panel card = CreateProductCard(userProductId, productId, productName, category, image);
                            card.Tag = productId; // Store product ID for ingredient lookup
                            card.Location = new Point(10, yPosition);
                            scrollPanel.Controls.Add(card);
                            yPosition += card.Height + 10;
                        }
                    }

                    // If no products were found
                    if (productCount == 0)
                    {
                        Label noProducts = new Label
                        {
                            Text = "No products in your collection yet.",
                            AutoSize = true,
                            Location = new Point(10, 10),
                            Font = new Font("Arial", 10)
                        };
                        scrollPanel.Controls.Add(noProducts);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add a function to slide the alert panel
        private void SlideAlertPanel(bool show)
        {
            Timer timer = new Timer();
            timer.Interval = 10;
            int targetX = show ? this.Width - AlertPanel.Width : this.Width;
            int startX = show ? this.Width : this.Width - AlertPanel.Width;

            // Make sure AlertPanel is visible before moving it
            AlertPanel.Visible = true;
            AlertPanel.Location = new Point(startX, 0);

            // Bring the panel to front to ensure it's not hidden behind other controls
            AlertPanel.BringToFront();

            timer.Tick += (s, e) =>
            {
                if (show)
                {
                    if (AlertPanel.Left > targetX)
                    {
                        AlertPanel.Left -= 20;
                    }
                    else
                    {
                        AlertPanel.Left = targetX;
                        timer.Stop();
                    }
                }
                else
                {
                    if (AlertPanel.Left < targetX)
                    {
                        AlertPanel.Left += 20;
                    }
                    else
                    {
                        AlertPanel.Left = targetX;
                        AlertPanel.Visible = false;
                        timer.Stop();
                    }
                }
            };

            timer.Start();
        }

        // Add a new button for alert panel in your existing buttons
        private void AddAlertButton()
        {
            // Create a new button for alerts
            Button alertButton = new Button
            {
                Text = "Ingredient Alerts",
                Width = 150,
                Height = 40,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold)
                // Set location based on your existing UI
            };
            alertButton.FlatAppearance.BorderSize = 0;
            alertButton.Click += (s, e) =>
            {
                // Get products in user's cart and check their ingredients
                List<int> userProductIds = GetUserProductIds();
                if (userProductIds.Count > 0)
                {
                    ShowIngredientAlerts(userProductIds);
                }
                else
                {
                    MessageBox.Show("Please add products to your collection first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Add to form in an appropriate location based on your UI
            this.Controls.Add(alertButton);
        }

        // Helper method to get all user product IDs
        private List<int> GetUserProductIds()
        {
            List<int> productIds = new List<int>();

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT ProductId FROM UserProducts WHERE UserID = @userId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return productIds;
        }

        // Modify the existing productView_Click method to include an option to check ingredients
        private void productView_Click(object sender, EventArgs e)
        {
            // Debug message to confirm the button click is being registered
            Console.WriteLine("ViewProducts button clicked");

            // First ensure the connection is working and load products
            LoadUserProducts();

            // Make sure panel is visible and properly positioned before sliding
            ProductPanel.Visible = true;
            ProductPanel.Location = new Point(this.Width, 0);

            // Now slide the panel in
            SlidePanel(true);
        }

        // Keep the rest of your original methods below
        private void LoadProductImages()
        {
            try
            {
                using (SqlConnection connection = con)
                {
                    connection.Open();
                    for (int i = 1; i <= 5; i++)
                    {
                        LoadCategoryImages(connection, i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCategoryImages(SqlConnection connection, int categoryId)
        {
            string categoryName = GetCategoryName(categoryId);
            string query = @"SELECT i.ProductId, i.prodCategoryId, i.ImageData, p.Name 
                           FROM Images i 
                           JOIN Products p ON i.ProductId = p.ProductID 
                           WHERE i.prodCategoryId = @CategoryId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int imageCounter = 0;
                    while (reader.Read() && imageCounter < 5)
                    {
                        int productId = reader.GetInt32(0);
                        byte[] imageData = (byte[])reader["ImageData"];
                        string productName = reader.GetString(3);

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(ms);
                            string controlName = $"id{productId}cat{categoryId}";
                            PictureBox pictureBox = this.Controls.Find(controlName, true).FirstOrDefault() as PictureBox;

                            if (pictureBox != null)
                            {
                                pictureBox.Image = image;
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                                // Add tooltip for product name
                                ToolTip toolTip = new ToolTip();
                                toolTip.SetToolTip(pictureBox, productName);

                                // Create custom ImageCheckBox for product selection
                                var imgCheckBox = new ImageCheckBox();
                                imgCheckBox.Size = pictureBox.Size;
                                imgCheckBox.Location = pictureBox.Location;
                                imgCheckBox.ProductData = new ProductData
                                {
                                    ProductId = productId,
                                    Category = categoryName,
                                    ProductName = productName
                                };
                                imgCheckBox.Image = image;

                                // Replace original picturebox with our image checkbox
                                Panel parent = pictureBox.Parent as Panel;
                                parent.Controls.Remove(pictureBox);
                                parent.Controls.Add(imgCheckBox);

                                // Store reference to the checkbox
                                productCheckboxes[productId] = imgCheckBox;
                            }
                        }
                        imageCounter++;
                    }
                }
            }
        }

        private string GetCategoryName(int categoryId)
        {
            switch (categoryId)
            {
                case 1: return "Cleansers";
                case 2: return "Moisturizers";
                case 3: return "Serums";
                case 4: return "Sunscreens";
                case 5: return "Toners";
                default: return "Unknown";
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile(currentUserId);
            profile.Show();
            this.Close();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            // This is the SAVE button click event
            List<ProductData> selectedProducts = new List<ProductData>();

            // Find all checked products
            foreach (var checkbox in productCheckboxes.Values)
            {
                if (checkbox.Selected && checkbox.ProductData != null)
                {
                    selectedProducts.Add(checkbox.ProductData);
                }
            }

            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("No products selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Save all selected products to database
            foreach (ProductData product in selectedProducts)
            {
                SaveProductToDatabase(product.ProductId, product.Category);
            }

            MessageBox.Show($"{selectedProducts.Count} product(s) saved to your collection!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Uncheck all checkboxes after saving
            foreach (var checkbox in productCheckboxes.Values)
            {
                checkbox.Selected = false;
            }
        }

        private void SaveProductToDatabase(int productId, string category)
        {
            try
            {
                // Create a fresh connection directly using DatabaseHelper
                // This ensures we get a new connection with proper initialization
                using (SqlConnection freshConnection = DatabaseHelper.GetConnection())
                {
                    // Check if product already exists in UserProducts
                    string checkQuery = "SELECT COUNT(*) FROM UserProducts WHERE UserID = @userId AND ProductId = @id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, freshConnection))
                    {
                        checkCmd.Parameters.AddWithValue("@userId", currentUserId);
                        checkCmd.Parameters.AddWithValue("@id", productId);

                        freshConnection.Open();
                        int count = (int)checkCmd.ExecuteScalar();

                        // If product already exists, don't add it again
                        if (count > 0)
                        {
                            return;
                        }
                    }

                    // We need to reopen the connection for the next command since it was closed after the first using block
                    if (freshConnection.State != ConnectionState.Open)
                        freshConnection.Open();

                    // Set expiry date to 1 year from now
                    DateTime expiryDate = DateTime.Now.AddYears(1);

                    // Insert product into UserProducts
                    string query = "INSERT INTO UserProducts (UserID, ProductId, ExpiryDate) VALUES (@userId, @id, @expiryDate)";
                    using (SqlCommand cmd = new SqlCommand(query, freshConnection))
                    {
                        cmd.Parameters.AddWithValue("@userId", currentUserId);
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.Parameters.AddWithValue("@expiryDate", expiryDate);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SlidePanel(bool show)
        {
            // Debug to verify we're getting here
            Console.WriteLine($"SlidePanel called with show={show}");

            Timer timer = new Timer();
            timer.Interval = 10;
            int targetX = show ? this.Width - ProductPanel.Width : this.Width;
            int startX = show ? this.Width : this.Width - ProductPanel.Width;

            // Make sure ProductPanel is visible before moving it
            ProductPanel.Visible = true;
            ProductPanel.Location = new Point(startX, 0);

            // Bring the panel to front to ensure it's not hidden behind other controls
            ProductPanel.BringToFront();

            // Add debug messages to timer tick to help diagnose animation issues
            timer.Tick += (s, e) =>
            {
                if (show)
                {
                    if (ProductPanel.Left > targetX)
                    {
                        ProductPanel.Left -= 20;
                        Console.WriteLine($"Panel moving to: {ProductPanel.Left}");
                    }
                    else
                    {
                        ProductPanel.Left = targetX;
                        Console.WriteLine("Panel in final position: " + ProductPanel.Left);
                        timer.Stop();
                    }
                }
                else
                {
                    if (ProductPanel.Left < targetX)
                    {
                        ProductPanel.Left += 20;
                    }
                    else
                    {
                        ProductPanel.Left = targetX;
                        ProductPanel.Visible = false;
                        timer.Stop();
                    }
                }
            };

            timer.Start();
        }

        private void DeleteProduct(int userProductId, Panel card)
        {
            try
            {
                // Use DatabaseHelper to get a fresh connection
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM UserProducts WHERE UserProductID = @id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", userProductId);
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Find the parent scroll panel
                        Panel scrollPanel = (Panel)card.Parent;
                        scrollPanel.Controls.Remove(card);

                        // Reposition remaining cards
                        int yPosition = 10;
                        foreach (Control control in scrollPanel.Controls)
                        {
                            if (control is Panel)
                            {
                                control.Location = new Point(10, yPosition);
                                yPosition += control.Height + 10;
                            }
                        }

                        // If no cards left, show message
                        if (scrollPanel.Controls.Count == 0)
                        {
                            Label noProducts = new Label
                            {
                                Text = "No products in your collection yet.",
                                AutoSize = true,
                                Location = new Point(10, 10)
                            };
                            scrollPanel.Controls.Add(noProducts);
                        }

                        MessageBox.Show("Product removed from your collection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Panel CreateProductCard(int userProductId, int productId, string productName, string category, Image image)
        {
            // Original implementation remains the same but consider adding a check ingredients button
            Panel panel = new Panel
            {
                Width = 270,
                Height = 100,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Image = image,
                Width = 60,
                Height = 60,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 20)
            };

            Label lblName = new Label
            {
                Text = productName,
                Font = new Font("Arial", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(80, 20)
            };

            Label lblCategory = new Label
            {
                Text = category,
                Font = new Font("Arial", 8),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(80, 40)
            };

            Button btnDelete = new Button
            {
                Text = "Delete",
                Width = 70,
                Height = 25,
                BackColor = Color.LightCoral,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = userProductId,
                Location = new Point(190, 65)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) => DeleteProduct((int)btnDelete.Tag, panel);

            // Add a small alert button
            Button btnAlert = new Button
            {
                Text = "Alert",
                Width = 50,
                Height = 25,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = productId,
                Location = new Point(130, 65)
            };
            btnAlert.FlatAppearance.BorderSize = 0;
            btnAlert.Click += (s, e) =>
            {
                // Check this specific product's ingredients
                ShowIngredientAlerts(new List<int> { (int)btnAlert.Tag });
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblCategory);
            panel.Controls.Add(btnDelete);
            panel.Controls.Add(btnAlert);

            return panel;
        }

        // Keep the inner classes
        public class ImageCheckBox : Control
        {
            private bool selected = false;
            private Image image = null;
            public ProductData ProductData { get; set; }

            public ImageCheckBox()
            {
                this.SetStyle(ControlStyles.UserPaint |
                             ControlStyles.AllPaintingInWmPaint |
                             ControlStyles.DoubleBuffer |
                             ControlStyles.ResizeRedraw |
                             ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.Transparent;
                this.Cursor = Cursors.Hand;
            }

            public bool Selected
            {
                get { return selected; }
                set
                {
                    selected = value;
                    this.Invalidate(); // Redraw when selection changes
                }
            }

            public Image Image
            {
                get { return image; }
                set
                {
                    image = value;
                    this.Invalidate();
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                Graphics g = e.Graphics;

                // Draw the image
                if (image != null)
                {
                    g.DrawImage(image, new Rectangle(0, 0, this.Width, this.Height));
                }

                // Draw the checkbox in the top-right corner
                int checkSize = 18;
                Rectangle checkboxRect = new Rectangle(this.Width - checkSize - 5, 5, checkSize, checkSize);

                // Draw checkbox background
                using (SolidBrush fillBrush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(fillBrush, checkboxRect);
                }

                // Draw checkbox border
                using (Pen borderPen = new Pen(Color.FromArgb(100, 100, 100), 1))
                {
                    g.DrawRectangle(borderPen, checkboxRect);
                }

                // If selected, draw a checkmark
                if (selected)
                {
                    using (Pen checkPen = new Pen(Color.Black, 2))
                    {
                        // Draw checkmark
                        Point[] checkPoints = new Point[] {
                        new Point(checkboxRect.Left + 3, checkboxRect.Top + checkSize/2),
                        new Point(checkboxRect.Left + checkSize/3, checkboxRect.Bottom - 3),
                        new Point(checkboxRect.Right - 3, checkboxRect.Top + 3)
                    };
                        g.DrawLines(checkPen, checkPoints);
                    }
                }
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Selected = !Selected; // Toggle selection
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                this.Invalidate();
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                this.Invalidate();
            }
        }

        public class ProductData
        {
            public int ProductId { get; set; }
            public string Category { get; set; }
            public string ProductName { get; set; }
        }
        private void CatalogPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}