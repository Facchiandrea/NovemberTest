using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject rogue;
    public GameObject poof;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowCollider"))
        {
            Instantiate(poof, rogue.transform.GetChild(0).transform.position, poof.transform.rotation);
            Invoke("DestroyRogue", 2f);

            rogue.GetComponent<SpriteRenderer>().enabled = false;
            rogue.GetComponent<Rogue>().destroyed = true;

            rogue.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            rogue.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            rogue.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    public void DestroyRogue()
    {
        Destroy(rogue);
    }

}
