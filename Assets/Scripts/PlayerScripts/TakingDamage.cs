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
    void Start()
    {
        AdjustUI();
    }


    public void TakeDamage()
    {
        if (invulnerable == false)
        {
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
        SceneManager.LoadScene(1);

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
