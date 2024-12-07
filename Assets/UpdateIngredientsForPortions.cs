using UnityEngine;
using UnityEngine.UI;

public class UpdateIngredientsForPortions : MonoBehaviour
{
    [Header("Ingredient Text GameObjects")]
    public Text pizzaDoughText;
    public Text tomatoSauceText;
    public Text mozzarellaText;
    public Text basilLeavesText;
    public Text oliveOilText;

    [Header("Portions Text")]
    public Text portionsText; // Text displaying the number of portions (as an integer)

    // Baseline values for the ingredients
    private float pizzaDoughBaseline = 250f; // grams
    private float tomatoSauceBaseline = 120f; // mL
    private float mozzarellaBaseline = 150f; // grams
    private int basilLeavesBaseline = 8; // leaves
    private float oliveOilBaseline = 30f; // mL

    public void UpdateIngredientTexts()
    {
        // Parse the number of portions
        if (!int.TryParse(portionsText.text, out int portions) || portions < 1)
        {
            Debug.LogError("Invalid portions number. Defaulting to 1.");
            portions = 1;
        }

        // Update each ingredient's text
        pizzaDoughText.text = $"Pizza dough\n- {pizzaDoughBaseline * portions}g";
        tomatoSauceText.text = $"Tomato sauce\n- {tomatoSauceBaseline * portions} mL";
        mozzarellaText.text = $"Mozzarella cheese balls\n- {mozzarellaBaseline * portions}g";
        basilLeavesText.text = $"Fresh basil leaves\n- {basilLeavesBaseline * portions} leaves";
        oliveOilText.text = $"Extra-virgin olive oil\n- {oliveOilBaseline * portions} mL";
    }
}
