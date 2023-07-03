# Recipe App

The Recipe App is a console application that allows users to manage recipes, including entering new recipes, displaying all recipes, scaling a recipe, resetting quantities, and clearing all data. The application is written in C#.

## Usage

1. Clone or download the project to your local machine.

2. Open the project in an Integrated Development Environment (IDE) that supports C#, such as Visual Studio.

3. Build the solution to compile the code.

4. Run the application.

5. The application will display a menu with the following options:

    - Enter a new recipe: Allows you to enter details for a new recipe, including ingredients and steps.
    
    - Display all recipes: Shows a list of all recipes stored in the application. You can select a recipe to display its details.
    
    - Scale a recipe: Allows you to scale the quantities of ingredients in a recipe by a given factor.
    
    - Reset quantities: Resets the quantities of ingredients in a recipe to their original values.
    
    - Clear all data: Clears all data entered in the application, including recipes, ingredients, and steps.
    
    - Exit: Exits the application.

6. Follow the prompts and input the requested information to perform the desired actions.

7. Enjoy managing your recipes with the Recipe App!

## Code Structure

The code is structured as follows:

- `Program.cs`: Contains the main entry point of the application and the user interface logic.

- `Recipe.cs`: Defines the `Recipe` class, which represents a recipe. It contains properties for the recipe name, total calories, and quantity. It also includes methods for entering recipe details, displaying a recipe, scaling quantities, resetting quantities, and clearing data.

- `Ingredient.cs`: Defines the `Ingredient` class, which represents an ingredient in a recipe. It contains properties for the ingredient name, quantity, unit of measurement, calories, and food group.

## Contributing

Contributions to the Recipe App are welcome! If you find any issues or have suggestions for improvements, please submit a pull request or open an issue in the project repository.
