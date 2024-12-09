using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using System.IO;

public class add_remove_timer : MonoBehaviour
{
    [SerializeField] public TMP_Text _step_text;

    public GameObject TimerOriginal;
    public GameObject TimerContainer;
    private int CloneNum = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimerOriginal.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void add_when_text(){
        string[] words = _step_text.text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if(words[i].Contains("minutes")){
                remove_all_timer();
                add_timer();
                break;
            }
           
        }
    }

    public void add_timer(){
        GameObject TimerClone = Instantiate(TimerOriginal, new Vector3(TimerOriginal.transform.position.x,TimerOriginal.transform.position.y-10,TimerOriginal.transform.position.z), TimerOriginal.transform.rotation);
        TimerClone.transform.parent = TimerContainer.transform;
        TimerClone.transform.localScale= new Vector3(1,1,1);
    
        TimerClone.name = "TimerClone" + CloneNum;
        CloneNum = CloneNum+1;
        TimerOriginal = TimerClone;

    }

    public void remove_all_timer(){
        List<GameObject> timers = new List<GameObject>();
        foreach (Transform child in TimerContainer.transform) timers.Add(child.gameObject);
        TimerOriginal = timers[0];
        timers.RemoveAt(0);
        timers.ForEach(child => Destroy(child));

    }

    

}
