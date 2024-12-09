using UnityEngine;

public class BookPagesFlipInteraction : MonoBehaviour
{
    // Book and page references
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject bookLeft;
    public GameObject bookRight;
    public GameObject ingredientsPanel;

    private MeshRenderer leftRenderer;
    private MeshRenderer rightRenderer;

    public void Start()
    {
        // Initialize MeshRenderer references and check for null
        leftRenderer = bookLeft.GetComponent<MeshRenderer>();
        rightRenderer = bookRight.GetComponent<MeshRenderer>();

        if (leftRenderer == null)
        {
            Debug.LogError("MeshRenderer component missing on bookLeft.");
        }

        if (rightRenderer == null)
        {
            Debug.LogError("MeshRenderer component missing on bookRight.");
        }
    }

    // Reusable method to check if flipping is allowed
    private bool CanFlipPages()
    {
        return !ingredientsPanel.activeSelf &&
               leftRenderer != null && leftRenderer.enabled &&
               rightRenderer != null && rightRenderer.enabled;
    }

    // Flip to next pages
    public void FlipToNextPages()
    {
        if (CanFlipPages())
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(true);
            page4.SetActive(true);
        }
    }

    // Flip to previous pages
    public void FlipToPreviousPages()
    {
        if (CanFlipPages())
        {
            page1.SetActive(true);
            page2.SetActive(true);
            page3.SetActive(false);
            page4.SetActive(false);
        }
    }
}
