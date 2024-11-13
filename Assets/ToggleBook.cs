using UnityEngine;

public class ToggleBook : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
