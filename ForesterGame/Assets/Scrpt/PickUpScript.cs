using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    // Reference to the character camera.
    [SerializeField]
    private Camera characterCamera;
    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;
    // Reference to the currently held item.
    private Interactable pickedItem;
    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if player picked some item already
            if (pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
            }
            else
            {

                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                Ray ray = characterCamera.ScreenPointToRay(screenCenter);
                RaycastHit hit;
                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out hit, 5f))
                {
                    // Check if object is pickable
                    var pickable = hit.transform.GetComponent<Interactable>();
                    // If object has PickableItem class
                    if (pickable)
                    {
                        if (pickable.CompareTag("ToPick"))
                        {
                            // Pick it
                            PickItem(pickable);
                        }
                        else if (pickable.CompareTag("ToSit"))
                        {
                            Chair.interactable = true;
                        }
                        else if (pickable.CompareTag("ToLay"))
                        {
                            Debug.Log("Hey");
                            Bed.interactable = true;
                        }
                        
                    }
                    else
                    {
                        Chair.interactable = false;
                        Bed.interactable = false;
                    }
                }
            }
        }

    }
    /// <summary>
    /// Method for picking up item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void PickItem(Interactable item)
    {
        // Assign reference
        pickedItem = item;
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        GameObject item_ = item.gameObject;
        item_.transform.SetParent(slot, true);
        // Reset position and rotation
        item_.transform.localPosition = Vector3.zero;
   
        item_.transform.localEulerAngles = Vector3.zero;
    }
    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(Interactable item)
    {
        // Remove reference
        pickedItem = null;
        // Remove parent
        item.transform.SetParent(null);
        // Enable rigidbody
        item.Rb.isKinematic = false;
        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }

    private void ToSit(Interactable item)
    {
        this.transform.position = item.transform.position;
    }
}
