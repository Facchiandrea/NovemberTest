using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TakingDamage : MonoBehaviour
{
    public GameObject fill1;
    public GameObject fill2;
    public GameObject fill3;
    public int HP;
    private bool invulnerable;
    public float invulnerabilityTime = 1f;
    public GameObject deathScreen;
    public GameObject crown;
    public bool godMode;
    void Start()
    {
        AdjustUI();
        godMode = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && godMode == false)
        {
            godMode = true;
            crown.SetActive(true);
            HP = 99999;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && godMode == true)
        {
            godMode = false;
            crown.SetActive(false);
            HP = 3;
            AdjustUI();

        }


    }

    public void TakeDamage()
    {
        if (invulnerable == false)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.FadeIn("Thud");

            }

            HP -= 1;
            AdjustUI();
            invulnerable = true;
            Invoke("RemoveInvulnerability", invulnerabilityTime);
            StopCoroutine(FlashinCoroutine());
            StartCoroutine(FlashinCoroutine());
            if (HP < 1)
            {
                Death();
            }


        }
    }

    private void Death()
    {
        deathScreen.SetActive(true);
        Destroy(this.gameObject);
    }

    public void Healing()
    {
        HP += 1;
        AdjustUI();
    }

    private void RemoveInvulnerability()
    {
        invulnerable = false;


    }
    private IEnumerator FlashinCoroutine()
    {

        SpriteRenderer playerSprite = this.gameObject.GetComponent<SpriteRenderer>();

        Color defaultColor = playerSprite.color;

        playerSprite.color = new Color(1, 0, 0, 1);

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = defaultColor;
    }

    void AdjustUI()
    {
        if (HP == 0)
        {
            fill1.SetActive(false);
            fill1.SetActive(false);
            fill1.SetActive(false);

        }
        else if (HP == 1)
        {
            fill1.SetActive(true);
            fill2.SetActive(false);
            fill3.SetActive(false);

        }
        else if (HP == 2)
        {
            fill1.SetActive(true);
            fill2.SetActive(true);
            fill3.SetActive(false);

        }
        else if (HP == 3)
        {
            fill1.SetActive(true);
            fill2.SetActive(true);
            fill3.SetActive(true);

        }

    }
}
