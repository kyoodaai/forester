using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vosk;

public class VoskInitializator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private VoskSpeechToText voskR;
    // Start is called before the first frame update
    void Start()
    {
        voskR = player.GetComponent<VoskSpeechToText>();
        Initialize();
    }

    IEnumerator Initialize()
    {
        voskR.enabled = true;
        yield return new WaitForSeconds(1f);
        voskR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
