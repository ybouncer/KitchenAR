using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;





public class TimerScript : MonoBehaviour
{


    private bool _timerActive = false;
    private float _currentTime;
    [SerializeField] private int _startMinutes;
    [SerializeField] private TMP_Text _text;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = _startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerActive)
        {
            _currentTime = _currentTime - Time.deltaTime;
            
            if(_currentTime  <=0 ){
                _timerActive = false;
                
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.Minutes.ToString() + " : " + time.Seconds.ToString();


        if (_text.text == "0 : 0"){
            _text.color =  new Color(1f,0f,0f,1f);
        }

    }

    public void StartStopTimer(){
        if (_timerActive == false){
            _timerActive = true;
        }else{
            _timerActive = false;
        }
    }


}
