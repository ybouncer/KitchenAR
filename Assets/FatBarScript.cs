using UnityEngine;
using UnityEngine.UI;

public class FatBarScript : MonoBehaviour
{
    public Slider fatSlider;

    public void UpdateFatBar(float fatPercentage)
    {
        fatSlider.value = Mathf.Clamp(fatPercentage, 0f, 100f);  
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}