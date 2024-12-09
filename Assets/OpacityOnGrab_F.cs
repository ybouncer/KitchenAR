using UnityEngine;
using Oculus.Interaction;

public class OpacityOnGrab_F : MonoBehaviour
{
    // Référence au composant Grabbable
    private Grabbable grabbable; 
    // Référence au SpriteRenderer
    private SpriteRenderer spriteRenderer; 
    
    void Start()
    {
        // Récupérer le composant Grabbable sur cet objet
        grabbable = GetComponent<Grabbable>();

        // Récupérer le SpriteRenderer sur le parent
        spriteRenderer = GetComponentInParent<SpriteRenderer>();

    }

    void Update()
    {
        // Vérifier si les composants sont valides avant d'appliquer les changements
        if (grabbable)
        {
            // Réduire l'opacité à 65%
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.65f);        
        }
        else
        {
            // Restaurer l'opacité à 100%
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);        
        }
    }
}