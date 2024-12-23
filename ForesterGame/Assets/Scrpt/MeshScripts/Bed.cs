using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject playerStanding, playerLaying;
    [SerializeField] public Camera cam;
    public static bool interactable;
    public bool laying;
    private void Start()
    {
    }

    void Update()
    {
        if (interactable == true)
        {
            Debug.Log("Hey");
            if (Input.GetKeyDown(KeyCode.E))
            {
                //intText.SetActive(false);
                //standText.SetActive(true);
                playerLaying.SetActive(true);
                laying = true;
                playerStanding.SetActive(false);
                interactable = false;
            }
        }
        if (laying == true)
        {
            //cam.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerLaying.SetActive(false);
                //standText.SetActive(false);
                playerStanding.SetActive(true);
                laying = false;
            }
        }
    }
}
