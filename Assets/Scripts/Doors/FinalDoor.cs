using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public GameObject gatep1;
    public GameObject gatep2;
    public int leversPulledNumber;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leversPulledNumber == 3 && open == false)
        {
            gatep1.SetActive(false);
            gatep2.SetActive(false);
            open = true;
        }
    }
}
