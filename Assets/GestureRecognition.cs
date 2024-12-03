using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognition : MonoBehaviour
{
    // Références des doigts
    public Transform thumbTip;
    public Transform indexTip;
    public Transform middleTip;
    public Transform ringTip;
    public Transform pinkyTip;

    // Sprite à effacer
    public GameObject[] spritesToCheck;
    // Distance maximale entre pouce et index pour le geste "👌"
    public float detectionThreshold = 0.02f;

    void Update()
    {
        DetectGesture();
    }

    private void DetectGesture()
    {
        // Vérifier la distance entre le bout du pouce et celui de l'index
        float thumbIndexDistance = Vector3.Distance(thumbTip.position, indexTip.position);

        // Si la distance est inférieure au seuil, on considère que le geste "👌" est détecté
        if (thumbIndexDistance <= detectionThreshold)
        {
            Debug.Log("Geste 👌 détecté !");
            HideSpriteAtHorizontalPosition();
        }
    }

    private void HideSpriteAtHorizontalPosition()
    {
        foreach (GameObject sprite in spritesToCheck)
        {
            if (sprite != null)
            {
                // Vérifier si la rotation du sprite est de 90°
                float spriteX = sprite.transform.rotation.x;
                if (spriteX == 90)
                {
                    sprite.SetActive(false);
                }
            }
        }
    }
}