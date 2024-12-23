using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private AudioClip grassSounds;
    [SerializeField] private AudioClip metalSounds;
    [SerializeField] private AudioClip woodSounds;
    [SerializeField] private AudioClip stoneSounds;
    private Ray ray;
    private RaycastHit hit;
    public AudioSource foot;
    private AudioClip currentSound;
    private bool isMoving = false;

    private void Start()
    {
        if (foot == null)
        {
            Debug.Log("Нет звука");
        }
    }

    private void Update()
    {
        ray = new Ray(this.gameObject.transform.position, Vector3.down);
        bool wasMoving = isMoving;

        isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W);

        if (isMoving)
        {
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.gameObject.layer)
                {
                    case 6:
                        currentSound = grassSounds;
                        break;
                    case 7:
                        currentSound = metalSounds;
                        break;
                    case 8:
                        currentSound = woodSounds;
                        break;
                    case 9:
                        currentSound = stoneSounds;
                        break;
                }

                if (!foot.isPlaying || foot.clip != currentSound)
                {
                    foot.clip = currentSound;
                    foot.Play();
                }
            }
        }
        else
        {
            if (foot.isPlaying)
            {
                foot.Stop();
            }
        }
    }
}