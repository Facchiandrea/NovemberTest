using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public GameObject GateP1;
    public GameObject GateP2;
    public GameObject Key;
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
        if (Input.GetKeyDown(KeyCode.E) && FindObjectOfType<Inventory>().keyQuantity > 0 && open == false && playerInRange || Input.GetKeyDown(KeyCode.F) && FindObjectOfType<Inventory>().keyQuantity > 0 && open == false && playerInRange || Input.GetKeyDown(KeyCode.Space) && FindObjectOfType<Inventory>().keyQuantity > 0 && open == false && playerInRange)
        {
            StartCoroutine(Open());
        }
    }

    private IEnumerator Open()
    {
        open = true;
        FindObjectOfType<Inventory>().UseKey();
        Key.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        GateP1.transform.position = GateP2.transform.position;
        GateP2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GateP1.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;

        yield return null;

    }
}
