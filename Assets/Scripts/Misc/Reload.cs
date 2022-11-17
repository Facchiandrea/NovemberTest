using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    void Start()
    {
        Invoke("Reloading", 1.5f);
    }

    void Reloading()
    {
        SceneManager.LoadScene(1);

    }
}
