using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookBookManager : MonoBehaviour
{
    [System.Serializable]
    public class NutritionFacts
    {
        public string calories;
        public string carbohydrates;
        public string fats;
        public string proteins;
    }

    [System.Serializable]
    public class Recipe
    {
        public string name;
        public string yield;
        public string prepTime;
        public string cookTime;
        public NutritionFacts nutritionFacts;
    }

    [System.Serializable]
    public class RecipeList
    {
        public List<Recipe> recipes;
    }

    public RecipeList recipeList;
    public Text recipeNameText;
    public Text recipeTimeText;
    public Text caloriesText;
    public Text carbsText;
    public Text fatsText;
    public Text proteinsText;

    public Slider proteinSlider;
    public Slider fatSlider;
    public Slider carbsSlider;

    void Start()
    {
        // Simulate loading the JSON data
        LoadRecipes();

        // Example: Let's load the first recipe
        DisplayRecipe(0);
    }

    void LoadRecipes()
    {
        // Simulate loading from a JSON file (in a real case, use JSONUtility or similar)
        string json = System.IO.File.ReadAllText("Recipes.json"); // Path to your JSON file
        recipeList = JsonUtility.FromJson<RecipeList>(json);
    }

    void DisplayRecipe(int index)
    {
        if (index < recipeList.recipes.Count)
        {
            Recipe recipe = recipeList.recipes[index];

            // Set the recipe name and time
            recipeNameText.text = recipe.name;
            recipeTimeText.text = "Total Time: " + GetTotalTime(recipe.prepTime, recipe.cookTime);

            // Set the nutritional values
            caloriesText.text = "Calories: " + recipe.nutritionFacts.calories;
            carbsText.text = "Carbohydrates: " + recipe.nutritionFacts.carbohydrates;
            fatsText.text = "Fats: " + recipe.nutritionFacts.fats;
            proteinsText.text = "Proteins: " + recipe.nutritionFacts.proteins;

            // Update the sliders based on the nutritional facts
            UpdateSlider(proteinSlider, recipe.nutritionFacts.proteins);
            UpdateSlider(fatSlider, recipe.nutritionFacts.fats);
            UpdateSlider(carbsSlider, recipe.nutritionFacts.carbohydrates);
        }
    }

    void UpdateSlider(Slider slider, string value)
    {
        float amount = ParseNutritionValue(value);
        slider.value = amount;
    }

    float ParseNutritionValue(string value)
    {
        // Remove non-numeric characters (like "g" or "kcal") and parse the float
        string numericValue = value.Replace("g", "").Replace("kcal", "").Trim();
        return float.Parse(numericValue) / 100; // Divide by 100 to normalize it as a percentage for the slider
    }

    string GetTotalTime(string prepTime, string cookTime)
    {
        // Get the longer of the prep or cook time
        int prepMinutes = ParseTime(prepTime);
        int cookMinutes = ParseTime(cookTime);
        return Mathf.Max(prepMinutes, cookMinutes).ToString() + " minutes";
    }

    int ParseTime(string time)
    {
        // Extract minutes from time string (assumes format "XX minutes")
        return int.Parse(time.Replace("minutes", "").Trim());
    }
}
