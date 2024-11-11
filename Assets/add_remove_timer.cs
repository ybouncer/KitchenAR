using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class add_remove_timer : MonoBehaviour
{
    public GameObject TimerOriginal;
    public GameObject TimerContainer;
    private int CloneNum = 0;
    //public List<GameObject> dynamicObjectList = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameObject TimerClone = Instantiate(TimerOriginal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add_timer(){
        GameObject TimerClone = Instantiate(TimerOriginal, new Vector3(TimerOriginal.transform.position.x,TimerOriginal.transform.position.y-10,TimerOriginal.transform.position.z), TimerOriginal.transform.rotation);
        TimerClone.transform.parent = TimerContainer.transform;
        TimerClone.transform.localScale= new Vector3(1,1,1);

    
        TimerClone.name = "TimerClone" + CloneNum;
        CloneNum = CloneNum+1;
        TimerOriginal = TimerClone;

        //add_to_list(current);
    }

    public void remove_all_timer(){
        List<GameObject> timers = new List<GameObject>();
        foreach (Transform child in TimerContainer.transform) timers.Add(child.gameObject);
        timers.ForEach(child => Destroy(child));
    }

    /*void add_to_list(GameObject current) {
        if(!dynamicObjectList.Contains(current))

            dynamicObjectList.Add(current);
    }*/
    

}
