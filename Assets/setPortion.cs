using UnityEngine; // Required for MonoBehaviour, Debug.Log, etc.
using Microsoft.MixedReality.Toolkit.Input; // Required for MRTK speech handling
using TMPro; // Required for TextMeshPro

public class SetPortionWithVoice : MonoBehaviour, IMixedRealitySpeechHandler
{
    [Header("References")]
    public TMP_Text portionText; // Reference to the text that displays portion count
    private int currentPortion; // Current portion count
    public UpdateIngredientsForPortions updateIngredientsScript; // Reference to the script that updates the ingredients

    void Start()
    {
        if (portionText != null)
        {
            // Initialize with the current portion count extracted from the text
            if (int.TryParse(portionText.text, out currentPortion))
            {
                Debug.Log("Portion initialized to: " + currentPortion);
            }
            else
            {
                currentPortion = 1; // Default value if not correctly initialized
                Debug.LogError("Invalid portion value found in the text. Defaulting to 1.");
            }
        }
        else
        {
            Debug.LogError("Portion Text GameObject is not assigned.");
        }

        if (updateIngredientsScript == null)
        {
            Debug.LogError("UpdateIngredientsForPortions script reference is missing.");
        }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        string command = eventData.Command.Keyword.ToLower();

        // Check if the command contains the word "portions"
        if (command.Contains("portions"))
        {
            string[] commandParts = command.Split(' '); // Split command into parts
            if (commandParts.Length > 1)
            {
                int setAmount = ConvertWordToNumber(commandParts[0]); // Get the number part
                if (setAmount != -1) // Check that a valid number was recognized
                {
                    SetPortion(setAmount); // Set the portion count to the recognized number
                }
            }
            else
            {
                Debug.Log("Command did not include a valid number.");
            }
        }
        // If the user says something like "how many portions", ignore it or handle differently
        else if (command.Contains("how many portions"))
        {
            Debug.Log("User asked how many portions, but no change will be made.");
        }
    }

    private void SetPortion(int amount)
    {
        if (amount >= 1 && amount <= 16) // Ensure the amount is between 1 and 16
        {
            currentPortion = amount;
            UpdatePortionText();

            // Call UpdateIngredientsForPortions to update ingredient amounts based on new portion value
            updateIngredientsScript.UpdateIngredientTexts();

            Debug.Log("Portion count set to: " + currentPortion);
        }
        else
        {
            Debug.LogError("Invalid portion value. Must be between 1 and 16.");
        }
    }

    // Updates the portion count text
    private void UpdatePortionText()
    {
        if (portionText != null)
        {
            portionText.text = currentPortion.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on Portion Text GameObject.");
        }
    }

    // Helper method to convert number words to their numeric value (if needed)
    private int ConvertWordToNumber(string word)
    {
        switch (word.ToLower())
        {
            case "one": return 1;
            case "two": return 2;
            case "three": return 3;
            case "four": return 4;
            case "five": return 5;
            case "six": return 6;
            case "seven": return 7;
            case "eight": return 8;
            case "nine": return 9;
            case "ten": return 10;
            case "eleven": return 11;
            case "twelve": return 12;
            case "thirteen": return 13;
            case "fourteen": return 14;
            case "fifteen": return 15;
            case "sixteen": return 16;
            default:
                // If it's a number, try to parse it directly
                int result;
                if (int.TryParse(word, out result))
                {
                    return result;
                }
                else
                {
                    return -1; // Return -1 if unrecognized
                }
        }
    }
}
