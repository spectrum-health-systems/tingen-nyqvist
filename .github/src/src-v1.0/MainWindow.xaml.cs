
        /// <summary>Attempt to perform a query against an Avatar System.</summary>
        /// <param name="sender">The Avatar System button that was pressed.</param>
        /// <param name="avatarSystem">The Avatar System to be queried.</param>
        private void AttemptQuery(object sender, string avatarSystem)
        {
            if (txbxQuery.Text != "" && txbxNyqvistUserName.Text != "" && pwbxNyqvistUserPass.Password != "")
            {
                try
                {
                    txbxResult.Text = PerformQuery(avatarSystem, txbxNyqvistUserName.Text.Trim(), pwbxNyqvistUserPass.Password.Trim(), txbxQuery.Text.Trim());
                    txbxWebServiceCall.Text = (!txbxResult.Text.Contains("The sql query which you provided returned an error."))
                        ? UpdateWebServiceCall(avatarSystem, txbxQuery.Text)
                        : "";
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

        /// <summary>Perform a query against an Avatar System.</summary>
        /// <param name="avatarSystem">The Avatar System to be queried.</param>
        /// <param name="nyqvistUserName">The username for the query.</param>
        /// <param name="nyqvistUserPass">The password for the query.</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>The result of the query.</returns>
        /// <exception cref="ArgumentException"></exception>
        private static string PerformQuery(string avatarSystem, string nyqvistUserName, string nyqvistUserPass, string queryString)
        {
            switch (avatarSystem)
            {
                case "LIVE":
                    return new NtstWsvcLiveQuery.Query().SubmitQuery("LIVE", nyqvistUserName, nyqvistUserPass, queryString);
                case "UAT":
                    return new NtstWsvcUatQuery.Query().SubmitQuery("UAT", nyqvistUserName, nyqvistUserPass, queryString);
                case "SBOX":
                    return new NtstWsvcSboxQuery.Query().SubmitQuery("SBOX", nyqvistUserName, nyqvistUserPass, queryString);
                default:
                    throw new ArgumentException("Invalid system specified.");
            }
        }

        /// <summary>
        /// Constructs and returns a web service call string based on the specified system and query.
        /// </summary>
        /// <param name="avatarSystem">The target system for the web service call. Valid values are "LIVE", "UAT", and "SBOX".</param>
        /// <param name="queryString">The query string to be included in the web service call.</param>
        /// <returns>A formatted string representing the web service call for the specified system and query.</returns>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="avatarSystem"/> parameter is not one of the valid values: "LIVE", "UAT", or "SBOX".</exception>
        private static string UpdateWebServiceCall(string avatarSystem, string queryString)
        {
            switch (avatarSystem)
            {
                case "LIVE":
                    return $"NtstWsvcLiveQuery.Query().SubmitQuery(\"LIVE\", \"USERNAME\", \"PASSWORD\", \"{queryString}\");";
                case "UAT":
                    return $"NtstWsvcUatQuery.Query().SubmitQuery(\"UAT\", \"USERNAME\", \"PASSWORD\", \"{queryString}\");";
                case "SBOX":
                    return $"NtstWsvcSboxQuery.Query().SubmitQuery(\"SBOX\", \"USERNAME\", \"PASSWORD\", \"{queryString}\");";
                default:
                    throw new ArgumentException("Invalid system specified.");
            }

        }



        ///// <summary>Toggle the state of the query result buttons.</summary>
        //private void ToggleResultButtons()
        //{
        //    if (txbxResult.Text != "")
        //    {
        //        btnFormatResultXml.IsEnabled = true;
        //        btnCopyResultXml.IsEnabled   = true;
        //    }
        //    else
        //    {
        //        btnFormatResultXml.IsEnabled = false;
        //        btnCopyResultXml.IsEnabled   = false;
        //    }
        //}



        /*
         * Event Handlers
         */

        //private void pwbxNyqvistUserPass_PasswordChanged(object sender, RoutedEventArgs e) => ToggleSystemButtons();
        //private void txbxQuery_TextChanged(object sender, TextChangedEventArgs e) => ToggleSystemButtons();
        //private void btnLiveSystem_Click(object sender, RoutedEventArgs e) => AttemptQuery(sender, "LIVE");
        //private void btnUatSystem_Click(object sender, RoutedEventArgs e) => AttemptQuery(sender, "UAT");
        //private void btnSboxSystem_Click(object sender, RoutedEventArgs e) => AttemptQuery(sender, "SBOX");
        //private void txbxResult_TextChanged(object sender, TextChangedEventArgs e) => ToggleResultButtons();
        //private void btnFormatResultXml_Click(object sender, RoutedEventArgs e) => FormatXML();
        //private void btnCopyResultXml_Click(object sender, RoutedEventArgs e) => Clipboard.SetText(txbxResult.Text);
        //private void txbxWebServiceCall_TextChanged(object sender, TextChangedEventArgs e) => ToggleWebServiceCallButtons();
        //private void btnCopyWebServiceCall_Click(object sender, RoutedEventArgs e) => Clipboard.SetText(txbxWebServiceCall.Text);
    }
}
