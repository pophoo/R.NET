using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using RDotNet;
using RDotNet.NativeLibrary;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableDataSource<Point> source = new ObservableDataSource<Point>();
            this.plotter.AddLineGraph(source, Colors.Black, 1.0, "RVector");

            REngine engine = REngine.GetInstance();
            NumericVector sequence = engine.Evaluate("x <- seq(-3, 3, 0.01)").AsNumeric();
            NumericVector dnorm = engine.Evaluate("dnorm(x, 0, 1)").AsNumeric();
            IEnumerable<Point> data = sequence.Zip(dnorm, (x, y) => new Point(x, y));
            source.AppendMany(data);
        }
    }
}
