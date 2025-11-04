// =============================================================================
// TingenNYQVIST
// https://github.com/spectrum-health-systems/tingen-nyqvist
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u251104_code
// u251104_documentation
// =============================================================================

using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace TingenNYQVIST
{
    /// <summary>Entry class for Tingen NYQVIST.</summary>
    public partial class MainWindow : Window
    {
        /// <summary>Entry method for Tingen NYQVIST.</summary>
        public MainWindow()
        {
            InitializeComponent();

            SetupWindow(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        /// <summary>Setup the main window for a new session.</summary>
        /// <param name="version">The version of Tingen NYQVIST.</param>
        private void SetupWindow(string version)
        {
            Title                    = $"Tingen NYQVIST v{version}";
            txbxNyqvistUserName.Text = GetNyqvistUserName(@"./AppData/Config/username.txt");

        }

        /// <summary>Get the Avatar username that Tingen NYQVIST will use from an external file.</summary>
        /// <remarks>
        ///   If the username file does not exist, an empty string is returned.
        /// </remarks>
        /// <returns>An Avatar username.</returns>
        private string GetNyqvistUserName(string usernameFile) => (File.Exists(usernameFile))
                ? File.ReadAllText(usernameFile)
                : "";

        /// <summary>Attempt to perform a query against an Avatar System.</summary>
        /// <param name="sender">The Avatar System button that was pressed.</param>
        /// <param name="system">The Avatar System to be queried.</param>
        private void AttemptQuery(object sender, string system)
        {
            if (txbxQuery.Text != "" && txbxNyqvistUserName.Text != "" && pwbxNyqvistUserPass.Password != "")
            {
                try
                {
                    txbxResult.Text         = PerformQuery(system, txbxNyqvistUserName.Text.Trim(), pwbxNyqvistUserPass.Password, txbxQuery.Text);

                    if (!txbxResult.Text.Contains("The sql query which you provided returned an error."))
                    {
                        txbxWebServiceCall.Text = UpdateWebServiceCall(system, txbxQuery.Text);
                    }
                    else
                    {
                        txbxWebServiceCall.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = "An error occurred while submitting query: " + ex.Message + ".";

                    MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    txbxResult.Text = errorMessage;

                    txbxWebServiceCall.Text = "";
                }

                HighlightSystemButton(sender);
            }
        }

        private static string PerformQuery(string system, string nyqvistUserName, string nyqvistUserPass, string query)
        {
            switch (system)
            {
                case "LIVE":
                    return new NtstWsvcLiveQuery.Query().SubmitQuery("LIVE", nyqvistUserName, nyqvistUserPass, query);

                case "UAT":
                    return new NtstWsvcUatQuery.Query().SubmitQuery("UAT", nyqvistUserName, nyqvistUserPass, query);

                case "SBOX":
                    return new NtstWsvcSboxQuery.Query().SubmitQuery("SBOX", nyqvistUserName, nyqvistUserPass, query);

                default:
                    throw new ArgumentException("Invalid system specified.");
            }
        }

        private static string UpdateWebServiceCall(string system, string query)
        {
            switch (system)
            {
                case "LIVE":
                    return $"NtstWsvcLiveQuery.Query().SubmitQuery(\"LIVE\", \"USERNAME\", \"PASSWORD\", \"{query}\");";

                case "UAT":
                    return $"NtstWsvcUatQuery.Query().SubmitQuery(\"UAT\", \"USERNAME\", \"PASSWORD\", \"{query}\");";

                case "SBOX":
                    return $"NtstWsvcSboxQuery.Query().SubmitQuery(\"SBOX\", \"USERNAME\", \"PASSWORD\", \"{query}\");";

                default:
                    throw new ArgumentException("Invalid system specified.");
            }

        }

        private void FormatXML()
        {
            txbxResult.FontSize = 12;
            var test = txbxResult.Text;

            var test2 = PrettyPrintXml(test);

            txbxResult.Text = test2;
        }

        private static string PrettyPrintXml(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            return doc.ToString();
        }


        private void HighlightSystemButton(object sender)
        {
            btnLiveSystem.ClearValue(Button.BackgroundProperty);
            btnUatSystem.ClearValue(Button.BackgroundProperty);
            btnSboxSystem.ClearValue(Button.BackgroundProperty);

            var button = sender as Button;

            button.Background = Brushes.Green;
        }

        private void ToggleSystemButtons()
        {
            if (txbxQuery.Text != "" && txbxNyqvistUserName.Text != "" && pwbxNyqvistUserPass.Password != "")
            {
                btnLiveSystem.IsEnabled = true;
                btnUatSystem.IsEnabled  = true;
                btnSboxSystem.IsEnabled = true;
            }
            else
            {
                btnLiveSystem.IsEnabled = false;
                btnUatSystem.IsEnabled  = false;
                btnSboxSystem.IsEnabled = false;
            }
        }

        private void ToggleResultButtons()
        {
            if (txbxResult.Text != "")
            {
                btnFormatResultXml.IsEnabled = true;
                btnCopyResultXml.IsEnabled   = true;
            }
            else
            {
                btnFormatResultXml.IsEnabled = false;
                btnCopyResultXml.IsEnabled   = false;
            }
        }

        private void ToggleWebServiceCallButtons()
        {
            if (txbxWebServiceCall.Text != "")
            {
                btnCopyWebServiceCall.IsEnabled = true;
            }
            else
            {
                btnCopyWebServiceCall.IsEnabled = false;
            }
        }


        private void pwbxNyqvistUserPass_PasswordChanged(object sender, RoutedEventArgs e) => ToggleSystemButtons();


        private void btnLiveSystem_Click(object sender, RoutedEventArgs e) => AttemptQuery(sender, "LIVE");

        private void btnUatSystem_Click(object sender, RoutedEventArgs e) => AttemptQuery(sender, "UAT");
        private void btnSboxSystem_Click(object sender, RoutedEventArgs e) => AttemptQuery(sender, "SBOX");

        private void btnFormatResultXml_Click(object sender, RoutedEventArgs e) => FormatXML();

        private void btnCopyResultXml_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txbxResult.Text);
        }

        private void txbxQuery_TextChanged(object sender, TextChangedEventArgs e) => ToggleSystemButtons();

        private void txbxResult_TextChanged(object sender, TextChangedEventArgs e) => ToggleResultButtons();

        private void btnCopyWebServiceCall_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txbxWebServiceCall.Text);
        }

        private void txbxWebServiceCall_TextChanged(object sender, TextChangedEventArgs e) => ToggleWebServiceCallButtons();
    }
}
