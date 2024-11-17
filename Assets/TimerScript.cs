using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;




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
        print("start1");
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
            _text.color = Color.red;
        }

    }

    public void StartStopTimer(){
        if (_timerActive == false){
            _timerActive = true;
            print("start");
        }else{
            _timerActive = false;
            print("stop");
        }
    }


}
