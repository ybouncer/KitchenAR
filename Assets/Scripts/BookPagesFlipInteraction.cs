using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class BookPagesFlipInteraction : MonoBehaviour
{
    // Book and page references
    public GameObject page1;  
    public GameObject page2;  
    public GameObject page3;  
    public GameObject page4;  

    public GameObject bookLeft;  
    public GameObject bookRight;

    // Flip to next pages
    public void FlipToNextPages()
    {
        page1.SetActive(false);  
        page2.SetActive(false);  
        page3.SetActive(true);   
        page4.SetActive(true);  
    }

    // Flip to previous pages
    public void FlipToPreviousPages()
    {
        page1.SetActive(true);   
        page2.SetActive(true);  
        page3.SetActive(false);  
        page4.SetActive(false);  
    }
}