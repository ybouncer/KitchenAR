using UnityEngine;
using UnityEngine.EventSystems;  // Necessary for detecting UI elements
using UnityEngine.UI;           // Required for working with UI elements

public class SelectRecipe : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public GameObject book; // Reference to the main book object
    public GameObject leftSide; // Reference to the left side of the book
    public GameObject rightSide; // Reference to the right side of the book

    public GameObject page1; // Left page 1 (UI Canvas)
    public GameObject page2; // Left page 2 (UI Canvas)
    public GameObject page3; // Right page 3 (UI Canvas)
    public GameObject page4; // Right page 4 (UI Canvas)

    public GameObject ingredientsPanel; // Reference to the ingredientsPanel

    private GameObject activeLeftPage; // The currently active page on the left side
    private GameObject activeRightPage; // The currently active page on the right side

    private GraphicRaycaster graphicRaycaster; // Reference to the GraphicRaycaster on the UI Canvas
    private PointerEventData pointerEventData; // Used for raycasting to UI elements
    private EventSystem eventSystem; // Event system for UI interactions

    void Start()
    {
        // Initialize the active pages (you can change these based on your needs)
        SetActivePages();
        
        // Set up the graphic raycaster and event system
        graphicRaycaster = GetComponentInChildren<GraphicRaycaster>();
        eventSystem = GetComponentInChildren<EventSystem>();
        pointerEventData = new PointerEventData(eventSystem);
    }

    void Update()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Automatically assign if not set
        }

        // Perform raycast to detect gaze
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        // Set pointer position for raycasting
        pointerEventData.position = new Vector2(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2); // Assuming gaze is in the center of the screen

        // Raycast to detect if we're looking at the UI (pages)
        if (graphicRaycaster != null)
        {
            // Perform the raycast using the GraphicRaycaster and EventSystem
            var results = new System.Collections.Generic.List<RaycastResult>();
            graphicRaycaster.Raycast(pointerEventData, results);

            foreach (var result in results)
            {
                // Check if the raycast hits any active page on the left or right side
                if (result.gameObject == activeLeftPage || result.gameObject == activeRightPage)
                {
                    Debug.Log("Gazing at an active page!");
                    // Perform the action when gazing at an active page
                    book.SetActive(false);
                    ingredientsPanel.SetActive(true);
                    break;
                }
            }
        }
    }

    // Set the active pages based on which pages are currently visible
    void SetActivePages()
    {
        // Example logic to set active pages based on which pages are active in your UI
        // You can update this based on your actual logic to switch pages
        activeLeftPage = page1.activeSelf ? page1 : page2;
        activeRightPage = page3.activeSelf ? page3 : page4;

        Debug.Log($"Active Left Page: {activeLeftPage.name}");
        Debug.Log($"Active Right Page: {activeRightPage.name}");
    }
}