using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSiclkleHit : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        if (gameObject.CompareTag("ShieldOfFaith"))
        {
            EventManager.ButtonPressed(1);
        }
        if (gameObject.CompareTag("RayOfHope"))
        {
            EventManager.Shoot();
            EventManager.ButtonPressed(2);
        }
        if (gameObject.CompareTag("WordOfPower"))
        {
            EventManager.ButtonPressed(3);
        }
    }
}