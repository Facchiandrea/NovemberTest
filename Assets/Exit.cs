using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public bool open;
    public bool playerInRange;
    public GameObject winscreen;
    public GameObject player;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && open == false && playerInRange || Input.GetKeyDown(KeyCode.F) && open == false && playerInRange || Input.GetKeyDown(KeyCode.Space) && open == false && playerInRange)
        {
            winscreen.SetActive(true);
            Destroy(player);
        }

    }
}
