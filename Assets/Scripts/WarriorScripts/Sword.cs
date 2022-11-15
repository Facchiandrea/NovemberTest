using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowCollider"))
        {
            FindObjectOfType<TakingDamage>().TakeDamage();

        }
    }

}
