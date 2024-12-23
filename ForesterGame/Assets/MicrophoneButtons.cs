using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneButtons : MonoBehaviour
{
    // Start is called before the first frame update
    private static int count = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI textInFile;
    private VoskSpeechToText voskR;
    private bool onClick = false;
    private bool isRecording = true;
    private VoiceProcessor voiceProcessor;
    [SerializeField] private GameObject loudness;
    [SerializeField] private MicrophoneManager microphoneManager;
    void Start()
    {
        voskR = player.GetComponent<VoskSpeechToText>();
        voiceProcessor = player.GetComponent<VoiceProcessor>();
        voskR.enabled = false;
    }

    void Update()
    {
        
    }

    public void OnClickRecording()
    {
        count++;
        voskR.enabled = !voskR.enabled;
        if (count == 1)
        {
            return;
        }
        if (!voskR.enabled)
        {

            voiceProcessor.enabled = false;
            voiceProcessor.StopRecording();
            Debug.Log("VIKL");
            loudness.SetActive(true);
        }
        else
        {

            voiceProcessor.enabled = true;
            voiceProcessor.StartRecording();
            Debug.Log("VKL");      
            loudness.SetActive(false);
        }

        //else
        //{
        //    voiceProcessor.StartRecording();
        //}
    }

    public void OnClickRecordingInFile()
    {
        if (onClick)
        {
            microphoneManager.StopRecording();
            textInFile.text = "Запись в файл";
            onClick = false;
        }
        else {
            Debug.Log("Here");
            microphoneManager.MicrophoneAudioClip();
            textInFile.text = "Recording...";
            onClick = true; 
        }
    }

    public void OnClickLoudness()
    {
        if (isRecording)
        {
            microphoneManager.MicrophoneAudioClip();
            ScaleFromMicrophone.recording = true;
            isRecording = false;
        }
        else
        {
            microphoneManager.EndMicrophone();
            ScaleFromMicrophone.recording = false;
            isRecording = true;
        }
        

    }
}
