using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    public GameObject player;
    public GameObject GateP1;
    public GameObject GateP2;
    public GameObject Lever1;
    public GameObject Lever2;
    public bool playerInRange;
    public bool open;


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
            StartCoroutine(Open());
        }

        if (open == false)
        {
            if (player.transform.position.y > transform.position.y)
            {
                GateP1.GetComponent<SpriteRenderer>().sortingOrder = 100;

            }
            else
            {
                GateP1.GetComponent<SpriteRenderer>().sortingOrder = 12;

            }

        }

    }

    private IEnumerator Open()
    {
        open = true;
        Lever2.SetActive(true);
        Lever1.SetActive(false);

        yield return new WaitForSeconds(0.2f);
        GateP1.transform.position = GateP2.transform.position;
        GateP2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GateP1.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;

        yield return null;

    }
}
