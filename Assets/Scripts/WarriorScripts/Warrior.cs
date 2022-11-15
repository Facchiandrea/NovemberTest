using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float movementSpeed = 4f;

    public float oldPosition;

    private void Awake()
    {
        oldPosition = this.gameObject.transform.position.x;
    }
    void Start()
    {
    }
    private void Update()
    {

        if (transform.position.x > oldPosition)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (transform.position.x < oldPosition)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }
    public void FixedUpdate()
    {
    }

    private void LateUpdate()
    {
        oldPosition = transform.position.x;
    }
}
