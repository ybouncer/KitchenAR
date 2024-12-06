using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class SelectRecipe : MonoBehaviour
{   
    public GameObject parentBook; // Parent Book that contains Left and Right side
    public GameObject ingredientsPanel; // Ingredients panel that shows ingredients and let's decide on the number of portions
    // References to the book sides that contain colliders
    public GameObject bookLeft;  // Page 1 parent object (left page/bottom side)
    public GameObject bookRight;  // Page 2 parent object (right page/top side)

    private IMixedRealityGazeProvider gazeProvider;

    private void Start()
    {
        // Get the GazeProvider using the correct service method in MRTK 3
        gazeProvider = CoreServices.InputSystem?.GazeProvider;
    }

    public void RecipeSelected()
    {
        // Check if the gaze is on page 1 or page 2
        if (IsGazingAtPage(bookLeft))  // Fixed pageLeft -> bookLeft
        {
            // Logic to handle page 1 selection 
            SelectPage1();
        }
        else if (IsGazingAtPage(bookRight))  // Fixed pageRight -> bookRight
        {
            // Logic to handle page 2 selection
            SelectPage2();
        }
    }

    // Check if the gaze is on the provided page's collider
    private bool IsGazingAtPage(GameObject page)
    {
        if (gazeProvider != null && gazeProvider.GazeTarget != null)
        {
            // Ensure the page object has a Collider component
            Collider pageCollider = page.GetComponent<Collider>();
            if (pageCollider != null && gazeProvider.GazeTarget == page)
            {
                return true;
            }
        }
        return false;
    }

    // Logic when the user gazes at and selects page 1
    private void SelectPage1()
    {
        Select();
    }

    // Logic when the user gazes at and selects page 2
    private void SelectPage2()
    {
        Select();
    }

    private void Select()
    {
        parentBook.SetActive(false);  // Deactivates the book
        ingredientsPanel.SetActive(true);  // Activates the ingredients panel
    }
}
