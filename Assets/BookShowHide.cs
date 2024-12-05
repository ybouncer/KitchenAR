using UnityEngine;

public class BookShowHide : MonoBehaviour
{
    public GameObject book;
    public GameObject parentbook;
    public GameObject CanvasLeft;
    public GameObject CanvasRight;
    public HingeJoint hinge;

    // Method to hide elements
    public void Hide()
    {
        // Hide all renderers of the child objects
        foreach (Transform child in parentbook.transform)
        {
            Renderer childrend = child.GetComponent<Renderer>();
            if (childrend != null)
            {
                childrend.enabled = false; // Disable renderers to hide
            }
        }

        // Hide Canvas elements
        CanvasLeft.SetActive(false);
        CanvasRight.SetActive(false);

        // Optionally, disable the hinge motor if needed
        if (hinge != null)
        {
            var hingeComponent = book.GetComponent<HingeJoint>();
            if (hingeComponent != null)
            {
                hingeComponent.useMotor = false;
            }
        }
    }

    // Method to show elements
    public void Show()
    {
        // Show all renderers of the child objects
        foreach (Transform child in parentbook.transform)
        {
            Renderer childrend = child.GetComponent<Renderer>();
            if (childrend != null)
            {
                childrend.enabled = true; // Enable renderers to show
            }
        }

        // Show Canvas elements
        CanvasLeft.SetActive(true);
        CanvasRight.SetActive(true);

        // Optionally, enable the hinge motor if needed
        if (hinge != null)
        {
            var hingeComponent = book.GetComponent<HingeJoint>();
            if (hingeComponent != null)
            {
                hingeComponent.useMotor = true;
            }
        }
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
