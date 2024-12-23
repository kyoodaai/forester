using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class DialogueSystem : MonoBehaviour
{
    [Serializable]
    public struct Dialogue
    {
        public string name;
        public string description;
        public AudioClip audio;
    }
    [SerializeField] private TextMeshProUGUI textofDialogue;
    private FadesScript script = new FadesScript();
    [SerializeField] private AudioSource audioSource;
    private float currentAudio;
    public Dialogue[] dialogues;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
       if (index != dialogues.Length)
        {
            StartCoroutine(FadesManageIn());
            string formattedString = $"<color=green>{dialogues[index].name}</color>:{dialogues[index].description}";
            textofDialogue.text = formattedString;
            playSound(index);
            StartCoroutine(waitAndFade());
            index++;
        }


    }

    IEnumerator FadesManageIn()
    {
        yield return script.FadeCoroutine(0, 1, 0.5f, textofDialogue);
    }

    IEnumerator waitAndFade()
    {
        yield return waitForCurrentAudio();
        yield return FadesManageOut();
        StartDialogue();
    }

    IEnumerator FadesManageOut()
    {
        yield return script.FadeCoroutine(1,0, 0.5f, textofDialogue);
    }

    public void playSound(int index)
    {
        currentAudio = dialogues[index].audio.length;
        audioSource.PlayOneShot(dialogues[index].audio);
    }

    IEnumerator waitForCurrentAudio()
    {
        yield return new WaitForSeconds(currentAudio - 0.5f);
    }
}
