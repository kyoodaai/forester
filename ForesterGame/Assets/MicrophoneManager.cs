using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
using Whisper;
using System;
using UnityEngine.XR;

public class MicrophoneManager : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microClip;
    private string microphoneName;
    private byte[] bytes;

    private void Start()
    {
        microphoneName = Microphone.devices[0];
        MicrophoneAudioClip();
    }

    private void Update()
    {
        
    }

    public void MicrophoneAudioClip()
    {
        microClip = Microphone.Start(microphoneName, true, 100, AudioSettings.outputSampleRate);

    }
    public void EndMicrophone()
    {
        Microphone.End(microphoneName);
    }

    public float GetLoud()
    {
        return GetLoudnessFromClip(Microphone.GetPosition(Microphone.devices[0]), microClip);
    }
    public float GetLoudnessFromClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0) { return 0; }
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);
        float total = 0;
        for (int i = 0; i < sampleWindow; i++) {
            total += Math.Abs(waveData[i]);
        }

        return total / sampleWindow;
    }


    public void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * microClip.channels];
        microClip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, microClip.frequency, microClip.channels);
        SendRecording();
    }
    private void SendRecording()
    {
        string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "recording.wav");

        File.WriteAllBytes(documentsPath, bytes);
    }

    public void inFileFunc()
    {
        MicrophoneAudioClip();
        StopRecording();
    }



    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream))
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }

}
