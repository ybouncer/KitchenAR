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

    string[] cookingWords = { "riz", "tomate", "olive", "carotte","algue", "ail", "champignon","fromage", "mozzarella","cochon","porc","bacon","oeuf","nouille","narutomaki","bol","boule","huile","poireau" };
    string[] cookingEmojis = { "<sprite=69>", "<sprite=16>", "<sprite=17>","<sprite=22>","<sprite=26>","<sprite=28>","<sprite=30>", "<sprite=41>","<sprite=41>","<sprite=45>","<sprite=45>","<sprite=45>","<sprite=56>","<sprite=71>","<sprite=77>","<sprite=60>","<sprite=36>","<sprite=126>","<sprite=\"poireau\" index=0>" };

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
        Debug.Log(recipes.recipe[1].step[_step]);
        _text.text = emojify(recipes.recipe[1].step[_step]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextStep(){
        if (_step+1 < recipes.recipe[1].step.Count){

            _step = _step+1;
             _text.text = emojify(recipes.recipe[1].step[_step]);

        }
        
    }

    public void PreviousStep(){

        if (_step-1  >=0 ){

            _step = _step-1;
            _text.text = emojify(recipes.recipe[1].step[_step]);

        }
    }


    public string emojify(string text){
        string outputText = "";
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {

            if (words[i] == "minutes"){
                print("create timer, value = word[i-1]");
            }

            if (words[i] == "bouillir"){
                print("create alert, icon=pot, value = 100°C");
            }
            if(words[i].Contains("°C")){
                print("create alert, icon=oven, value = words[i]");
            }



            bool found = false;
            for (int j = 0; j < cookingWords.Length; j++)
            {
                if ((words[i].ToLower() == cookingWords[j]) ||(words[i].ToLower() == cookingWords[j]+"s")||(words[i].ToLower() == cookingWords[j]+"x"))
                {
                    outputText += words[i] + cookingEmojis[j] + " ";
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



}

