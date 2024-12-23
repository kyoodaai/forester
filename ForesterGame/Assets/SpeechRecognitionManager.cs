using UnityEngine;
using UnityEngine.Windows.Speech;
using HuggingFace.API;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using Whisper;
using HuggingFace.API;
using static UnityEditor.PlayerSettings.Switch;
using System.Linq;
using Vosk;

public class SpeechRecognitionManager : MonoBehaviour
{
    public VoskSpeechToText voskR;

    private void Start()
    {
        voskR.AutoStart = true;
        
    }
    private void Awake()
    {
        voskR.OnTranscriptionResult += OnTranscriptionResult02;
    }
    public void textAsync(AudioClip clip)
    {
    }
    private void OnTranscriptionResult02(string obj)
    {
        // Save to file
        Debug.Log(obj);
        var result = new RecognitionResult(obj);
        foreach (RecognizedPhrase p in result.Phrases)
        {
            Debug.Log(p.Text);
        }
    }
}