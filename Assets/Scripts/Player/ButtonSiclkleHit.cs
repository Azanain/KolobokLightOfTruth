using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSiclkleHit : MonoBehaviour, /*IDragHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float checkTimer;
    [SerializeField] private float timerCancel;
    public static bool ButtonIsPressed { get; private set; }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        ButtonIsPressed = true;
        StartCoroutine(TimerCheckButtonMode(ped));
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        ButtonIsPressed = false;
    }

    public virtual void OnDrag(PointerEventData ped, byte mode)
    {
        if (gameObject.CompareTag("ShieldOfFaith"))
        {
            if (mode == 1)
            {
                EventManager.ButtonPressed(1);
            }
            else if (mode == 2)
            { 
                EventManager.ButtonPressed(4);
            }
        }
        else if (gameObject.CompareTag("RayOfHope"))
        {
            if (mode == 1)
            {
                EventManager.Shoot();
                EventManager.ButtonPressed(2);
                Debug.Log("shoot");
            }
            else if (mode == 2)
            {
                EventManager.ButtonPressed(5);
                StartCoroutine(TimerChargeLazer());
                Debug.Log("bigShoot");
            }
        }
        else if (gameObject.CompareTag("WordOfPower"))
        {
            if (mode == 1)
            {
                EventManager.ButtonPressed(3);
            }
            else if (mode == 2)
            {
                EventManager.ButtonPressed(6);
            }
        }
    }
    private IEnumerator TimerChargeLazer()
    {
        float timer = 0;
        while (ButtonIsPressed)
        {
            yield return new WaitForSeconds(0.05f);
            timer += 0.05f;
            EventManager.ChargingLazer(timer);
        }
        if (!ButtonIsPressed)
        {

            EventManager.ChargingLazer(timer);
            StopCoroutine(TimerChargeLazer());
        }
    }

    private IEnumerator TimerCheckButtonMode(PointerEventData ped)
    {
        float timer = 0;
        while (ButtonIsPressed)
        {
            yield return new WaitForSeconds(0.05f);
            timer += 0.05f;
        }
        if (timer <= checkTimer)
        {
            OnDrag(ped, 1);
        }
        else if (timer > checkTimer && timer < timerCancel)
        {
            OnDrag(ped, 2);
        }
        else if (timer >= timerCancel)
        {
            StopCoroutine(TimerCheckButtonMode(ped));
        }
    }
}