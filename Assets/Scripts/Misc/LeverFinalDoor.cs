using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFinalDoor : MonoBehaviour
{
    public GameObject Lever1;
    public GameObject Lever2;
    public bool playerInRange;
    public bool open;
    public GameObject greenButton;
    public FinalDoor finalDoor;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DoorTrigger"))
        {
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DoorTrigger"))
        {
            playerInRange = false;

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && open == false && playerInRange || Input.GetKeyDown(KeyCode.F) && open == false && playerInRange || Input.GetKeyDown(KeyCode.Space) && open == false && playerInRange)
        {
            open = true;
            Lever2.SetActive(true);
            Lever1.SetActive(false);
            greenButton.SetActive(true);
            finalDoor.leversPulledNumber += 1;
        }

    }
}
