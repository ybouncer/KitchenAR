using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SelectRecipe : MonoBehaviour
{
    public Camera playerCamera; // The player's camera
    public GameObject book; // The main book object
    public GameObject ingredientsPanel; // Panel to show when interacting with the book
    public BookShowHide bookShowHideScript; // Script to manage book visibility

    // References for the left and right sides of the book
    public GameObject bookLeft; // Book Left side (parent of Page1 and Page2)
    public GameObject bookRight; // Book Right side (parent of Page3 and Page4)

    private GraphicRaycaster graphicRaycaster; // For detecting UI interactions
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    public GameObject CanvasLeft1;
    public GameObject CanvasLeft2;
    public GameObject CanvasRight1;
    public GameObject CanvasRight2;

    void Start()
    {
        // Use FindFirstObjectByType to avoid deprecated warning
        eventSystem = Object.FindFirstObjectByType<EventSystem>();
        pointerEventData = new PointerEventData(eventSystem);
    }

    public void DetectGazeInteraction()
    {
        // Set the pointer position (assuming gaze is at the center of the screen)
        pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2);

        // Get the list of active pages
        List<GameObject> activePages = GetActivePages();

        // Raycast to all active pages
        foreach (GameObject page in activePages)
        {
            graphicRaycaster = page.GetComponent<GraphicRaycaster>();
            if (graphicRaycaster == null) continue;

            // Perform raycasting using the GraphicRaycaster
            List<RaycastResult> results = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerEventData, results);

            // Process raycast results
            foreach (var result in results)
            {
                if (result.gameObject.transform.parent.gameObject == page)
                {
                    Debug.Log("oui");
                    HandleInteraction();
                    return; // Stop checking other pages once interaction is detected
                }
            }
        }
    }

    // Handle the interaction when gazing at a page
    public void HandleInteraction()
    {
        // Hide the book and show the ingredients panel
        foreach (Transform child in book.transform) {
            Renderer childrend = child.GetComponent<Renderer>();
            childrend.enabled = false;
        }
        CanvasLeft1.SetActive(false);
        CanvasRight1.SetActive(false);
        CanvasLeft2.SetActive(false);
        CanvasRight2.SetActive(false);        
        ingredientsPanel.SetActive(true);
        bookShowHideScript.SetIngredientsPanelWasLastActive(true);

    }

    // Get all the active pages (both on the left and right sides of the book)
    private List<GameObject> GetActivePages()
    {
        List<GameObject> activePages = new List<GameObject>();

        // Check for active pages on the left side
        foreach (Transform page in bookLeft.transform)
        {
            if (page.gameObject.activeSelf) // If the page is active
            {
                activePages.Add(page.gameObject);
            }
        }

        // Check for active pages on the right side
        foreach (Transform page in bookRight.transform)
        {
            if (page.gameObject.activeSelf) // If the page is active
            {
                activePages.Add(page.gameObject);
            }
        }

        return activePages;
    }
}
