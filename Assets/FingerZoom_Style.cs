using UnityEngine;

public class FingerZoom_Style : MonoBehaviour
{
    public Transform rightThumb; // Assigné à b_r_thumb0
    public Transform rightIndex; // Assigné à b_r_index1
    public Transform targetObject; // L'objet à zoomer/dézoomer

    [SerializeField] private float initialDistance;
    [SerializeField] private Vector3 initialScale;

    void Start()
    {
        initialDistance = Vector3.Distance(rightThumb.position, rightIndex.position);
        initialScale = targetObject.localScale;
    }

    void Update()
    {
        // Calcul de la distance entre le pouce et l'index
        float currentDistance = Vector3.Distance(rightThumb.position, rightIndex.position);

        // Ratio de zoom basé sur la distance initiale
        float scaleRatio = currentDistance / initialDistance;

        // Appliquer le ratio à la taille de l'objet
        targetObject.localScale = initialScale * scaleRatio;
    }
}