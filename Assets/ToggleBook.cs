using UnityEngine;

public class ToggleBook : MonoBehaviour
{
    public GameObject book;
    public HingeJoint hinge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Toggle()
    {
        if (hinge != null) {
            var hinge = book.GetComponent<HingeJoint>();
            hinge.useMotor = false;
        }

        gameObject.SetActive(!gameObject.activeSelf);
    }
}
