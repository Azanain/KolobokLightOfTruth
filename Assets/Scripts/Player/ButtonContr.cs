using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContr : MonoBehaviour
{
    public void Button()
    {
        if (gameObject.CompareTag("ShieldOfFaith"))
        {
            EventManager.ButtonPressed(1);
        }
    }
}
