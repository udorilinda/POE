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

namespace final_poe_part
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml

    public partial class MainWindow : Window
    {

        private List<Recipe> recipes = new List<Recipe>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterRecipe_Click(object sender, RoutedEventArgs e)
        {


            RecipeWindow recipeWindow = new RecipeWindow();
            if (recipeWindow.ShowDialog() == true)
            {
                Recipe recipe = recipeWindow.Recipe;
                recipes.Add(recipe);
                MessageBox.Show("Recipe:");
            }
            {
                // Prompt user for the number of ingredients
                int numberOfIngredients = PromptForInt("Enter the number of ingredients:");

                // Prompt user for the recipe name
                string recipeName = PromptForString("Enter the recipe name:");

                // Prompt user for the group number
                int groupNumber = PromptForInt("Enter the group number:");

                // Prompt user for the number of scale
                int numberOfScale = PromptForInt("Enter the number of scale:");

                // Prompt user for the recipe steps
                string recipeSteps = PromptForString("Enter the recipe steps:");

            }
        }

        private int PromptForInt(string message)
        {
            int result = 0;
            string input = Microsoft.VisualBasic.Interaction.InputBox(message, "Enter Number", "0");
            int.TryParse(input, out result);
            return result;
        }

        private string PromptForString(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Enter Text", "");
        }


        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            int numberOfIngredients = int.Parse(txtIngredients.Text);
            string recipeName = txtRecipeName.Text;
            int groupNumber = int.Parse(txtgroupNumber.Text);
            int numberOfScales = int.Parse(txtScales.Text);
            string steps = txtSteps.Text;

            // Process the entered recipe details here and display them in a MessageBox

            MessageBox.Show($"Recipe: {recipeName}group number:{groupNumber}\nNumber of Ingredients: {numberOfIngredients}\nNumber of Scales: {numberOfScales}\nSteps: {steps}");

            RecipeWindow recipeWindow = new RecipeWindow(recipes);
            recipeWindow.ShowDialog();
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {

            // Code for resetting quantities
            Recipe.ResetQuantities();

        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            // Code for clearing data
            Recipe.ClearData();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //code for closing the application
            Close();
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            //initializing the igridient ,foodgroup, max calories the user inputed 
            string ingredient = ingredientTextBox.Text;
            string foodGroup = ((ComboBoxItem)foodGroupComboBox.SelectedItem)?.Content?.ToString();
            double maxCalories;
            double.TryParse(maxCaloriesTextBox.Text, out maxCalories);

            //appying the fiter that the user has entered

            var filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.Equals(ingredient, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))) &&
                (maxCalories <= 0 || r.TotalCalories <= maxCalories)
            ).ToList();

            if (filteredRecipes.Count == 0)
            {
                resultLabel.Content = "No recipes found.";
            }
            else
            {
                resultLabel.Content = $"Found {filteredRecipes.Count} recipes.";
            }
        }
    }

    internal class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double TotalCalories => Ingredients.Sum(i => i.Calories);

        internal static void ClearData()
        {
            throw new NotImplementedException();
        }

        internal static void ResetQuantities()
        {
            throw new NotImplementedException();
        }

        // Other properties and methods

        public override string ToString()
        {
            return Name;
        }
    }

    internal class Ingredient
    {
        //here we are setting and getting the information of the user
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public List<Ingredient> Ingredients { get; private set; }
        public List<Ingredient> OriginalQuantities { get; private set; }
        public double TotalCalories { get; private set; }

        public List<string> Steps { get; private set; }
        // Other properties and methods

        public override string ToString()
        {
            return $"{Quantity} {Unit} {Name}";
        }
    }

    internal class RecipeWindow : Window
    {
        private List<Recipe> recipes;

        public RecipeWindow()
        {
        }

        public RecipeWindow(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        // Code for the RecipeWindow class (UI for entering/displaying a recipe)

        public Recipe Recipe { get; internal set; }
    }
}
