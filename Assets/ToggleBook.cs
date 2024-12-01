using UnityEngine;

public class ToggleBook : MonoBehaviour
{
    public GameObject book;
    public GameObject parentbook;
    public HingeJoint hinge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Toggle()
    {
        if (hinge != null) {
            var hinge = book.GetComponent<HingeJoint>();
            hinge.useMotor = false;
        }
        /*if (gameObject.activeSelf) {
            JointLimits limits = hinge.limits;
            limits.min = -170;
            limits.max = 0;
            hinge.limits = limits;
            hinge.axis = -hinge.axis;
            hinge.useMotor = true;
        }*/
        foreach (Transform child in parentbook.transform) {
            Renderer childrend = child.GetComponent<Renderer>();
            childrend.enabled = !childrend.enabled;
        }
        //hinge.enabled = !hinge.enabled;
        //gameObject.SetActive(!gameObject.activeSelf);
    }
}
