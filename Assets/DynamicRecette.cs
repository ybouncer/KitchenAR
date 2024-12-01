using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using System.IO;


public class DynamicRecette : MonoBehaviour
{

   
    [SerializeField] private TMP_Text _text;
    private int _step = 0;

    public int numero_recette = 0;

    string[] cookingWords = { "riz", "tomate", "olive", "carotte","algue", "ail", "champignon","fromage", "mozzarella","cochon","porc","bacon","oeuf","nouille","narutomaki","bol","boule","huile","poireau","farine","sel","saler","gingembre","basilic","épinard","soja","casserole","four" };
    string[] cookingEmojis = { "<sprite=73>", "<sprite=17>", "<sprite=18>","<sprite=23>","<sprite=27>","<sprite=29>","<sprite=31>", "<sprite=43>","<sprite=43>","<sprite=47>","<sprite=47>","<sprite=47>","<sprite=59>","<sprite=76>","<sprite=81>","<sprite=63>","<sprite=38>","<sprite=33>","<sprite=67>","<sprite=16>","<sprite=50>","<sprite=50>","<sprite=84>","<sprite=101>","<sprite=118>","<sprite=132>","<sprite=133>","<sprite=134>" };

    public TextAsset jsonData;
    public RecipeList recipes = new RecipeList();

    [System.Serializable]
    public class Recipe {

        public string name;
        public string yield;
        public string prepTime;
        public string cookTime;
        public List<string> ingredients;
        public List<string> step;

    }


    [System.Serializable]
    public class RecipeList {
       public Recipe[] recipe;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        recipes =  JsonUtility.FromJson<RecipeList>(jsonData.text);
        _text.text = emojify(recipes.recipe[numero_recette].step[_step]);
        _text.color = new Color(0f,0f,0f,0.9f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextStep(){
        if (_step+1 < recipes.recipe[numero_recette].step.Count){

            _step = _step+1;
            _text.text = emojify(recipes.recipe[numero_recette].step[_step]);

        }
        
    }

    public void PreviousStep(){

        if (_step-1  >=0 ){

            _step = _step-1;
            _text.text = emojify(recipes.recipe[numero_recette].step[_step]);

        }
    }


    public string emojify(string text){
        string outputText = "";
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {

            string prefix = "";

            if(words[i].IndexOf("'")!=-1){
                     
                string test = words[i].Substring(words[i].IndexOf("'")+1, words[i].Length-1 -words[i].IndexOf("'"));
                words[i]=test;
                prefix = words[i].Substring(0, words[i].IndexOf("'")+1);
                    
            }
            bool found = false;
            for (int j = 0; j < cookingWords.Length; j++)
            {
                

                int maxAllowedDistance = Math.Max(1, (int)(0.2 * cookingWords[j].Length)); 

                if ((words[i].ToLower() == cookingWords[j]) || GetLevenshteinDistance(words[i].ToLower(), cookingWords[j]) <= maxAllowedDistance )
                {
                    outputText += prefix + words[i] + cookingEmojis[j] + " ";
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                outputText += words[i] + " ";
            }
        }

        return outputText;


    }

    // Function to calculate Levenshtein Distance
    public int GetLevenshteinDistance(string a, string b)
    {
        if (string.IsNullOrEmpty(a)) return b.Length;
        if (string.IsNullOrEmpty(b)) return a.Length;

        int[,] dp = new int[a.Length + 1, b.Length + 1];

        for (int i = 0; i <= a.Length; i++)
            dp[i, 0] = i;

        for (int j = 0; j <= b.Length; j++)
            dp[0, j] = j;

        for (int i = 1; i <= a.Length; i++)
        {
            for (int j = 1; j <= b.Length; j++)
            {
                int cost = a[i - 1] == b[j - 1] ? 0 : 1;

                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );
            }
        }

        return dp[a.Length, b.Length];
    }
}


