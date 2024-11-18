using UnityEngine;

public class openBook : MonoBehaviour
{
    public GameObject book;
    public HingeJoint hinge;

    void Start()
    {
        var hinge = book.GetComponent<HingeJoint>();
        hinge.useMotor = false;
    }

    public void Opening()
    {
        hinge.useMotor = true;
    }
}
