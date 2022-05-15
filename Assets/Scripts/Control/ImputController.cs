using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputController : MonoBehaviour
{
    private void OnGUI()
    {
        Event e = Event.current;

        if (!Options.isPause)
        {
            if(e.button == 0 && e.isMouse)
            {
                EventManager.Shoot();
            }
            if (Event.current.Equals(Event.KeyboardEvent("Space")))
            {
                EventManager.Jump();
            }
            if (Event.current.Equals(CompareTag("ShieldOfFaith")))
            {
                EventManager.ButtonPressed(1);
            }
            if (Event.current.Equals(Event.KeyboardEvent("2")))
            {
                EventManager.ButtonPressed(2);
            }
            if (Event.current.Equals(Event.KeyboardEvent("3")))
            {
                EventManager.ButtonPressed(3);
            }
        }
    }
}
