using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandRotationDetector : MonoBehaviour
{
    public OVRHand leftHand; // Reference to the left OVRHand component
    private Quaternion previousRotation; // Stores the previous rotation of the hand
    public GameObject targetObject; // The object you want to check for gaze interaction
    public Camera playerCamera; // The camera used for raycasting (usually the player's main camera)
    public int Debugint;

    void Start()
    {
        if (leftHand == null)
        {
            Debug.LogError("Left hand is not assigned. Please assign an OVRHand component.");
        }

        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned.");
        }

        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Automatically get the main camera if not assigned
        }

        // Initialize with the current rotation
        previousRotation = leftHand.transform.rotation;
    }

    void Update()
    {
        if (leftHand == null || !leftHand.IsTracked || targetObject == null || playerCamera == null)
            return; // Exit if the hand is not tracked or required components are missing

        // Raycast to check if the player is gazing at the target object
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            // If the raycast hits the target object
            if (hit.collider.gameObject == targetObject)
            {
                DetectRotation();
            }
        }
    }

    // Perform the rotation detection
    private void DetectRotation()
    {
        // Get the current rotation of the hand
        Quaternion currentRotation = leftHand.transform.rotation;

        // Calculate the rotation difference
        Quaternion deltaRotation = currentRotation * Quaternion.Inverse(previousRotation);

        // Extract axis-angle from the delta rotation
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);

        if (angle > 22.5f)
        {
            // Calculate the rotation direction
            float rotationDirection = Vector3.Dot(axis, leftHand.transform.up);

            if (rotationDirection > 0.0f)
            {
                Debug.Log("Clockwise rotation detected!");
                if (Debugint > 0)
                    Debugint = Debugint - 1;
            }
            else
            {
                Debug.Log("Counterclockwise rotation detected!");
                Debugint = Debugint + 1;
            }
            Debug.Log(Debugint);
            previousRotation = currentRotation;
        }

        // Update the previous rotation
        //previousRotation = currentRotation;
    }
}
