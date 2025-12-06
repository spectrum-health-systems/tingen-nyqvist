// u251206_code
// u251206_documentation

using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TingenNyqvist;

/// <summary>Entry class for Tingen NYQVIST.</summary>
public partial class MainWindow : Window
{
    public Configuration Config { get; set; }

    /// <summary>Entry method for Tingen NYQVIST.</summary>
    public MainWindow()
    {
        InitializeComponent();

        Configuration Config = Configuration.Load();

        SetupWindow(Config);
    }

    /// <summary>Setup the main window for a new session.</summary>
    private void SetupWindow(Configuration config)
    {
        Title                    = $"Tingen NYQVIST v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        txbxNyqvistUserName.Text = config.TingenUserName.ToUpper().Trim();
    }

    private void LoginCredentialChanged(Label label, string text)
    {
        LabelToggle(label, text);
        QueryLabelState();
    }

    private static void LabelToggle(Label labelToModify, string text) =>
        labelToModify.Foreground = string.IsNullOrWhiteSpace(text)
            ? Brushes.White
            : Brushes.LawnGreen;

    private static void LabelToggle(Label labelToModify, Brush color) =>
        labelToModify.Foreground = color == Brushes.LawnGreen
            ? Brushes.LawnGreen
            : Brushes.White;

    private static void LabelToggle(Label labelToModify, Brush colorOne, Brush colorTwo) =>
        labelToModify.Foreground = (colorOne == Brushes.LawnGreen) && (colorTwo == Brushes.LawnGreen)
            ? Brushes.LawnGreen
            : Brushes.White;

    private void QueryLabelState()
    {
        LabelToggle(lblQuery, lblNyqvistUserName.Foreground, lblNyqvistUserPassword.Foreground);

        txbxQuery.IsEnabled = lblQuery.Foreground == Brushes.LawnGreen;
    }

    private void SystemButtonState()
    {
        if (!string.IsNullOrWhiteSpace(txbxQuery.Text) && lblQuery.Foreground == System.Windows.Media.Brushes.LawnGreen)
        {
            lblQuerySystem.Foreground = System.Windows.Media.Brushes.LawnGreen;
            ToggleSystemButtons(true);
        }
        else
        {
            lblQuerySystem.Foreground = System.Windows.Media.Brushes.White;
            ToggleSystemButtons(false);
        }
    }

    private void ToggleSystemButtons(bool state)
    {
        var systemButtons = new[]
        {
            btnQueryLive,
            btnQueryUat,
            btnQuerySbox,
            btnQueryBld
        };

        foreach (var systemButton in systemButtons)
        {
            systemButton.IsEnabled = state;
        }
    }

    /* Event Handlers
     */
    private void txbxNyqvistUserName_TextChanged(object sender, TextChangedEventArgs e) => LoginCredentialChanged(lblNyqvistUserName, txbxNyqvistUserName.Text);
    private void txbxNyqvistUserPassword_TextChanged(object sender, TextChangedEventArgs e) => LoginCredentialChanged(lblNyqvistUserPassword, txbxNyqvistUserPassword.Text);
    private void txbxQuery_TextChanged(object sender, TextChangedEventArgs e) => LabelToggle(lblQuery, txbxQuery.Text);
}