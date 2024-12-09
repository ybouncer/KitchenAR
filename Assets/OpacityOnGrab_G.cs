using UnityEngine;
using Oculus.Interaction;

public class OpacityOnGrab_G : MonoBehaviour
{

    private Grabbable grabbable; // Référence au composant Grabbable
    private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer
    
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
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.65f);        
        }
        else
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);        
        }
    }
}
