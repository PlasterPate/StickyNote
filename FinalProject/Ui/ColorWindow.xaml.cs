using System;
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
using System.Windows.Shapes;

namespace Ui
{
    /// <summary>
    /// Interaction logic for ColorWindow.xaml
    /// </summary>
    public partial class ColorWindow : Window
    {
        public ColorWindow()
        {
            InitializeComponent();
        }

        public SolidColorBrush topColor = new SolidColorBrush();

        private Brush ColorHex(string colorCode)
        {
            BrushConverter bc = new BrushConverter();
            return (Brush)bc.ConvertFrom(colorCode);
        }

        // YELLOW

        private void YellowBtn_MouseEnter(object sender, RoutedEventArgs e)
        {
            YellowBtn.Stroke = Brushes.Black;
            YellowBtn.StrokeThickness = 2;

        }

        private void YellowBtn_MouseLeave(object sender, RoutedEventArgs e)
        {
            YellowBtn.Stroke = null;
        }

        private void YellowBtn_MouseUp(object sender, RoutedEventArgs e)
        {
            this.Background = ColorHex("#FFF2B5");
            topColor = (SolidColorBrush)YellowBtn.Fill;
            Close();
        }

        // GREEN

        private void GreenBtn_MouseEnter(object sender, RoutedEventArgs e)
        {
            GreenBtn.Stroke = Brushes.Black;
            GreenBtn.StrokeThickness = 2;
        }

        private void GreenBtn_MouseLeave(object sender, RoutedEventArgs e)
        {
            GreenBtn.Stroke = null;
        }

        private void GreenBtn_MouseUp(object sender, RoutedEventArgs e)
        {
            this.Background = ColorHex("#c7efc4");
            topColor = (SolidColorBrush)GreenBtn.Fill;
            Close();
        }

        // BLUE

        private void BlueBtn_MouseEnter(object sender, RoutedEventArgs e)
        {
            BlueBtn.Stroke = Brushes.Black;
            BlueBtn.StrokeThickness = 2;
        }

        private void BlueBtn_MouseLeave(object sender, RoutedEventArgs e)
        {
            BlueBtn.Stroke = null;
        }

        private void BlueBtn_MouseUp(object sender, RoutedEventArgs e)
        {
            this.Background = ColorHex("#c4e5ff");
            topColor = (SolidColorBrush)BlueBtn.Fill;
            Close();
        }

        // PURPULE

        private void PurpleBtn_MouseEnter(object sender, RoutedEventArgs e)
        {
            PurpleBtn.Stroke = Brushes.Black;
            PurpleBtn.StrokeThickness = 2;
        }

        private void PurpleBtn_MouseLeave(object sender, RoutedEventArgs e)
        {
            PurpleBtn.Stroke = null;
        }

        private void PurpleBtn_MouseUp(object sender, RoutedEventArgs e)
        {
            this.Background = ColorHex("#dec6fb");
            topColor = (SolidColorBrush)PurpleBtn.Fill;
            Close();
        }

        // PINK

        private void PinkBtn_MouseEnter(object sender, RoutedEventArgs e)
        {
            PinkBtn.Stroke = Brushes.Black;
            PinkBtn.StrokeThickness = 2;
        }

        private void PinkBtn_MouseLeave(object sender, RoutedEventArgs e)
        {
            PinkBtn.Stroke = null;
        }

        private void PinkBtn_MouseUp(object sender, RoutedEventArgs e)
        {
            this.Background = ColorHex("#ffc3f4");
            topColor = (SolidColorBrush)PinkBtn.Fill;
            Close();
        }

        // GRAY

        private void GrayBtn_MouseEnter(object sender, RoutedEventArgs e)
        {
            GrayBtn.Stroke = Brushes.Black;
            GrayBtn.StrokeThickness = 2;
        }

        private void GrayBtn_MouseLeave(object sender, RoutedEventArgs e)
        {
            GrayBtn.Stroke = null;
        }

        private void GrayBtn_MouseUp(object sender, RoutedEventArgs e)
        {
            this.Background = ColorHex("#f9f9f9");
            topColor = (SolidColorBrush)GrayBtn.Fill;
            Close();
        }
    }
}
