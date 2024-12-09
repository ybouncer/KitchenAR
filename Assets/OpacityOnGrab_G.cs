using UnityEngine;
using Oculus.Interaction;

public class OpacityOnGrab_G : MonoBehaviour
{

    private Grabbable grabbable; // Référence au composant Grabbable
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer
    private Color originalColor; // Sauvegarde la couleur d'origine

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Récupérer le composant Grabbable
        grabbable = GetComponent<Grabbable>();
        // Récupérer le SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifier si l'objet est attrapé par Grabbable
        if (grabbable)
        {
            SetOpacity(0.65f); // Réduire l'opacité à 65%
        }
        else
        {
            SetOpacity(1f); // Restaurer l'opacité à 100%
        }
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
