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
    /// Interaction logic for IngredientForm.xaml
    /// </summary>
    public partial class IngredientForm : Window
    {
        public Ingredient ingredientTemp;
        public bool isAdded = false;
        public IngredientForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when add button is clicked
        /// add ingredient to recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            if (NameTextBox.Text == string.Empty)
                NameLabel.Foreground = Brushes.Red;
            else
                NameLabel.Foreground = Brushes.Black;
            if (DescriptionTextBox.Text == string.Empty)
                DescriptionLabel.Foreground = Brushes.Red;
            else
                DescriptionLabel.Foreground = Brushes.Black;
            if (UnitTextBox.Text == string.Empty)
                UnitLabel.Foreground = Brushes.Red;
            else
                UnitLabel.Foreground = Brushes.Black;
            if (NameTextBox.Text == string.Empty || DescriptionTextBox.Text == string.Empty || UnitTextBox.Text == string.Empty)
            {
                MessageBox.Show("Fill Empty Fields !");
                Hide();
                ShowDialog();
            }
            else
            {
                try
                {
                    ingredientTemp.Quantity = double.Parse(QuantityTextBox.Text);
                    QuantityLabel.Foreground = Brushes.Black;
                    isValid = true;
                }
                catch
                {
                    QuantityTextBox.Clear();
                    QuantityLabel.Foreground = Brushes.Red;
                    MessageBox.Show("Enter a valid number !");
                    isValid = false;
                    Hide();
                    ShowDialog();
                }
                if (isValid)
                {
                    ingredientTemp.Name = NameTextBox.Text;
                    ingredientTemp.Description = DescriptionTextBox.Text;
                    ingredientTemp.Unit = UnitTextBox.Text;
                    isAdded = true;
                }
            }
            Close();
        }

        /// <summary>
        /// when cancel butoon is clicked
        /// cancel changes and go back to recipe form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            isAdded = false;
            Close();
        }
    }
}
