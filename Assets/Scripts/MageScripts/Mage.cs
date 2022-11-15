using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject player;
    public GameObject[] explosions;
    public int explosionIndex;
    public float timeBetweenExplosions = 0.5f;


    private void Start()
    {
        StartCoroutine(Explosion());
    }
    private void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    public IEnumerator Explosion()
    {
        foreach (GameObject explosion in explosions)
        {
            float randomNumber = Random.Range(0, 10);
            if (randomNumber < 6)
            {
                explosion.transform.GetChild(0).gameObject.SetActive(true);
                explosion.GetComponent<Explosions>().ExplosionTriggered();
            }

            explosionIndex += 1;
        }
        if (explosionIndex == explosions.Length)
        {
            yield return new WaitForSeconds(2.3f / 1.5f);
            foreach (GameObject explosion in explosions)
            {
                explosion.transform.GetChild(0).gameObject.SetActive(false);
            }
            explosionIndex = 0;
        }
        yield return new WaitForSeconds(timeBetweenExplosions);

        yield return Explosion();

    }
}
