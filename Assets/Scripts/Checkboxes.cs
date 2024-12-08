using UnityEngine;
using UnityEngine.UI;

public class CheckboxToggle : MonoBehaviour
{
    public GameObject ingredientsTablePanel; // Parent panel containing checkboxes
    public Sprite checkedSprite;            // Sprite for checked state
    public Sprite uncheckedSprite;          // Sprite for unchecked state

    public void CheckOne()
    {
        SetCheckboxSprite("Checkbox1", checkedSprite);
    }

    public void CheckTwo()
    {
        SetCheckboxSprite("Checkbox2", checkedSprite);
    }

    public void CheckThree()
    {
        SetCheckboxSprite("Checkbox3", checkedSprite);
    }

    public void CheckFour()
    {
        SetCheckboxSprite("Checkbox4", checkedSprite);
    }

    public void CheckFive()
    {
        SetCheckboxSprite("Checkbox5", checkedSprite);
    }

    public void UncheckOne()
    {
        SetCheckboxSprite("Checkbox1", uncheckedSprite);
    }

    public void UncheckTwo()
    {
        SetCheckboxSprite("Checkbox2", uncheckedSprite);
    }

    public void UncheckThree()
    {
        SetCheckboxSprite("Checkbox3", uncheckedSprite);
    }

    public void UncheckFour()
    {
        SetCheckboxSprite("Checkbox4", uncheckedSprite);
    }

    public void UncheckFive()
    {
        SetCheckboxSprite("Checkbox5", uncheckedSprite);
    }

    public void CheckAll()
    {
        SetAllCheckboxSprites(checkedSprite);
    }

    public void UncheckAll()
    {
        SetAllCheckboxSprites(uncheckedSprite);
    }

    private void SetCheckboxSprite(string checkboxName, Sprite sprite)
    {
        Transform checkbox = ingredientsTablePanel.transform.Find(checkboxName);
        if (checkbox != null)
        {
            Image checkboxImage = checkbox.GetComponent<Image>();
            if (checkboxImage != null)
            {
                checkboxImage.sprite = sprite;
                Debug.Log($"{checkboxName} set to {sprite.name}");
            }
            else
            {
                Debug.LogError($"{checkboxName} does not have an Image component.");
            }
        }
        else
        {
            Debug.LogError($"{checkboxName} not found in ingredientsTablePanel.");
        }
    }

    private void SetAllCheckboxSprites(Sprite sprite)
    {
        foreach (Transform child in ingredientsTablePanel.transform)
        {
            Image checkboxImage = child.GetComponent<Image>();
            if (checkboxImage != null)
            {
                checkboxImage.sprite = sprite;
                Debug.Log($"{child.name} set to {sprite.name}");
            }
        }
    }
}
