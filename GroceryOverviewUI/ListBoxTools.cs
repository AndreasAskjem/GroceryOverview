using GroceryOverviewLibrary.Models;
using System.Drawing;
using System.Windows.Forms;

namespace GroceryOverviewUI
{
    public static class ListBoxTools
    {
        public static void DrawListBox(DrawItemEventArgs e, ProductModel listBoxItem, Color backgroundColor, Brush textColor)
        {
            e = new DrawItemEventArgs(e.Graphics,
                                      e.Font,
                                      e.Bounds,
                                      e.Index,
                                      e.State ^ DrawItemState.None,
                                      e.ForeColor,
                                      backgroundColor);

            e.DrawBackground();
            e.Graphics.DrawString(listBoxItem.Name,
                                  e.Font,
                                  textColor,
                                  e.Bounds,
                                  StringFormat.GenericDefault);
        }
    }
}
