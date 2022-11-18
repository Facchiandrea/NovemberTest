using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Item : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowCollider"))
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.FadeIn("Plin");

            }

            Destroy(this.gameObject);
            FindObjectOfType<Inventory>().ObtainKey();

        }
    }
}
