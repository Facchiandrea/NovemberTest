using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    public float fireRate = 1f;
    Transform firePoint;
    public GameObject ammoType;
    public Transform[] waypoints;
    int waypointIndex;
    public float movementSpeed = 4f;
    SpriteRenderer SR;
    public bool destroyed;
    public float oldPosition;

    private void Awake()
    {
        if (waypoints.Length != 0)
        {
            this.gameObject.transform.position = waypoints[waypointIndex].transform.position;

        }
        oldPosition = this.gameObject.transform.position.x;

    }
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        InvokeRepeating("Shoot", 0f, fireRate);
        firePoint = transform.GetChild(0);
        if (waypoints.Length != 0)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }
    }
    private void Update()
    {

        if (transform.position.x > oldPosition)
        {
            SR.flipX = false;
        }
        if (transform.position.x < oldPosition)
        {
            SR.flipX = true;

        }
    }
    public void Shoot()
    {
        if (destroyed == false)
        {

            GameObject.Instantiate(ammoType, firePoint.transform.position, ammoType.transform.rotation);
        }

    }
    public void FixedUpdate()
    {
        if (waypoints.Length != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, movementSpeed * Time.fixedDeltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;

            }
        }
    }

    private void LateUpdate()
    {
        oldPosition = transform.position.x;
    }
}
