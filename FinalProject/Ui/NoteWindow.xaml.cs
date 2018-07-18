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
using Business;
using Model;

namespace Ui
{
    /// <summary>
    /// Interaction logic for NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public NoteWindow()
        {
            InitializeComponent();
            TitleTextBox.SelectionBrush = Background;
        }

        public NoteViewModel note = new NoteViewModel();
        
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            note.Text = string.Empty;
            note.Text = TextTextBox.Text;
            note.Title = TitleTextBox.Text;
            note.Color = this.Background.ToString();
            DialogResult = true;
            Close();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ColorBtn_Click(object sender, RoutedEventArgs e)
        {
            ColorWindow frm = new ColorWindow();
            frm.Owner = this;
            frm.Top = this.Top;
            frm.Left = this.Left + 6;
            frm.Background = this.Background;
            frm.ShowDialog();
            this.Background = frm.Background;
            TitleTextBox.SelectionBrush = Background;
            TextTextBox.SelectionBrush = frm.topColor;
            TopBarRect.Fill = frm.topColor;
        }
    }
}
