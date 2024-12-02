using UnityEngine;

public class OpacityOnGrab_Style : MonoBehaviour
{
    private OVRGrabbable grabbable; // Référence au composant OVRGrabbable
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer
    private Color originalColor; // Sauvegarde la couleur d'origine
    private int rotation = transform.rotation.x; // Sauvegarde la rotation en x

    void Start()
    {
        // Récupérer le composant OVRGrabbable
        grabbable = GetComponent<OVRGrabbable>();

        // Récupérer le SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Sauvegarder la couleur d'origine
        }
    }

    void Update()
    {
        private int newRotation = 90; 

        // Vérifier si l'objet est attrapé
        if (grabbable.isGrabbed && rotation == 0)
        {
            SetOpacity(0.75f); // Réduire l'opacité à 75%
        }
        else
        {
            SetOpacity(0.5f); // Restaurer l'opacité à 50%
            rotation = newRotation;
        }
    }

    // Fonction pour changer l'opacité
    private void SetOpacity(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color newColor = originalColor;
            newColor.a = alpha; // Modifier l'alpha (transparence)
            spriteRenderer.color = newColor;
        }
    }
}
