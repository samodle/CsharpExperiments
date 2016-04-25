using Xamarin.Forms;
using WebSearch.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(ViewCell), typeof(TransparentViewCellRenderer))]

namespace WebSearch.iOS.Renderers
{
    public class TransparentViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            if (cell != null) 
                cell.BackgroundColor = UIColor.Clear;
            return cell;
        }
    }
}

