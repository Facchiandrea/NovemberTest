using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public GameObject sprite4;
    public Collider2D attackCollider;
    public int spikeMode;
    public bool trapTriggered;
    public float warningDuration = 2f;
    public float attackDuration = 1f;
    private bool Attacking;

    public float mode1activationDelay;
    public float mode1Delay;

    void Start()
    {
        if (spikeMode == 1)
        {
            Invoke("Warning", mode1activationDelay);
        }
        else if (spikeMode == 2)
        {
            Attacking = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeTrigger") && Attacking)
        {
            FindObjectOfType<TakingDamage>().TakeDamage();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spikeMode == 0 && collision.CompareTag("SpikeTrigger") && trapTriggered == false)
        {
            Warning();
            trapTriggered = true;
        }
    }

    public void Mode1Cycle()
    {
        Invoke("Warning", mode1Delay);
    }

    public void Warning()
    {
        sprite1.SetActive(false);
        sprite2.SetActive(true);
        sprite3.SetActive(false);
        sprite4.SetActive(false);

        Invoke("Attack", warningDuration);
    }
    public void Attack()
    {
        attackCollider.enabled = true;
        Attacking = true;
        sprite1.SetActive(false);
        sprite2.SetActive(false);
        sprite3.SetActive(true);
        sprite4.SetActive(true);

        Invoke("ResetTrap", attackDuration);

    }
    public void ResetTrap()
    {
        attackCollider.enabled = false;
        Attacking = false;
        sprite1.SetActive(true);
        sprite2.SetActive(false);
        sprite3.SetActive(false);
        sprite4.SetActive(false);

        trapTriggered = false;

        if (spikeMode == 1)
        {
            Invoke("Warning", mode1Delay);
        }
    }

}
