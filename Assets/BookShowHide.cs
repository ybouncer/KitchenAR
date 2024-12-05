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

    // Method to hide elements
    public void Hide()
    {
        // Hide Canvas elements
        if (CanvasLeft1.activeSelf) {
            CanvasLeft1.SetActive(false);
            var LastCanvasLeft = CanvasLeft1;
        }
        if (CanvasLeft2.activeSelf) {
            CanvasLeft2.SetActive(false);
            var LastCanvasLeft = CanvasLeft2;
        }
        if (CanvasRight1.activeSelf) {
            CanvasRight1.SetActive(false);
            var LastCanvasRight = CanvasRight1;
        }
        if (CanvasRight2.activeSelf) {
            CanvasRight2.SetActive(false);
            var LastCanvasRight = CanvasRight2;
        }
    }
    // Method to show elements
    public void Show()
    {
        // Hide Canvas elements
        if (!CanvasLeft1.activeSelf) {
            CanvasLeft1.SetActive(true);
        }
        if (!CanvasLeft2.activeSelf) {
            CanvasLeft2.SetActive(true);
        }
        if (!CanvasRight1.activeSelf) {
            CanvasRight1.SetActive(true);
        }
        if (!CanvasRight2.activeSelf) {
            CanvasRight2.SetActive(true);
        }
    }
}
