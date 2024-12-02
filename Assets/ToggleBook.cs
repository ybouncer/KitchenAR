using UnityEngine;

public class ToggleBook : MonoBehaviour
{
    public GameObject book;
    public GameObject parentbook;
    public GameObject CanvasLeft;
    public GameObject CanvasRight;
    public HingeJoint hinge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Toggle()
    {
        if (hinge != null) {
            var hinge = book.GetComponent<HingeJoint>();
            hinge.useMotor = false;
        }
        /*if (gameObject.activeSelf) {
            JointLimits limits = hinge.limits;
            limits.min = -170;
            limits.max = 0;
            hinge.limits = limits;
            hinge.axis = -hinge.axis;
            hinge.useMotor = true;
        }*/
        
        foreach (Transform child in parentbook.transform) {
            Renderer childrend = child.GetComponent<Renderer>();
            childrend.enabled = !childrend.enabled;
            //DisableRenderers(child.gameObject);
        }
        CanvasLeft.SetActive(!CanvasLeft.activeSelf);
        CanvasRight.SetActive(!CanvasRight.activeSelf);
        

        //hinge.enabled = !hinge.enabled;
        //gameObject.SetActive(!gameObject.activeSelf);
    }

void DisableRenderers(GameObject parentObject)
    {
        // Disable the Renderer component for the current GameObject
        Renderer renderer = parentObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        // Recursively call the function for each child of the current GameObject
        foreach (Transform child in parentObject.transform)
        {
            DisableRenderers(child.gameObject); // Recursion: process each child GameObject
        }
    }

}
