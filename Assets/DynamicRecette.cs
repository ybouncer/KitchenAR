using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using System.IO;


public class DynamicRecette : MonoBehaviour
{


    [SerializeField] private TMP_Text _text;
    private int _step = 0;

    public TextAsset jsonData;
    public RecipeList recipes = new RecipeList();

    
    [System.Serializable]
    public class Recipe {

        public string name;
        public string id;
        public List<string> tag;
        public List<string> ingredient;
        public List<string> ingredientGroup;
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
        _text.text = recipes.recipe[1].step[_step];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextStep(){
        if (_step+1 < recipes.recipe[1].step.Count){

            _step = _step+1;
             _text.text = recipes.recipe[1].step[_step];

            print("next");
        }
        
    }

    public void PreviousStep(){

        if (_step-1  >=0 ){

            _step = _step-1;
            _text.text = recipes.recipe[1].step[_step];

            print("previous");
        }
    }
}

