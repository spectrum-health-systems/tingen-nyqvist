// u251207_code
// u251207_documentation

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

    /* Event Handlers
     */
    private void txbxNyqvistUser_TextChanged(object sender, TextChangedEventArgs e) => ControlMonitor.CredentialChanged(lblNyqvistUser, txbxNyqvistUser, lblNyqvistUser, lblNyqvistPass, lblQuery, btnQueryReset, txbxQuery, lblAvatarSystems, AvatarSystemButtons);
    private void txbxNyqvistPass_TextChanged(object sender, TextChangedEventArgs e) => ControlMonitor.CredentialChanged(lblNyqvistPass, txbxNyqvistPass, lblNyqvistUser, lblNyqvistPass, lblQuery, btnQueryReset, txbxQuery, lblAvatarSystems, AvatarSystemButtons);
    private void txbxQuery_TextChanged(object sender, TextChangedEventArgs e) => ControlMonitor.QueryChanged(lblQuery.Foreground, txbxQuery.Text, btnQueryReset, lblAvatarSystems, AvatarSystemButtons);
    private void btnQueryReset_Click(object sender, RoutedEventArgs e) => txbxQuery.Clear();

}