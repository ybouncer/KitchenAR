using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechText : MonoBehaviour
{

    private Transform _cameraTransform;
    private Vector3 _dirToPlayer = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _dirToPlayer = (this.transform.position - _cameraTransform.position).normalized;
        _dirToPlayer.y = 0; // This ensures rotation only around the Y-axis
        this.transform.rotation = Quaternion.LookRotation(_dirToPlayer);
    }
}
