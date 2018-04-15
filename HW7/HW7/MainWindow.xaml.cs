﻿using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment5;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RecipeBook fromAunt;
        public MainWindow()
        {
            InitializeComponent();
            fromAunt = new RecipeBook("دستور پخت خاله", 20);
            ShowItems();
        }

        /// <summary>
        /// show recipe items in list box
        /// </summary>
        private void ShowItems()
        {
            RecipeListBox.Items.Clear();
            NothingFoundTextBox.Visibility = Visibility.Hidden;
            for (int i = 0; i < fromAunt.RecipeList.Length && fromAunt.RecipeList[i] != null; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = fromAunt.RecipeList[i].Title;
                RecipeListBox.Items.Add(item);
            }
        }

        /// <summary>
        /// showing recipe items in list box
        /// </summary>
        /// <param name="recipeArray">recipe array to be shown</param>
        private void ShowItems(Recipe[] recipeArray)
        {
            RecipeListBox.Items.Clear();
            if (recipeArray != null)
            {
                NothingFoundTextBox.Visibility = Visibility.Hidden;
                for (int i = 0; i < recipeArray.Length && recipeArray[i] != null; i++)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = recipeArray[i].Title;
                    RecipeListBox.Items.Add(item);
                }
            }
            else
            {
                //MessageBox.Show("No Items Match your Search!");
                NothingFoundTextBox.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// when new button is clicked
        /// create a new form to add recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            RecipeForm frm = new RecipeForm
            {
                recipeTemp = new Recipe()
            };
            frm.Title = "دستور پخت جدید";
            frm.ShowDialog();
            if (frm.isAdded)
            {
                fromAunt.Add(frm.recipeTemp);
                ShowItems();
            }
        }

        /// <summary>
        /// when delete button is clicked
        /// delete selected recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if(RecipeListBox.SelectedItem != null)
            {
                MessageBoxResult deleteConfirm = MessageBox.Show("Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (deleteConfirm == MessageBoxResult.Yes)
                {
                    string title = ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
                    fromAunt.Remove(title);
                    ShowItems();
                }
            }
        }

        /// <summary>
        /// when view button is clicked
        /// show specifications of the selected recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string title = ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
                Recipe rec = fromAunt.LookupByTitle(title);
                MessageBox.Show(rec.ToString());
            }
        }

        /// <summary>
        /// when edit button is clicked
        /// opens recipe form window 
        /// and let user to edit specifications of recipe that had added before
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string title = ((ListBoxItem)RecipeListBox.SelectedItem).Content.ToString();
                RecipeForm frm = new RecipeForm
                {
                    recipeTemp = fromAunt.LookupByTitle(title)
                };
                frm.Title = frm.recipeTemp.Title;
                frm.TitleTextBox.Text = frm.recipeTemp.Title;
                frm.InstructionsTextBox.Text = frm.recipeTemp.Instructions;
                frm.ServingCountTextBox.Text = frm.recipeTemp.ServingCount.ToString();
                frm.CuisineTextBox.Text = frm.recipeTemp.Cuisine;
                frm.KeywordsTextBox.Text = string.Join(" ", frm.recipeTemp.Keywords);
                frm.ShowItems();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// when load button is clicked
        /// load a text file including recipes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string loadFileName = null;
            openFileDialog.ShowDialog();
            loadFileName = openFileDialog.FileName;
            fromAunt.Load(loadFileName);
            ShowItems();
        }

        /// <summary>
        /// when save button is clicked
        /// saves current recipes in a text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string saveFileName = null;
            saveFileDialog.ShowDialog();
            saveFileName = saveFileDialog.FileName;
            fromAunt.Save(saveFileName);
            ShowItems();
        }

        /// <summary>
        /// when search button is clicked
        /// find recipes of recipebook by the phrase that user enters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)TitleRadioBtn.IsChecked)
            {
                Recipe rec = fromAunt.LookupByTitle(SearchBox.Text);
                Recipe[] recArr = null;
                if (rec != null)
                {
                    recArr = new Recipe[] { rec };
                }
                ShowItems(recArr);
            }
            if ((bool)KeywordRadioBtn.IsChecked)
            {
                ShowItems(fromAunt.LookupByKeyword(SearchBox.Text));
            }
            if ((bool)CuisineRadioBtn.IsChecked)
            {
                ShowItems(fromAunt.LookupByCuisine(SearchBox.Text));
            }
        }

        private void BtnTitle_Click(object sender, RoutedEventArgs e)
        {
            BtnTitle.Foreground = Brushes.Maroon;
        }

        private void BtnTitle_Release(object sender, RoutedEventArgs e)
        {
            BtnTitle.Foreground = Brushes.Red;
            ShowItems();
        }

        private void BtnTitle_MouseEnter(object sender, RoutedEventArgs e)
        {
            BtnTitle.Foreground = Brushes.Red;
        }

        private void BtnTitle_MouseLeave(object sender, RoutedEventArgs e)
        {
            BtnTitle.Foreground = Brushes.Black;
        }
    }
}
