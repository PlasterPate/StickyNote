using Microsoft.Win32;
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
using Assignment5;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for RecipeForm.xaml
    /// </summary>
    public partial class RecipeForm : Window
    {
        public Recipe recipeTemp;
        public bool isAdded = false;
        public RecipeForm()
        {
            InitializeComponent();
            ShowItems();
        }

        public void ShowItems()
        {
            IngredientsListBox.Items.Clear();
            if(recipeTemp != null)
                for (int i = 0; i < recipeTemp.Ingredients.Length && recipeTemp.Ingredients[i] != null; i++)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = recipeTemp.Ingredients[i].Name;
                    IngredientsListBox.Items.Add(item);
                }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            IngredientForm frm = new IngredientForm
            {
                ingredientTemp = new Ingredient()
            };
            frm.Title = "ماده ی جدید";
            frm.ShowDialog();
            if (frm.isAdded)
            {
                recipeTemp.AddIngredient(frm.ingredientTemp);
                ShowItems();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            if (TitleTextBox.Text == string.Empty)
                TitleLabel.Foreground = Brushes.Red;
            else
                TitleLabel.Foreground = Brushes.Black;
            if (CuisineTextBox.Text == string.Empty)
                CuisineLabel.Foreground = Brushes.Red;
            else
                CuisineLabel.Foreground = Brushes.Black;
            if (KeywordsTextBox.Text == string.Empty)
                KeywordsLabel.Foreground = Brushes.Red;
            else
                KeywordsLabel.Foreground = Brushes.Black;
            if (InstructionsTextBox.Text == string.Empty)
                InstructionsLabel.Foreground = Brushes.Red;
            else
                InstructionsLabel.Foreground = Brushes.Black;
            if (TitleTextBox.Text == string.Empty || CuisineTextBox.Text == string.Empty 
                || KeywordsTextBox.Text == string.Empty || InstructionsTextBox.Text == string.Empty)
            {
                MessageBox.Show("Fill Empty Fields !");
                Hide();
                ShowDialog();
            }
            else
            {
                try
                {
                    recipeTemp.ServingCount = int.Parse(ServingCountTextBox.Text);
                    ServingCountLabel.Foreground = Brushes.Black;
                    isValid = true;
                }
                catch
                {
                    ServingCountTextBox.Clear();
                    ServingCountLabel.Foreground = Brushes.Red;
                    MessageBox.Show("Enter a valid number !");
                    isValid = false;
                    Hide();
                    ShowDialog();
                }
                if (isValid)
                {
                    recipeTemp.Title = TitleTextBox.Text;
                    recipeTemp.Instructions = InstructionsTextBox.Text;
                    recipeTemp.ServingCount = int.Parse(ServingCountTextBox.Text);
                    recipeTemp.Cuisine = CuisineTextBox.Text;
                    recipeTemp.Keywords = KeywordsTextBox.Text.Split();
                }
            }
            //for (int i = 0; i< recipeTemp.Ingredients.Length; i++)
            //{
            //    if (recipeTemp.Ingredients[i] == null)
            //    {
            //        ingCount = i;
            //        break;
            //    }
            //}
            //Ingredient[] ingredients = new Ingredient[ingCount] ;
            //for (int i = 0; i < ingredients.Length; i++)
            //{
            //    ingredients[i] = recipeTemp.Ingredients[i];
            //}
            //recipeTemp = new Recipe(title, instructions, ingredients, servingCount, cuisine, keywords);
            isAdded = true;
            Close();
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            isAdded = false;
            Close();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            if(IngredientsListBox.SelectedItem != null)
            {
                string name = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
                Ingredient ing = recipeTemp.LookupByName(name);
                MessageBox.Show(ing.ToString());
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsListBox.SelectedItem != null)
            {
                MessageBoxResult deleteConfirm = MessageBox.Show("Are you sure you want to delete this item?","Delete Confirmation", MessageBoxButton.YesNo);
                if (deleteConfirm == MessageBoxResult.Yes)
                {
                    string name = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
                    recipeTemp.RemoveIngredient(name);
                    ShowItems();
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsListBox.SelectedItem != null)
            {
                string name = ((ListBoxItem)IngredientsListBox.SelectedItem).Content.ToString();
                IngredientForm frm = new IngredientForm
                {
                    ingredientTemp = recipeTemp.LookupByName(name)
                };
                frm.Title = frm.ingredientTemp.Name;
                frm.NameTextBox.Text = frm.ingredientTemp.Name;
                frm.QuantityTextBox.Text = frm.ingredientTemp.Quantity.ToString();
                frm.UnitTextBox.Text = frm.ingredientTemp.Unit;
                frm.DescriptionTextBox.Text = frm.ingredientTemp.Description;
                frm.ShowDialog();
            }
        }
    }
}
