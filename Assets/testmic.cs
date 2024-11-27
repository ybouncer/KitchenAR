using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RecordAudio : MonoBehaviour {
    
    private AudioClip recordedClip;
    [SerializeField] AudioSource audioSource;

    public void StartRecording()
    {
        string device = Microphone.devices[0];
        int sampleRate = 44100;
        int lengthSec = 10;

        recordedClip = Microphone.Start(device, false, lengthSec, sampleRate);
        Debug.Log("Recording started");
        StartCoroutine(StopRecordingAfterSeconds(lengthSec));
    }

    private IEnumerator StopRecordingAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        StopRecording();
        Debug.Log("Recording stopped");
    }

    public void StopRecording()
    {
        Microphone.End(null);
        PlayRecording();
    }

    public void PlayRecording()
    {
        if (recordedClip != null)
        {
            audioSource.clip = recordedClip;
            audioSource.Play();
            Debug.Log("Playing recorded audio");
        }
        else
        {
            Debug.LogWarning("No recording found to play!");
        }
    }

    void Start () 
    {
        StartRecording();
    }
}