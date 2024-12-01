using UnityEngine;

public class openBook : MonoBehaviour
{
    public GameObject book;
    public HingeJoint hinge;
    public JointMotor motor;
    public bool opened;

    void Start()
    {
        var hinge = book.GetComponent<HingeJoint>();
        hinge.useMotor = false;
    }

    public void Opening()
    {

        if (!opened) {            
            JointLimits limits = hinge.limits;
            limits.min = 0;
            limits.max = 170;
            hinge.limits = limits;
            motor = hinge.motor;
            hinge.axis = -hinge.axis;
            hinge.useMotor = true;
            opened = true;
        }
    }

    public void Closing()
    {
        if (opened) {
            JointLimits limits = hinge.limits;
            limits.min = -170;
            limits.max = 0;
            hinge.limits = limits;
            hinge.axis = -hinge.axis;
            hinge.useMotor = true;
            opened = false;
        }
    }
}
