// u2512010_code
// u2512010_documentation

using System.Windows;
using System.Windows.Controls;

namespace TingenNyqvist.AvatarSystem;

internal class Query
{
    internal static void Attempt(string avatarSystem, string nyqvistUser, string nyqvistPass, string query, TextBox txbxResult, TextBox txbxWebServiceCall)
    {
        try
        {
            txbxResult.Text = PerformQuery(avatarSystem, nyqvistUser.Trim(), nyqvistPass.Trim(), query);
            UpdateWebServiceCall(avatarSystem, query, txbxResult.Text, txbxWebServiceCall);
        }
        catch (Exception ex)
        {
            string errorMessage = "An error occurred while submitting query: " + ex.Message + ".";
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            txbxResult.Text = errorMessage;
            txbxWebServiceCall.Text = "";
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
            //return new NtstWsvcQueryLive.Query().SubmitQuery("LIVE", nyqvistUserName, nyqvistUserPass, queryString);
            case "UAT":
            //return new NtstWsvcQueryUat.Query().SubmitQuery("UAT", nyqvistUserName, nyqvistUserPass, queryString);
            case "SBOX":
                //return new NtstWsvcQuerySbox.Query().SubmitQuery("SBOX", nyqvistUserName, nyqvistUserPass, queryString);
                return "placeholder result for SBOX query";
            case "BLD":
            //return new NtstWsvcQueryBld.Query().SubmitQuery("SBOX", nyqvistUserName, nyqvistUserPass, queryString);
            default:
                throw new ArgumentException($"Invalid system specified: {avatarSystem}");
        }
    }

    private static void UpdateWebServiceCall(string avatarSystem, string query, string queryResult, TextBox txbxWebServiceCall)
    {
        if (!queryResult.Contains("The SQL query which you provided returned an error."))
        {
            switch (avatarSystem)
            {
                case "LIVE":
                    txbxWebServiceCall.Text = $"NtstWsvcLiveQuery.Query().SubmitQuery(\"LIVE\", \"USERNAME\", \"PASSWORD\", \"{query}\");";
                    break;

                case "UAT":
                    txbxWebServiceCall.Text = $"NtstWsvcUatQuery.Query().SubmitQuery(\"UAT\", \"USERNAME\", \"PASSWORD\", \"{query}\");";
                    break;

                case "SBOX":
                    txbxWebServiceCall.Text =  $"NtstWsvcSboxQuery.Query().SubmitQuery(\"SBOX\", \"USERNAME\", \"PASSWORD\", \"{query}\");";
                    break;

                default:
                    txbxWebServiceCall.Text =  $"Invalid system specified.";
                    throw new ArgumentException("Invalid system specified.");
            }
        }

    }
}