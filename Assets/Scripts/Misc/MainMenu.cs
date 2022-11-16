using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.FadeIn("MenuMusic");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.Stop("MenuMusic");
            AudioManager.instance.FadeIn("Thud");

            panel.SetActive(true);
            Invoke("ToGame", 1f);
        }
    }

    public void ToGame()
    {
        SceneManager.LoadScene(1);

    }
}
