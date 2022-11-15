using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue_Arrow : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowCollider"))
        {
            Destroy(this.gameObject);
        }
    }
}
