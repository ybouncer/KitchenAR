using UnityEngine;

public class OpacityOnGrab_Fam : MonoBehaviour
{
    private OVRGrabbable grabbable; // Référence au composant OVRGrabbable
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer
    private Color originalColor; // Sauvegarde la couleur d'origine
    private int rotation; // Sauvegarde la rotation en x
    private int newRotation = 90; // Nouvelle rotation en x

    public Transform rightThumb; // Transform du pouce droit
    public Transform rightIndex; // Transform de l'index droit
    public float grabThreshold = 0.05f; // Distance minimale pour considérer un grab (en mètres)

    private bool isGrabbedByFingers = false; // Indique si l'objet est attrapé via les doigts

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

        // Initialiser la rotation
        rotation = (int)transform.rotation.eulerAngles.x;
    }
void Update()
    {
        // Vérifier si l'objet est attrapé par OVRGrabbable et via les doigts
        if (grabbable.isGrabbed && IsGrabbedByFingers())
        {
            SetOpacity(0.75f); // Réduire l'opacité à 75%
        }
        else
        {
            SetOpacity(0.5f); // Restaurer l'opacité à 50%
            rotation = newRotation;
        }
    }

    // Vérifie si l'objet est attrapé via les doigts (pouce et index)
    bool IsGrabbedByFingers()
    {
        if (rightThumb != null && rightIndex != null)
        {
            float distance = Vector3.Distance(rightThumb.position, rightIndex.position);
            isGrabbedByFingers = distance <= grabThreshold;
            return isGrabbedByFingers;
        }
        return false;
    }

    // Fonction pour changer l'opacité
    void SetOpacity(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color newColor = originalColor;
            newColor.a = alpha; // Modifier l'alpha (transparence)
            spriteRenderer.color = newColor;
        }
    }
}