using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTrigger : MonoBehaviour
{
    public Mage mage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeTrigger"))
            mage.playerInRange = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeTrigger"))
            mage.playerInRange = false;
    }
}
