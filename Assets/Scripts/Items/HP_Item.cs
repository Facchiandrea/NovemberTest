using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Item : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowCollider"))
        {
            if (FindObjectOfType<TakingDamage>().HP < 3)
            {
                Destroy(this.gameObject);
                FindObjectOfType<TakingDamage>().Healing();
            }

        }
    }
}
