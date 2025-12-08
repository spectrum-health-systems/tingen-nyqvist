// u251207_code
// u251207_documentation

using System.Windows.Controls;
using System.Windows.Media;

namespace TingenNyqvist.UserInterface
{
    /// <summary> Monitors control changes and triggers state updates.</summary>
    internal class ControlMonitor
    {
        /// <summary>Logic for when either the username or password changes.</summary>
        /// <param name="credentialLabel">The credential label to evaluate.</param>
        /// <param name="credentialTextBox">The text of the TextBox to be evaluated.</param>
        /// <param name="lblQuery">The label control associated with the query input to update.</param>
        /// <param name="lblUser">The label control associated with the Nyqvist user input to update.</param>
        /// <param name="lblPassword">The label control associated with the Nyqvist password input to update.</param>
        /// <param name="txbxQuery">The TextBox control associated with the query input to update.</param>
        internal static void CredentialChanged(Label credentialLabel, TextBox credentialTextBox, Label lblUser, Label lblPassword, Label lblQuery, Button btnQueryReset, TextBox txbxQuery, Label lblAvatarSystems, Button[] btnsAvatarSystems)
        {
            ControlState.LabelForground(credentialLabel, credentialTextBox.Text);
            ControlState.QueryLabel(lblUser.Foreground, lblPassword.Foreground, lblQuery, btnQueryReset, txbxQuery);
            ControlState.AvatarSystemsToggle(lblQuery.Foreground, txbxQuery.Text, lblAvatarSystems, btnsAvatarSystems);
        }

        /// <summary>Logic for when the query text has changed.</summary>
        /// <param name="lblQueryFgnd">The brush used to set the foreground color of the query label.</param>
        /// <param name="txbxQueryContent">The current text content of the query text box. May be used to determine control states.</param>
        /// <param name="lblAvatarSystems">The label control associated with system selection or display.</param>
        /// <param name="btnsAvatarSystems">An array of button controls representing available systems to be updated based on the query text.</param>
        internal static void QueryChanged(Brush lblQueryFgnd, string txbxQueryContent, Button btnQueryReset, Label lblAvatarSystems, Button[] btnsAvatarSystems)
        {
            ControlState.AvatarSystemsToggle(lblQueryFgnd, txbxQueryContent, lblAvatarSystems, btnsAvatarSystems);
        }
    }
}