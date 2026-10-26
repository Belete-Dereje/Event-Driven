using System.Collections;
using System.Windows.Forms;

namespace InventoryManagementSystem.Helpers
{
    public class ListViewItemComparer : IComparer
    {
        private readonly int columnIndex;
        private readonly bool ascending;

        public ListViewItemComparer(int columnIndex, bool ascending)
        {
            this.columnIndex = columnIndex;
            this.ascending = ascending;
        }

        public int Compare(object? firstObject, object? secondObject)
        {
            ListViewItem? firstRow = firstObject as ListViewItem;
            ListViewItem? secondRow = secondObject as ListViewItem;

            if (firstRow == null || secondRow == null)
            {
                return 0;
            }

            string firstText = columnIndex < firstRow.SubItems.Count ? firstRow.SubItems[columnIndex].Text : string.Empty;
            string secondText = columnIndex < secondRow.SubItems.Count ? secondRow.SubItems[columnIndex].Text : string.Empty;
            int result;

            if (decimal.TryParse(firstText, out decimal firstNumber) &&
                decimal.TryParse(secondText, out decimal secondNumber))
            {
                result = firstNumber.CompareTo(secondNumber);
            }
            else
            {
                result = string.Compare(firstText, secondText, StringComparison.OrdinalIgnoreCase);
            }

            return ascending ? result : -result;
        }
    }
}
