using UnityEngine;

public class BookPagesFlipInteraction : MonoBehaviour
{
    // Book and page references
    public GameObject page1;  
    public GameObject page2;  
    public GameObject page3;  
    public GameObject page4;  

    public GameObject bookLeft;  
    public GameObject bookRight;

    private Vector3 previousHandPosition;
    private bool isGestureActive = false;

    void Update()
    {
        OVRHand leftHand = GetLeftHand();
        if (leftHand != null)
        {
            bool isTwoFingerGesture = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && 
                                      leftHand.GetFingerIsPinching(OVRHand.HandFinger.Middle) &&
                                      !leftHand.GetFingerIsPinching(OVRHand.HandFinger.Ring) &&
                                      !leftHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky);

            if (isTwoFingerGesture)
            {
                // Use leftHand.transform.position instead of GetPointerPose()
                Vector3 currentHandPosition = leftHand.transform.position;

                if (!isGestureActive)
                {
                    previousHandPosition = currentHandPosition;
                    isGestureActive = true;
                }
                else
                {
                    float swipeDistance = currentHandPosition.x - previousHandPosition.x;

                    // Swipe Right (flip forward)
                    if (swipeDistance > 0.1f) 
                    {
                        FlipToNextPages();
                        isGestureActive = false;
                    }
                    // Swipe Left (flip back)
                    else if (swipeDistance < -0.1f) 
                    {
                        FlipToPreviousPages();
                        isGestureActive = false;
                    }
                }
            }
            else
            {
                // Reset gesture if fingers are not pinched
                isGestureActive = false; 
            }
        }
    }

    // Use FindFirstObjectByType instead of deprecated FindObjectOfType
    OVRHand GetLeftHand()
    {
        // Get the left hand object
        return GameObject.FindFirstObjectByType<OVRHand>();
    }

    // Flip to next pages
    void FlipToNextPages()
    {
        page1.SetActive(false);  
        page2.SetActive(false);  
        page3.SetActive(true);   
        page4.SetActive(true);  
    }

    // Flip to previous pages
    void FlipToPreviousPages()
    {
        page1.SetActive(true);   
        page2.SetActive(true);  
        page3.SetActive(false);  
        page4.SetActive(false);  
    }
}