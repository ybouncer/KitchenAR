using UnityEngine;

public class ToggleBook : MonoBehaviour
{
    public GameObject book;
    public GameObject parentbook;
    public GameObject CanvasLeft1;
    public GameObject CanvasLeft2;
    public GameObject CanvasRight1;
    public GameObject CanvasRight2;
    public GameObject IngredientsPanel;
    public HingeJoint hinge;
    public BookShowHide bookShowHideScript;
    
    public void Toggle()
    {
        if (hinge != null) {
            var hinge = book.GetComponent<HingeJoint>();
            hinge.useMotor = false;
        }
        
        foreach (Transform child in parentbook.transform) {
            Renderer childrend = child.GetComponent<Renderer>();
            childrend.enabled = true;
        }
        IngredientsPanel.SetActive(false);
        bookShowHideScript.SetIngredientsPanelWasLastActive(false);
        //parentbook.SetActive(true);
        CanvasLeft1.SetActive(true);
        CanvasLeft2.SetActive(false);
        CanvasRight1.SetActive(true);
        CanvasRight2.SetActive(false);
    }
}
