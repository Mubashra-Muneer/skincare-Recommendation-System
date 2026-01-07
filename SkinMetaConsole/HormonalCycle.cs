using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SkinMetaConsole
{
    public partial class HormonalCycle : Form
    {
        private SqlConnection con = DatabaseHelper.GetConnection();
        private int currentUserID;
        private DateTime selectedDate = DateTime.Today;
        private Guna.UI2.WinForms.Guna2Button homeButton;
        private enum HormonalPhase
        {
            Menstruation, Follicular, Ovulation, Luteal
        }

        public HormonalCycle(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
            ConfigureTextBox();
        }

        private void ConfigureTextBox()
        {
            guna2TextBox1.Multiline = true;
            guna2TextBox1.ScrollBars = ScrollBars.Vertical;
            guna2TextBox1.WordWrap = true;
        }

        private void HormonalCycle_Load(object sender, EventArgs e)
        {
            LoadUserPeriodData();
            CalculateAndDisplayPhase(selectedDate);
            monthCalendar1.SetDate(selectedDate);
        }

        private void LoadUserPeriodData()
        {
            try
            {
                con.Open();
                string query = "SELECT LastPeriodDate FROM UserCycle WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        guna2DateTimePicker1.Value = Convert.ToDateTime(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading period data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { con.Close(); }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayPhase(selectedDate);
            SavePeriodDate();
        }

        private void SavePeriodDate()
        {
            try
            {
                con.Open();
                string query = @"
                    IF EXISTS (SELECT 1 FROM UserCycle WHERE UserID = @UserID)
                        UPDATE UserCycle SET LastPeriodDate = @LastPeriodDate WHERE UserID = @UserID
                    ELSE
                        INSERT INTO UserCycle (UserID, LastPeriodDate) VALUES (@UserID, @LastPeriodDate)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);
                    cmd.Parameters.AddWithValue("@LastPeriodDate", guna2DateTimePicker1.Value.Date);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving date: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { con.Close(); }
        }

        private void CalculateAndDisplayPhase(DateTime targetDate)
        {
            selectedDate = targetDate;
            DateTime lastPeriod = guna2DateTimePicker1.Value.Date;
            int cycleDay = (targetDate - lastPeriod).Days + 1;

            cycleDay = cycleDay < 0 ? cycleDay + 28 : cycleDay % 28;
            cycleDay = cycleDay == 0 ? 28 : cycleDay;

            HormonalPhase phase;
            if (cycleDay <= 5)
                phase = HormonalPhase.Menstruation;
            else if (cycleDay <= 13)
                phase = HormonalPhase.Follicular;
            else if (cycleDay <= 16)
                phase = HormonalPhase.Ovulation;
            else
                phase = HormonalPhase.Luteal;

            UpdatePhaseUI(phase);
            ShowRecommendations(phase);
        }

        private void UpdatePhaseUI(HormonalPhase phase)
        {
            ResetPhaseButtons();
            Guna2CircleButton activeButton;

            switch (phase)
            {
                case HormonalPhase.Menstruation:
                    activeButton = labelMenstruation;
                    break;
                case HormonalPhase.Follicular:
                    activeButton = labelFollicular;
                    break;
                case HormonalPhase.Ovulation:
                    activeButton = labelOvulation;
                    break;
                default:
                    activeButton = labelLuteal;
                    break;
            }

            activeButton.FillColor = Color.IndianRed;
            activeButton.ForeColor = Color.White;
        }

        private void ResetPhaseButtons()
        {
            // Reset all phase buttons to default appearance
            labelMenstruation.FillColor = Color.FromArgb(255, 239, 213);
            labelMenstruation.ForeColor = Color.Black;

            labelFollicular.FillColor = Color.FromArgb(255, 239, 213);
            labelFollicular.ForeColor = Color.Black;

            labelOvulation.FillColor = Color.FromArgb(255, 239, 213);
            labelOvulation.ForeColor = Color.Black;

            labelLuteal.FillColor = Color.FromArgb(255, 239, 213);
            labelLuteal.ForeColor = Color.Black;
        }

        private void ShowRecommendations(HormonalPhase phase)
        {
            StringBuilder sb = new StringBuilder();

            // Phase description with proper spacing
            sb.AppendLine(GetPhaseDescription(phase));
            sb.AppendLine(); // Add extra blank line

            // Product recommendations section
            sb.AppendLine("Recommended Products:");
            sb.AppendLine(GetPhaseProducts(phase));

            // Set the text with proper formatting
            guna2TextBox1.Text = sb.ToString();
        }

        private string GetPhaseDescription(HormonalPhase phase)
        {
            switch (phase)
            {
                case HormonalPhase.Menstruation:
                    return "Menstruation Phase (Days 1-5):\n" +
                           "• Sensitive skin\n" +
                           "• Use gentle cleansers\n" +
                           "• Avoid harsh exfoliants";

                case HormonalPhase.Follicular:
                    return "Follicular Phase (Days 6-13):\n" +
                           "• Best skin days\n" +
                           "• Use active ingredients\n" +
                           "• Hydration focus";

                case HormonalPhase.Ovulation:
                    return "Ovulation Phase (Days 14-16):\n" +
                           "• Increased oil\n" +
                           "• Use oil-control products\n" +
                           "• Prevent clogged pores";

                default: // Luteal
                    return "Luteal Phase (Days 17-28):\n" +
                           "• Hormonal acne\n" +
                           "• Anti-inflammatory products\n" +
                           "• Maintain hydration";
            }
        }
        private string GetPhaseProducts(HormonalPhase phase)
        {
            StringBuilder result = new StringBuilder();

            // Hardcoded products based on the hormonal phase
            switch (phase)
            {
                case HormonalPhase.Menstruation:
                    result.AppendLine("Recommended Products for Menstruation Phase:");
                    result.AppendLine("• CeraVe Hydrating Cleanser by CeraVe");
                    result.AppendLine("• La Roche-Posay Toleriane Hydrating Gentle Cleanser by La Roche-Posay");
                    result.AppendLine("• CeraVe Moisturizing Cream by CeraVe");
                    result.AppendLine("• Embryolisse Lait-Crème Concentré by Embryolisse");
                    result.AppendLine("• LANEIGE Cream Skin Toner & Moisturizer by LANEIGE");
                    break;

                case HormonalPhase.Follicular:
                    result.AppendLine("Recommended Products for Follicular Phase:");
                    result.AppendLine("• The Ordinary Niacinamide 10% + Zinc 1% by The Ordinary");
                    result.AppendLine("• Skinceuticals C E Ferulic by Skinceuticals");
                    result.AppendLine("• Estée Lauder Advanced Night Repair by Estée Lauder");
                    result.AppendLine("• The Ordinary Glycolic Acid 7% Toning Solution by The Ordinary");
                    result.AppendLine("• Olay Regenerist Micro-Sculpting Cream by Olay");
                    break;

                case HormonalPhase.Ovulation:
                    result.AppendLine("Recommended Products for Ovulation Phase:");
                    result.AppendLine("• Fresh Soy Face Cleanser by Fresh");
                    result.AppendLine("• Neutrogena Hydro Boost Water Gel by Neutrogena");
                    result.AppendLine("• Supergoop! Unseen Sunscreen SPF 40 by Supergoop!");
                    result.AppendLine("• Drunk Elephant C-Firma Day Serum by Drunk Elephant");
                    result.AppendLine("• Neutrogena Ultra Sheer Dry-Touch Sunscreen SPF 100+ by Neutrogena");
                    break;

                case HormonalPhase.Luteal:
                    result.AppendLine("Recommended Products for Luteal Phase:");
                    result.AppendLine("• Neutrogena Oil-Free Acne Wash by Neutrogena");
                    result.AppendLine("• The Ordinary Niacinamide 10% + Zinc 1% by The Ordinary");
                    result.AppendLine("• La Roche-Posay Anthelios Clear Skin Oil-Free Sunscreen SPF 60 by La Roche-Posay");
                    result.AppendLine("• Paula's Choice Skin Balancing Toner by Paula's Choice");
                    result.AppendLine("• Kiehl's Calendula Herbal Extract Toner by Kiehl's");
                    break;

                default:
                    result.AppendLine("No specific products found for this phase.");
                    break;
            }

            return result.ToString();
        }


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            CalculateAndDisplayPhase(e.Start);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile(currentUserID);
            profile.Show();
            this.Hide();
        }
    }
}