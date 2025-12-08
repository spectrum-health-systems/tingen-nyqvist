// u251208_code
// u251207_documentation

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TingenNyqvist.UserInterface
{
    /// <summary>Logic for controlling the state of UI elements.</summary>
    internal class ControlState
    {
        /// <summary>Sets the foreground color of a label based the contents of a TextBox.</summary>
        /// <param name="lblToModify">The label to modify.</param>
        /// <param name="txbxContent">The text to evaluate.</param>
        internal static void LabelForground(Label lblToModify, string txbxContent) =>
            lblToModify.Foreground = string.IsNullOrWhiteSpace(txbxContent)
                ? Brushes.White
                : Brushes.LimeGreen;

        /// <summary>Sets the foreground color of a label based on the foreground color of another label.</summary>
        /// <param name="lblToModify">The label to modify.</param>
        /// <param name="lblOtherFgnd">The color of the label to compare against.</param>
        internal static void LabelForground(Label lblToModify, Brush lblOtherFgnd) =>
            lblToModify.Foreground = lblOtherFgnd == Brushes.LimeGreen
                ? Brushes.LimeGreen
                : Brushes.White;

        /// <summary>Sets the foreground color of a label based on the foreground color of two other labels.</summary>
        /// <param name="lblToModify">The label to modify.</param>
        /// <param name="lblOneFgnd">The color of the first label to compare against.</param>
        /// <param name="lblTwoFgnd">The color of the second label to compare against.</param>
        internal static void LabelForground(Label lblToModify, Brush lblOneFgnd, Brush lblTwoFgnd) =>
            lblToModify.Foreground = (lblOneFgnd == Brushes.LimeGreen) && (lblTwoFgnd == Brushes.LimeGreen)
                ? Brushes.LimeGreen
                : Brushes.White;

        /// <summary>Sets the state of the query label based on the foreground colors of the credential labels.</summary>
        /// <param name="lblUserFgnd">The Nyqvist user label foreground color.</param>
        /// <param name="lblPassFgnd">The Nyqvist password label foreground color.</param>
        /// <param name="lblQuery">The query label</param>
        /// <param name="txbxQuery">The query TextBox</param>
        internal static void QueryLabel(Brush lblUserFgnd, Brush lblPassFgnd, Label lblQuery, Button btnQueryReset, TextBox txbxQuery)
        {
            LabelForground(lblQuery, lblUserFgnd, lblPassFgnd);
            QueryTextBoxToggle(lblQuery, txbxQuery, btnQueryReset);
        }

        /// <summary>Sets the enabled state of the query TextBox based on the foreground color of the query label.</summary>
        /// <param name="lblQuery">The query label</param>
        /// <param name="txbxQuery">The query TextBox</param>
        private static void QueryTextBoxToggle(Label lblQuery, TextBox txbxQuery, Button btnQueryReset)
        {
            txbxQuery.IsEnabled = lblQuery.Foreground == Brushes.LimeGreen;

            QueryResetToggle(btnQueryReset, lblQuery.Foreground == Brushes.LimeGreen);
        }

        private static void QueryResetToggle(Button btnQueryReset, bool btnIsVisible) =>
            btnQueryReset.Visibility = btnIsVisible
                ? Visibility.Visible
                : Visibility.Collapsed;

        /// <summary>Sets the Avatar System buttons enabled state based on the status condition.</summary>
        /// <param name="lblQuery">The brush used to determine the status condition.</param>
        /// <param name="txbxQueryContent">The text value used to evaluate whether the label and buttons should be updated</param>
        /// <param name="lblAvatarSystem">The label whose foreground color is updated to indicate the current status.</param>
        /// <param name="avatarSystemButtons">An array of system buttons to be enabled or disabled based on the status condition.</param>
        internal static void AvatarSystemsToggle(Brush lblQuery, string txbxQueryContent, Label lblAvatarSystem, Button[] avatarSystemButtons)
        {
            bool buttonsEnabled = !string.IsNullOrWhiteSpace(txbxQueryContent) && lblQuery == Brushes.LimeGreen;

            lblAvatarSystem.Foreground = buttonsEnabled
                ? Brushes.LimeGreen
                : Brushes.White;

            ButtonStatusToggle(avatarSystemButtons, buttonsEnabled);
        }

        /// <summary>Sets the status of the Avatar Systems buttons.</summary>
        /// <param name="avatarSystemButtons">The Avatar Systems buttons.</param>
        /// <param name="btnState">The state of the buttons.</param>
        private static void ButtonStatusToggle(Button[] avatarSystemButtons, bool btnState)
        {
            foreach (var systemButton in avatarSystemButtons)
            {
                systemButton.IsEnabled = btnState;
                systemButton.Background = Brushes.LimeGreen;
            }
        }

        internal static void AvatarSystemChosen(Button[] avatarSystemButtons, Button btnChosenSystem)
        {
            foreach (var systemButton in avatarSystemButtons)
            {
                if (systemButton == btnChosenSystem)
                {
                    systemButton.Background = Brushes.LawnGreen;
                }
                else
                {
                    systemButton.Background = Brushes.LimeGreen;
                }
            }
        }
    }
}