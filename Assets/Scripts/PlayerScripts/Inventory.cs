using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int keyQuantity;
    public void ObtainKey()
    {
        keyQuantity += 1;
        text.text = keyQuantity.ToString("00");
    }

    public void UseKey()
    {
        keyQuantity -= 1;
        text.text = keyQuantity.ToString("00");
    }
}
