using UnityEngine;
using System.Collections;

public class MicrophoneChecker : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CheckMicrophones());
    }

    private IEnumerator CheckMicrophones()
    {
        string[] microphones = Microphone.devices;

        if (microphones.Length == 0)
        {
            Debug.LogError("Aucun microphone détecté !");
            yield break;
        }

        Debug.Log($"Microphones détectés ({microphones.Length}):");
        foreach (string mic in microphones)
        {
            Debug.Log($"- {mic}");
            yield return StartCoroutine(TestMicrophone(mic));
        }
    }

    private IEnumerator TestMicrophone(string micName)
    {
        int minFreq, maxFreq;
        Microphone.GetDeviceCaps(micName, out minFreq, out maxFreq);

        if (minFreq == 0 && maxFreq == 0)
        {
            maxFreq = 44100; // Par défaut à 44,1 kHz si aucune fréquence n'est spécifiée
        }

        Debug.Log($"Test du microphone '{micName}' avec une plage de fréquences : {minFreq} Hz à {maxFreq} Hz");

        // Lancer l'enregistrement du microphone
        AudioClip testClip = Microphone.Start(micName, false, 1, maxFreq);

        if (testClip == null)
        {
            Debug.LogError($"Impossible de démarrer l'enregistrement avec le microphone : {micName}");
            yield break;
        }

        // Attendre une petite durée pour collecter des données (non bloquant)
        yield return new WaitForSeconds(1f);

        if (Microphone.IsRecording(micName))
        {
            Debug.Log($"Le microphone '{micName}' fonctionne. Données enregistrées avec succès.");
        }
        else
        {
            Debug.LogError($"Le microphone '{micName}' ne fonctionne pas ou n'a pas pu enregistrer.");
        }

        // Arrêter l'enregistrement
        Microphone.End(micName);
    }
}

