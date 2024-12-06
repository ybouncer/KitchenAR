using UnityEngine;

public class BookShowHide : MonoBehaviour
{
    public GameObject book;
    public GameObject parentbook;
    public GameObject CanvasLeft1;
    public GameObject CanvasLeft2;
    public GameObject CanvasRight1;
    public GameObject CanvasRight2;
    public HingeJoint hinge;
    public int PageActive;

    // Method to hide elements
    public void Hide()
    {

        if (hinge != null) {
            var hinge = book.GetComponent<HingeJoint>();
            hinge.useMotor = false;
        }
        
        foreach (Transform child in parentbook.transform) {
            Renderer childrend = child.GetComponent<Renderer>();
            childrend.enabled = false;
        }    
        // Hide Canvas elements
        if (CanvasLeft1.activeSelf) {
            CanvasLeft1.SetActive(false);
            CanvasRight1.SetActive(false);
            PageActive = 1;
        }
        if (CanvasRight2.activeSelf) {
            CanvasRight2.SetActive(false);
            CanvasLeft2.SetActive(false);
            PageActive = 2;
        }
    }
    // Method to show elements
    public void Show()
    {

        if (hinge != null) {
            var hinge = book.GetComponent<HingeJoint>();
            hinge.useMotor = false;
        }
        
        foreach (Transform child in parentbook.transform) {
            Renderer childrend = child.GetComponent<Renderer>();
            childrend.enabled = true;
        }

        // Show Canvas elements
        if(PageActive == 1) {
            CanvasLeft1.SetActive(true);
            CanvasRight1.SetActive(true);
        } else {
            CanvasLeft2.SetActive(true);
            CanvasRight2.SetActive(true);
        }
    }
}
