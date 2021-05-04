using System.Windows.Controls;
using System.Windows.Media;

namespace ShopApp.MyView
{
    public partial class UCTop5Charges : UserControl
    {
        public UCTop5Charges()
        {
            InitializeComponent();
            
            /*PointCollection pc = new PointCollection();

            for (int i = 0; i < 100; i++)
            {
                pc.Add(new System.Windows.Point { X = i, Y = i * 2 });
            }

            // in some appropriate datacontext, set some object that contains your points collection for the binding
            Chart.DataContext = new { points = pc };*/
        }
    }
}