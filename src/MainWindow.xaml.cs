// u251207_code
// u2512010_documentation

using System.Windows;
using System.Windows.Controls;
using TingenNyqvist.UserInterface;

namespace TingenNyqvist;

/// <summary>Entry class for Tingen NYQVIST.</summary>
public partial class MainWindow : Window
{
    /// <summary>Tingen NYQVIST configuration settings.</summary>
    public Configuration Config { get; set; }

    /// <summary>Sets the collection of Avatar System buttons.</summary>
    public Button[] AvatarSystemButtons { get; set; }

    /// <summary>Entry method for Tingen NYQVIST.</summary>
    public MainWindow()
    {
        InitializeComponent();

        Configuration Config = Configuration.Load();

        AvatarSystemButtons =
        [
            btnQueryLive,
            btnQueryUat,
            btnQuerySbox,
            btnQueryBld
        ];

        MainInterface.Initialize(Config, this);
    }

    /* Query handlers
     */

    /// <summary>The Live Avatar System button is clicked.</summary>
    private void btnQueryLive_Click(object sender, RoutedEventArgs e)
    {
        ControlState.AvatarSystemChosen(AvatarSystemButtons, btnQueryLive);
    }

    /// <summary>The UAT Avatar System button is clicked.</summary>
    private void btnQueryUat_Click(object sender, RoutedEventArgs e)
    {
        ControlState.AvatarSystemChosen(AvatarSystemButtons, btnQueryUat);
    }

    /// <summary>The Sbox Avatar System button is clicked.</summary>
    private void btnQuerySbox_Click(object sender, RoutedEventArgs e)
    {
        ControlState.AvatarSystemChosen(AvatarSystemButtons, btnQuerySbox);
        AvatarSystem.Query.Attempt("SBOX", txbxNyqvistUser.Text, txbxNyqvistPass.Text, txbxQuery.Text, txbxQueryResult, txbxWebServiceCall);
    }

    /// <summary>The Bld Avatar System button is clicked.</summary>
    private void btnQueryBld_Click(object sender, RoutedEventArgs e)
    {
        ControlState.AvatarSystemChosen(AvatarSystemButtons, btnQueryBld);
    }



    /* Event handlers
     */

    /// <summary>The Nyqvist user text is changed.</summary>
    private void txbxNyqvistUser_TextChanged(object sender, TextChangedEventArgs e) =>
        ControlMonitor.CredentialChanged(lblNyqvistUser, txbxNyqvistUser, lblNyqvistUser, lblNyqvistPass, lblQuery, btnQueryReset, txbxQuery, lblAvatarSystems, AvatarSystemButtons);

    /// <summary>The Nyqvist password text is changed.</summary>
    private void txbxNyqvistPass_TextChanged(object sender, TextChangedEventArgs e) =>
        ControlMonitor.CredentialChanged(lblNyqvistPass, txbxNyqvistPass, lblNyqvistUser, lblNyqvistPass, lblQuery, btnQueryReset, txbxQuery, lblAvatarSystems, AvatarSystemButtons);

    /// <summary>The query text is changed.</summary>
    private void txbxQuery_TextChanged(object sender, TextChangedEventArgs e) =>
        ControlMonitor.QueryChanged(lblQuery.Foreground, txbxQuery.Text, btnQueryReset, lblAvatarSystems, AvatarSystemButtons);

    /// <summary>Resets the query text box.</summary>
    private void btnQueryReset_Click(object sender, RoutedEventArgs e) =>
        txbxQuery.Clear();

    /// <summary>Formats the XML in the query result text box.</summary>
    private void btnFormatXml_Click(object sender, RoutedEventArgs e) =>
        ControlProperty.FormatXML(txbxQueryResult);
}
