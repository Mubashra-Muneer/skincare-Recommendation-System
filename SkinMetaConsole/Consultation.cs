using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing.Drawing2D;

namespace SkinMetaConsole
{
    public partial class Consultation : Form
    {
        private const string API_KEY = "AIzaSyBHTKGfUytNy8fCPm98lAjpKfr3MwXPVus";
        private HttpClient client;
        private List<ChatMessage> messages = new List<ChatMessage>();
        private int currentUserID;
        // Remove duplicate homeButton declaration here

        public Consultation(int userid)
        {
            InitializeComponent();
            // Add after the InitializeComponent call
            // Create sendButton if not done in Designer
            currentUserID = userid;
            if (sendButton == null)
            {
                sendButton = new Button();
                sendButton.Size = new Size(40, 40);
                sendButton.Location = new Point(10, 10); // adjust position
                this.Controls.Add(sendButton);
            }

            CustomizeComponents();
            AddSampleMessages();

            // homeButton is already created in designer.cs, so we don't need to create it again
            // Just add the event handler

            // Add resize handler
            this.Resize += (sender, e) => {
                RepositionMessages();
            };

            // Add event handlers
            messageInput.KeyDown += MessageInput_KeyDown;
            sendButton.Click += SendButton_Click;
            CreateBackButton();
        }

        // Keep only one HomeButton_Click handler
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
            GraphicsPath btnPath = new GraphicsPath();
            btnPath.AddEllipse(0, 0, backButton.Width, backButton.Height);
            backButton.Region = new Region(btnPath);

            // Set colors and styles
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.BackColor = Color.IndianRed;
            backButton.ForeColor = Color.White;

            // Add click event handler
            backButton.Click += (sender, e) =>
            {
                UserProfile profile = new UserProfile(currentUserID);
                profile.Show();
                this.Hide();
            };

            // Add button to form
            this.Controls.Add(backButton);

            // Bring button to front to ensure visibility
            backButton.BringToFront();
        }

        private async void GetAIResponse(string userInput)
        {
            try
            {
                if (client == null)
                    client = new HttpClient();

                // Create the request body with the proper structure
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = userInput }
                            }
                        }
                    }
                };

                string json = JsonConvert.SerializeObject(requestBody);

                // Create a proper HttpRequestMessage
                var request = new HttpRequestMessage(HttpMethod.Post,
                    $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={API_KEY}");

                // Set content with proper content headers
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                request.Content = content;

                // Send the request
                var response = await client.SendAsync(request);

                // Add detailed error handling
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    AddMessage($"API Error: {response.StatusCode}", false);

                    // Log the detailed error for debugging
                    System.Diagnostics.Debug.WriteLine($"API Error Response: {errorContent}");
                    return;
                }

                string responseString = await response.Content.ReadAsStringAsync();

                // Debug log
                System.Diagnostics.Debug.WriteLine("API Success Response: " + responseString);

                JObject responseJson = JObject.Parse(responseString);
                string reply = responseJson["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                if (!string.IsNullOrEmpty(reply))
                {
                    AddMessage(reply.Trim(), false);
                }
                else
                {
                    AddMessage("No response from Gemini.", false);
                }
            }
            catch (HttpRequestException httpEx)
            {
                AddMessage($"Network Error: {httpEx.Message}", false);
                System.Diagnostics.Debug.WriteLine("HTTP Exception: " + httpEx.ToString());
            }
            catch (Exception ex)
            {
                AddMessage("Error: " + ex.Message, false);
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.ToString());
            }
        }
        private void CustomizeComponents()
        {
            // Make send button circular
            GraphicsPath btnPath = new GraphicsPath();
            btnPath.AddEllipse(0, 0, sendButton.Width, sendButton.Height);
            sendButton.Region = new Region(btnPath);

            // Set colors and styles
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.BackColor = Color.IndianRed;
            sendButton.ForeColor = Color.White;
            sendButton.Text = "➤";
            sendButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Style the chat container
            chatContainer.BackColor = Color.MistyRose;

            // Style the input area
            bottomPanel.BackColor = Color.White;
            messageInput.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AddSampleMessages()
        {
            // Add sample messages matching exactly what's in the screenshot
            AddMessage("Hi", true);
            AddMessage("This is SkinMeta! How can I help you?", false);
        }

        // Add this method to your Consultation class
        private async void ListAvailableModels()
        {
            try
            {
                if (client == null)
                    client = new HttpClient();

                // Create a proper HttpRequestMessage for the GET request
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://generativelanguage.googleapis.com/v1beta/models?key={API_KEY}");

                // Send the request
                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();
                string responseString = await response.Content.ReadAsStringAsync();

                JObject responseJson = JObject.Parse(responseString);

                // Create a readable message with available models
                StringBuilder modelsInfo = new StringBuilder("Available Gemini Models:\n\n");

                var models = responseJson["models"] as JArray;
                if (models != null)
                {
                    foreach (var model in models)
                    {
                        string name = model["name"]?.ToString();
                        string displayName = model["displayName"]?.ToString();
                        string version = model["version"]?.ToString();

                        modelsInfo.AppendLine($"• {name} ({displayName}) - v{version}");
                    }

                    // Add this message to the chat
                    AddMessage(modelsInfo.ToString(), false);

                    // Also log to debug console
                    System.Diagnostics.Debug.WriteLine(modelsInfo.ToString());
                }
                else
                {
                    AddMessage("No models found in the response", false);
                }
            }
            catch (Exception ex)
            {
                AddMessage("Error listing models: " + ex.Message, false);
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.ToString());
            }
        }

        // Add this button and handler to your form to test available models
        private void AddListModelsButton()
        {
            Button listModelsBtn = new Button
            {
                Text = "List Available Models",
                Location = new Point(10, 10),
                Size = new Size(150, 30)
            };

            listModelsBtn.Click += (sender, e) => {
                ListAvailableModels();
            };

            this.Controls.Add(listModelsBtn);
        }
        private void AddMessage(string text, bool isRight)
        {
            // Create message object
            ChatMessage message = new ChatMessage
            {
                Text = text,
                IsRight = isRight,
                Timestamp = DateTime.Now
            };
            messages.Add(message);

            // Display all messages
            DisplayMessages();
        }

        private void DisplayMessages()
        {
            // Clear current messages from display
            chatContainer.Controls.Clear();

            int yPosition = 10;

            // Display each message
            foreach (var message in messages)
            {
                // Create message label for content
                Label msgLabel = new Label
                {
                    Text = message.Text,
                    AutoSize = true,
                    MaximumSize = new Size((int)(chatContainer.Width * 0.68), 0),
                    ForeColor = message.IsRight ? Color.White : Color.IndianRed,
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Transparent,
                    Padding = new Padding(10, 8, 10, 8)
                };

                // Calculate size needed
                Size textSize = TextRenderer.MeasureText(msgLabel.Text, msgLabel.Font, msgLabel.MaximumSize, TextFormatFlags.WordBreak);
                int width = textSize.Width + msgLabel.Padding.Horizontal;
                int height = textSize.Height + msgLabel.Padding.Vertical;

                // Create bubble panel
                RoundedPanel bubble = new RoundedPanel
                {
                    Size = new Size(width, height),
                    MinimumSize = new Size(50, 35),
                    BackColor = message.IsRight ? Color.LightCoral : Color.White
                };

                bubble.Controls.Add(msgLabel);
                msgLabel.Location = new Point(0, 0);
                msgLabel.Size = bubble.Size;

                chatContainer.Controls.Add(bubble);

                // Position the bubble based on whether it's a sent or received message
                if (message.IsRight)
                {
                    bubble.Left = chatContainer.Width - bubble.Width - 15;
                }
                else
                {
                    bubble.Left = 15;
                }

                bubble.Top = yPosition;
                yPosition += bubble.Height + 10;
            }

            // Scroll to bottom
            if (chatContainer.VerticalScroll.Visible)
            {
                // Try to scroll to the bottom
                chatContainer.AutoScrollPosition = new Point(0, chatContainer.VerticalScroll.Maximum);

                // Alternative scrolling method
                SendWindowsMessage message = new SendWindowsMessage();
                message.wparam = chatContainer.Handle;
                message.msg = 0x115; // WM_VSCROLL
                message.lparam = 1; // SB_BOTTOM
                message.Send();
            }
        }

        private void RepositionMessages()
        {
            // Reposition all message bubbles when the form is resized
            DisplayMessages();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendUserMessage();
        }

        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendUserMessage();
                e.SuppressKeyPress = true; // Prevent the ding sound
            }
        }

        private void SendUserMessage()
        {
            string message = messageInput.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                AddMessage(message, true);  // User message
                messageInput.Text = "";
                GetAIResponse(message);     // AI reply
            }
        }
    }

    // Class to store message data
    public class ChatMessage
    {
        public string Text { get; set; }
        public bool IsRight { get; set; } // True if the message is on the right (sent by user)
        public DateTime Timestamp { get; set; }
    }

    // Custom rounded panel for message bubbles
    public class RoundedPanel : Panel
    {
        private int radius = 15;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                // Make rounded corners
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);

                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }
            }

            base.OnPaint(e);
        }
    }

    // Helper class to send Windows messages
    public class SendWindowsMessage
    {
        public IntPtr wparam;
        public int msg;
        public int lparam;

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessageInternal(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public void Send()
        {
            SendMessageInternal(wparam, msg, new IntPtr(0), new IntPtr(lparam));
        }
    }
}