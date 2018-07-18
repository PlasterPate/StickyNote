using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using Business;
using Model;

namespace Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowItems();
        }

        public void ShowItems()
        {
            NotesListBox.Items.Clear();
            for(int i = 0; i < noteLogic.ReadAll().Count(); i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = noteLogic.ReadAll()[i].Title;
                NotesListBox.Items.Add(item);
            }
        }

        private Brush ColorHex(string colorCode)
        {
            BrushConverter bc = new BrushConverter();
            return (Brush)bc.ConvertFrom(colorCode);
        }

        NoteLogic noteLogic = new NoteLogic();

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow frm = new NoteWindow();
            frm.Owner = this;
            int noteIdx = noteLogic.ReadAll().Count();
            for (int i = 1; i <= noteIdx + 1; i++)
            {
                if (noteLogic.noteRepository.Find($"New Note {i}") == null)
                {
                    frm.TitleTextBox.Text = $"New Note {i}";
                    break;
                }
            }
            frm.Background = Background;
            frm.TopBarRect.Fill = TopBarRect.Fill;
            frm.TextTextBox.SelectionBrush = TopBarRect.Fill;
            frm.ShowDialog();
            if ((bool)frm.DialogResult)
                if (noteLogic.noteRepository.Find(frm.note.Title) != null)
                {
                    for (int i = 1; true; i++)
                    {
                        if (noteLogic.noteRepository.Find(frm.note.Title + $"({i})") == null)
                        {
                            frm.note.Title += $"({i})";
                            noteLogic.AddNote(frm.note);
                            break;
                        }
                    }
                }
                else
                {
                    noteLogic.AddNote(frm.note);
                }
            
            ShowItems();
        }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoteWindow frm = new NoteWindow();
            frm.Owner = this;
            try
            {
                string Title = ((ListBoxItem)NotesListBox.SelectedItem).Content.ToString();
                NoteViewModel note = noteLogic.Find(Title);
                frm.TitleTextBox.Text = note.Title;
                frm.TextTextBox.Text = note.Text;
                frm.Background = ColorHex(note.Color);
                frm.TopBarRect.Fill = ColorToDark(note.Color);
                frm.TextTextBox.SelectionBrush = frm.TopBarRect.Fill;
                frm.ShowDialog();
                noteLogic.DeleteNote(Title);
                if ((bool)frm.DialogResult)
                    noteLogic.AddNote(frm.note);
                ShowItems();
            }
            catch { }
        }

        private Brush ColorToDark(string colorCode)
        {
            string darkColorCode = string.Empty;
            switch (colorCode)
            {
                case "#FFFFF2B5":
                    darkColorCode = "#FFFFB901";
                    break;
                case "#FFC7EFC4":
                    darkColorCode = "#FF118905";
                    break;
                case "#FFC4E5FF":
                    darkColorCode = "#ff0179d7";
                    break;
                case "#FFDEC6FB":
                    darkColorCode = "#ff5d249b";
                    break;
                case "#FFFFC3F4":
                    darkColorCode = "#ffd901a9";
                    break;
                case "#FFF9F9F9":
                    darkColorCode = "#ff777777";
                    break;
                default:
                    darkColorCode = "#FFFFB901";
                    break;
            }
            return ColorHex(darkColorCode);
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
            TopBarRect.Fill = frm.topColor;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
