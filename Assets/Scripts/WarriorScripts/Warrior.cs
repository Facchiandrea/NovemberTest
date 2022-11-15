using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Warrior : MonoBehaviour
{

    float oldPosition;
    SpriteRenderer SR;
    SpriteRenderer SR2;
    SpriteRenderer SR3;
    SpriteRenderer SR4;
    public GameObject player;
    private bool isAttacking;

    private void Awake()
    {
        oldPosition = this.gameObject.transform.position.x;
    }


    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR2 = transform.GetChild(0).GetComponent<SpriteRenderer>();
        SR3 = transform.GetChild(1).GetComponent<SpriteRenderer>();
        SR4 = transform.GetChild(2).GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (GetComponent<AIDestinationSetter>().isActiveAndEnabled)
        {
            if (transform.position.x > oldPosition)
            {
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (transform.position.x < oldPosition)
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);

            }

        }

        if (player.transform.position.y > transform.position.y)
        {
            SR.sortingOrder = 110;
            SR2.sortingOrder = 112;
            SR3.sortingOrder = 109;
            SR4.sortingOrder = 111;

        }
        else
        {
            SR.sortingOrder = 90;
            SR2.sortingOrder = 92;
            SR3.sortingOrder = 89;
            SR4.sortingOrder = 91;

        }
    }

    void Attack()
    {
        if (isAttacking == false)
        {
            StartCoroutine(SpinWeapon(0.3f));
            isAttacking = true;
        }
    }
    IEnumerator SpinWeapon(float duration)
    {
        float startRotation = SR4.transform.eulerAngles.z;
        float endRotation = startRotation - 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            SR4.transform.eulerAngles = new Vector3(SR4.transform.eulerAngles.x, SR4.transform.eulerAngles.y,
            yRotation);
            yield return null;
        }
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowCollider"))
        {
            Attack();
        }
    }

    private void LateUpdate()
    {
        oldPosition = transform.position.x;
    }
}
