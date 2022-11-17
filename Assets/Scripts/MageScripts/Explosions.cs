using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public bool active;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeTrigger") && active)
        {
            FindObjectOfType<TakingDamage>().TakeDamage();

        }
    }
    public void ExplosionTriggered()
    {
        Invoke("ActivateExplosion", 1.4f / 1.5f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 1;

    }
    public void ActivateExplosion()
    {
        active = true;
        Invoke("DeactivateExplosion", 0.2f / 1.5f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 1000;


    }
    public void DeactivateExplosion()
    {
        active = false;

    }

}
