using System.IO;
using UnityEngine;
using System.Collections;

public class MicrophoneCapture : MonoBehaviour
{
    public string microphoneDeviceName = ""; // Si vide, prend le premier microphone disponible
    public int sampleRate = 16000; // Fréquence d'échantillonnage de 16 kHz
    public int bufferSize = 1024; // Taille du tampon audio
    public float clipDuration = 1f; // Durée de chaque clip audio en secondes
    public AudioClip currentClip; // Le clip audio actuel qui sera transmis au script principal

    private AudioSource audioSource;
    private float[] audioBuffer;
    private bool isRecording = false;
    private int sampleCount;
    private AudioClip micClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioBuffer = new float[bufferSize];

        // Démarre la capture audio en boucle
        StartCoroutine(CaptureAudioRoutine());
    }

    // Coroutine pour capturer de l'audio toutes les 1 ou 2 secondes
    private IEnumerator CaptureAudioRoutine()
    {
        if (microphoneDeviceName == "")
        {
            microphoneDeviceName = Microphone.devices[0]; // Si aucun nom spécifique n'est défini, prend le premier micro disponible
        }

        // Démarre l'enregistrement
        isRecording = true;
        micClip = Microphone.Start(microphoneDeviceName, true, 999, sampleRate);  // Démarre un enregistrement en continu

        // Attendre que l'enregistrement commence
        while (Microphone.GetPosition(microphoneDeviceName) <= 0)
        {
            yield return null;
        }

        int lastSamplePosition = 0;

        while (true)
        {
            // Attendre la durée du clip (1 ou 2 secondes)
            yield return new WaitForSeconds(clipDuration);

            int currentPosition = Microphone.GetPosition(microphoneDeviceName); // Obtenir la position actuelle de l'audio

            // Calculer combien de nouveaux échantillons ont été enregistrés
            int newSamples = currentPosition - lastSamplePosition;

            // Si de nouveaux échantillons ont été capturés, on les récupère
            if (newSamples > 0)
            {
                // Crée un tableau pour stocker les nouveaux échantillons
                float[] newAudioData = new float[newSamples];
                micClip.GetData(newAudioData, lastSamplePosition); // Récupère les nouvelles données audio

                // Crée un nouveau clip audio avec les nouvelles données
                currentClip = AudioClip.Create("MicrophoneClip", newSamples, 1, sampleRate, false);
                currentClip.SetData(newAudioData, 0); // Remplissez le clip avec les nouvelles données

                // Mesurez l'amplitude de l'audio capturé et affichez dans la console
                MeasureAmplitude(newAudioData);

                // Enregistre le clip audio en fichier WAV
                SaveAudioClipAsWav(currentClip, "CapturedAudioClip_" + Time.time.ToString("F2") + ".wav");

                // Envoie le clip audio au script principal
                ProcessAudioClip(currentClip);
            }

            // Met à jour la position de l'échantillon pour la prochaine itération
            lastSamplePosition = currentPosition;
        }
    }

    // Mesure l'amplitude de l'audio et l'affiche dans la console
    private void MeasureAmplitude(float[] audioData)
    {
        float maxAmplitude = 0f;

        // Recherche l'échantillon avec la plus grande amplitude (valeur absolue)
        foreach (float sample in audioData)
        {
            float absSample = Mathf.Abs(sample); // Prend la valeur absolue pour obtenir l'amplitude
            if (absSample > maxAmplitude)
            {
                maxAmplitude = absSample; // Mets à jour l'amplitude maximale
            }
        }

        // Affiche l'amplitude maximale dans la console
        Debug.Log("Amplitude maximale dans ce clip: " + maxAmplitude);
    }

    // Enregistre un clip audio au format WAV
    private void SaveAudioClipAsWav(AudioClip clip, string filePath)
    {
        string path = Path.Combine(Application.persistentDataPath, filePath);
        byte[] wavData = ConvertAudioClipToWav(clip);
        
        // Sauvegarde les données WAV dans un fichier
        File.WriteAllBytes(path, wavData);
        Debug.Log("Fichier WAV enregistré à : " + path);
    }

    // Convertit un AudioClip en tableau d'octets WAV
    private byte[] ConvertAudioClipToWav(AudioClip clip)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            BinaryWriter writer = new BinaryWriter(memoryStream);

            // En-tête WAV
            int channels = clip.channels;
            int sampleRate = clip.frequency;
            int sampleCount = clip.samples * channels;
            short bitsPerSample = 16; // 16 bits pour PCM

            // Calcul du nombre de bytes à écrire dans le fichier WAV
            writer.Write(new char[] { 'R', 'I', 'F', 'F' }); // ChunkID
            writer.Write(36 + sampleCount * bitsPerSample / 8); // ChunkSize
            writer.Write(new char[] { 'W', 'A', 'V', 'E' }); // Format
            writer.Write(new char[] { 'f', 'm', 't', ' ' }); // Subchunk1ID
            writer.Write(16); // Subchunk1Size (16 pour PCM)
            writer.Write((short)1); // AudioFormat (1 pour PCM)
            writer.Write((short)channels); // Nombre de canaux
            writer.Write(sampleRate); // SampleRate
            writer.Write(sampleRate * channels * bitsPerSample / 8); // ByteRate
            writer.Write((short)(channels * bitsPerSample / 8)); // BlockAlign
            writer.Write(bitsPerSample); // BitsPerSample
            writer.Write(new char[] { 'd', 'a', 't', 'a' }); // Subchunk2ID
            writer.Write(sampleCount * bitsPerSample / 8); // Subchunk2Size

            // Écrit les données audio sous forme d'échantillons 16-bit PCM
            float[] samples = new float[clip.samples];
            clip.GetData(samples, 0);

            foreach (float sample in samples)
            {
                short pcmSample = (short)(sample * short.MaxValue); // Convertir en PCM 16-bit
                writer.Write(pcmSample);
            }

            writer.Flush();
            return memoryStream.ToArray();
        }
    }

    // Traitement de l'audio capturé
    private void ProcessAudioClip(AudioClip clip)
    {
        if (clip != null)
        {
            // Vous pouvez ici appeler votre fonction de transcription, par exemple :
            // runWhisper.ProcessAudioClip(clip);
            // Ou simplement transmettre à un autre script ou fonction pour le traitement
            Debug.Log("Nouvel audio clip capturé : " + clip.length + " secondes");
        }
    }

    // Assurez-vous d'arrêter l'enregistrement à la destruction
    private void OnDestroy()
    {
        if (isRecording)
        {
            Microphone.End(microphoneDeviceName);
        }
    }
}
