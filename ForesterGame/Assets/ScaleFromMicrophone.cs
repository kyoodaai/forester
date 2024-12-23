using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public MicrophoneManager microphoneManager;
    [SerializeField] private TextMeshProUGUI _text;
    public static bool recording = false;

    public float sensibility = 100f;
    public float threshold = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (recording)
        {
            float loudness = microphoneManager.GetLoud() * sensibility;
            if (loudness < threshold)
            {

                _text.color = Color.red;
            }
            else
            {
                _text.color = Color.green;
            }
            _text.text = Mathf.Clamp01(loudness).ToString();

            transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
        }
        
    }
}
