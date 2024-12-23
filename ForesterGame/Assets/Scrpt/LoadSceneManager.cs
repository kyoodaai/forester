using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject triggerController;
    [SerializeField] private GameObject otherTriger;
    private void OnTriggerEnter(Collider other)
    {
        triggerController.SetActive(true);
        if (other.CompareTag("Player"))
        {
            string[] indexes = gameObject.name.Split('_');
            Debug.Log("Проверка 1");
            Scene scene = SceneManager.GetSceneByBuildIndex(int.Parse(indexes[0]));
            Scene sceneToUnload = SceneManager.GetSceneByBuildIndex(int.Parse(indexes[1]));
            
            if (sceneToUnload.isLoaded)
            {
                SceneManager.UnloadSceneAsync(int.Parse(indexes[1]));
            }
            
            if (!scene.isLoaded)
            {
                Debug.Log("Проверка 3");
                StartCoroutine(LoadScenes(int.Parse(indexes[0])));
            }
            gameObject.SetActive(false);
            otherTriger.SetActive(false);
        }
    }

    IEnumerator LoadScenes(int i)
    {
        Debug.Log("Проверка 2");
        AsyncOperation async = Application.LoadLevelAdditiveAsync(i);
        yield return async;
    }
}