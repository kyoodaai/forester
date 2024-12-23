using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControll : MonoBehaviour
{
    [SerializeField] private GameObject loadTrigger1;
    [SerializeField] private GameObject loadTrigger2;

    private void Start()
    {
        loadTrigger1.SetActive(false);
        loadTrigger2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loadTrigger1.SetActive(true);
            loadTrigger2.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
