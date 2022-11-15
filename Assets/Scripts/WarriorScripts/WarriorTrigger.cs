using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WarriorTrigger : MonoBehaviour
{
    public GameObject warrior;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeTrigger"))
        {
            warrior.GetComponent<AIDestinationSetter>().enabled = true;
            warrior.GetComponent<Animator>().SetBool("isMoving", true);
            warrior.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeTrigger"))
        {
            warrior.GetComponent<AIDestinationSetter>().enabled = false;
            warrior.GetComponent<Animator>().SetBool("isMoving", false);
            warrior.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        }
    }

}
