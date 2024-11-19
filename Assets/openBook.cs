using UnityEngine;

public class openBook : MonoBehaviour
{
    public GameObject book;
    public HingeJoint hinge;
    public JointMotor motor;
    public bool opened = false;

    void Start()
    {
        var hinge = book.GetComponent<HingeJoint>();
        hinge.useMotor = false;
    }

    public void Opening()
    {
        if (!opened) {
            motor = hinge.motor;
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
            motor.targetVelocity = -150;
            hinge.useMotor = true;
            opened = false;
        }
    }
}
