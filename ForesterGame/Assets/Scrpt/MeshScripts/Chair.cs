using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactable
{
    public GameObject playerStanding, playerSitting, intText, standText;
    public static bool interactable;
    public bool sitting;
     

    void Update()
    {
        if (interactable == true)
        {
            Debug.Log("Hey");
            if (Input.GetKeyDown(KeyCode.E))
            {
                //intText.SetActive(false);
                //standText.SetActive(true);
                playerSitting.SetActive(true);
                sitting = true;
                playerStanding.SetActive(false);
                interactable = false;
            }
        }
        if (sitting == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerSitting.SetActive(false);
                //standText.SetActive(false);
                playerStanding.SetActive(true);
                sitting = false;
            }
        }
    }
}
