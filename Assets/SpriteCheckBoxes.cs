using UnityEngine;
using UnityEngine.UI;

public class CustomCheckbox : MonoBehaviour
{
    public Sprite uncheckedSprite; // Sprite for the unchecked state
    public Sprite checkedSprite;   // Sprite for the checked state
    private bool isChecked = false; // Initial state of the checkbox
    public Transform fingertip;    // Transform representing the user's fingertip

    private Image checkboxImage;
    private bool isFingertipInside = false; // Track if the fingertip is currently inside

    private void Start()
    {
        // Get the Image component on this GameObject
        checkboxImage = GetComponent<Image>();

        // Set the initial sprite
        checkboxImage.sprite = uncheckedSprite;

        // Ensure the GameObject has a collider for interactions
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    // Method to toggle the checkbox state
    public void ToggleCheckbox()
    {
        isChecked = !isChecked; // Flip the checkbox state

        // Update the sprite based on the state
        checkboxImage.sprite = isChecked ? checkedSprite : uncheckedSprite;

        // Perform any additional actions for checked/unchecked states
        if (isChecked)
        {
            Debug.Log($"{gameObject.name} is checked!");
        }
        else
        {
            Debug.Log($"{gameObject.name} is unchecked!");
        }
    }

    private void Update()
    {
        CheckForInteraction();
    }

    private void CheckForInteraction()
    {
        if (fingertip == null)
        {
            Debug.LogError("Fingertip transform is not assigned!");
            return;
        }

        // Perform a physics check around the fingertip position
        Collider[] hitColliders = Physics.OverlapSphere(fingertip.position, 0.01f); // Adjust radius as needed
        foreach (Collider hitCollider in hitColliders)
        {
            // Ensure the collider is for this checkbox
            if (hitCollider.gameObject == gameObject)
            {
                if (!isFingertipInside) // Check if the fingertip just entered
                {
                    ToggleCheckbox(); // Only toggle once per interaction
                    isFingertipInside = true; // Mark the fingertip as inside
                }
                return; // Exit early to avoid multiple toggles
            }
        }

        // Reset when the fingertip leaves
        if (isFingertipInside)
        {
            isFingertipInside = false;
        }
    }
}