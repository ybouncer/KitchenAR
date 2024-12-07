using UnityEngine;
using UnityEngine.UI;

public class CustomCheckbox : MonoBehaviour
{
    public Sprite uncheckedSprite; // Sprite for the unchecked state
    public Sprite checkedSprite;   // Sprite for the checked state
    private bool isChecked = false; // Initial state of the checkbox

    private Image checkboxImage;

    private void Start()
    {
        // Get the Image component on this GameObject
        checkboxImage = GetComponent<Image>();

        // Set the initial sprite
        checkboxImage.sprite = uncheckedSprite;
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
            Debug.Log("Checkbox is checked!");
        }
        else
        {
            Debug.Log("Checkbox is unchecked!");
        }
    }

    // Method to detect pointer or gaze click
    private void OnMouseDown()
    {
        ToggleCheckbox();
    }
}
