using TMPro;
using UnityEngine;

public class SetPortion7 : MonoBehaviour
{
    [Header("References")]
    public TMP_Text portionText; // Reference to the text that displays portion count
    private int currentPortion = 7; // Current portion count
    public UpdateIngredientsForPortions updateIngredientsScript; // Reference to the script that updates the ingredients

    void Start()
    {
        if (portionText == null)
        {
            Debug.LogError("Portion Text GameObject is not assigned.");
        }

        if (updateIngredientsScript == null)
        {
            Debug.LogError("UpdateIngredientsForPortions script reference is missing.");
        }
    }

    // Function to update the portion count text
    public void UpdatePortion()
    {
        if (portionText != null)
        {
            portionText.text = currentPortion.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on Portion Text GameObject.");
        }
        
        // Call UpdateIngredientsForPortions to update ingredient amounts based on new portion value
        if (updateIngredientsScript != null)
        {
            updateIngredientsScript.UpdateIngredientTexts();
        }
        else
        {
            Debug.LogError("UpdateIngredientsForPortions script reference is missing.");
        }
    }
}
