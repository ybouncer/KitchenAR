using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; // Import TextMeshPro namespace

public class HandRotationDetector : MonoBehaviour
{
    public OVRHand leftHand; // Reference to the left OVRHand component
    private Quaternion previousRotation; // Stores the previous rotation of the hand
    public GameObject targetObject; // The object you want to check for gaze interaction
    public Camera playerCamera; // The camera used for raycasting (usually the player's main camera)
    public GameObject numberPortions; // The GameObject containing the text for the number of portions
    public int Debugint = 1; // Initial portion count (e.g., 1 portion)

    private TextMeshProUGUI portionText; // Reference to the TextMeshPro component

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

        if (numberPortions != null)
        {
            // Get the TextMeshPro component from the numberPortions GameObject
            portionText = numberPortions.GetComponent<TextMeshProUGUI>();

            // Initialize the text with the current portion count
            UpdatePortionText();
        }
        else
        {
            Debug.LogError("NumberPortions GameObject is not assigned.");
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
                if (Debugint > 1) // Prevent portions from going below 1
                {
                    Debugint -= 1;
                    UpdatePortionText();
                }
            }
            else
            {
                Debug.Log("Counterclockwise rotation detected!");
                Debugint += 1;
                UpdatePortionText();
            }

            Debug.Log("Portion count: " + Debugint);

            // Update the previous rotation
            previousRotation = currentRotation;
        }
    }

    // Updates the portion count text
    private void UpdatePortionText()
    {
        if (portionText != null)
        {
            portionText.text = Debugint.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on NumberPortions GameObject.");
        }
    }
}