// u251208_code
// u251208_documentation

using System.Windows.Controls;
using System.Xml.Linq;

namespace TingenNyqvist.UserInterface;

internal class ControlProperty
{
    /// <summary>Format raw XML.</summary>
    internal static void FormatXML(TextBox txbxQueryResult)
    {
        txbxQueryResult.FontSize = 12;
        txbxQueryResult.Text = XDocument.Parse(txbxQueryResult.Text).ToString();
    }
}