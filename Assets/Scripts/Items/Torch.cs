using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : MonoBehaviour
{
    private Light2D torchlight;
    float t;
    float length = 1.2f;
    float speedVariation;
    public bool start;

    private void Start()
    {
        torchlight = GetComponent<Light2D>();
        speedVariation = Random.Range(0.5f, 1f);
        Invoke("StartTorch", Random.Range(0f, 1f));
    }
    void StartTorch()
    {
        start = true;
    }
    void Update()
    {
        // torchlight.intensity = Mathf.PingPong(Time.t, 1);
        if (start)
        {
            t = Time.time;
            torchlight.intensity = Mathf.PingPong(t * speedVariation, length - 1) + 0.8f;
        }
    }
}
