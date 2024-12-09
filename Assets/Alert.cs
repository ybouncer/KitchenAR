using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using System.IO;


public class Alert : MonoBehaviour
{
    [SerializeField] public TMP_Text _step_text;

    [SerializeField] private TMP_Text _alert_text;

    [SerializeField] private TMP_Text _alert_sprite;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        find_sprite_cooking();
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void find_sprite_cooking(){
        if(_step_text.text.Contains("casserole")){
            _alert_sprite.text = "<sprite=133>";
            find_text_cooking();
        }
        if(_step_text.text.Contains("four")){
            _alert_sprite.text = "<sprite=134>" ;
            find_text_cooking();
        }
        /*if (!_step_text.text.Contains("casserole") && !_step_text.text.Contains("four")){
            _alert_sprite.text = "";
        }*/
    }

     public void find_text_cooking(){
        string[] words = _step_text.text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if(words[i].Contains("°C")){
                _alert_text.text = words[i-1]+" °C";
                break;
            }
            if(words[i] == "bouillir"){
                _alert_text.text = "100 °C";
                break;
            }
           
        }
    }
    
}
