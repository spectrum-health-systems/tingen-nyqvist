// u251207_code
// u2512010_documentation

using System.Reflection;

namespace TingenNyqvist.UserInterface
{
    /// <summary>Logic for the user interface.</summary>
    internal class MainInterface
    {
        /// <summary>Setup the main window for a new session.</summary>
        internal static void Initialize(Configuration config, MainWindow mainWindow)
        {
            mainWindow.Title                = $"Tingen NYQVIST v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            mainWindow.txbxNyqvistUser.Text = config.TingenUserName.ToUpper().Trim();

            HideControls(mainWindow);
        }

        /// <summary>Hides the query reset and format XML buttons from the main window.</summary>
        private static void HideControls(MainWindow mainWindow)
        {
            mainWindow.btnQueryReset.Visibility = System.Windows.Visibility.Collapsed;
            mainWindow.btnFormatXml.Visibility  = System.Windows.Visibility.Collapsed;
        }
    }
}