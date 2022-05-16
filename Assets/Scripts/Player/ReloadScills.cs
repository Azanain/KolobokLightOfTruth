using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScills : MonoBehaviour
{
    private Image ImageWeapon1_1;
    private Image ImageWeapon1_2;
    private Image ImageWeapon1_3;

    private PlayerShoot playerShoot;
    private Explosion explosion;
    private void Awake()
    {
        EventManager.ButtonEvent += StartTimerReloadawapon1;
        playerShoot = GetComponent<PlayerShoot>();
        explosion = GetComponent<Explosion>();
        ImageWeapon1_1 = GameObject.FindGameObjectWithTag("ShieldOfFaith").GetComponent<Image>();
        ImageWeapon1_2 = GameObject.FindGameObjectWithTag("RayOfHope").GetComponent<Image>();
        ImageWeapon1_3 = GameObject.FindGameObjectWithTag("WordOfPower").GetComponent<Image>();

        ImageWeapon1_1.fillAmount = 1;
        ImageWeapon1_2.fillAmount = 1;
        ImageWeapon1_3.fillAmount = 1;
    }
    private void StartTimerReloadawapon1(byte button)
    {
        switch (button)
        {
            case 1:
                StartCoroutine((TimerUpdateImageWeapon1(PlayerParametrs.TimeReloadWeapon1)));
                StartCoroutine(TimerActivationShield());
                break;
            case 3:
                EventManager.Jump();
                StartCoroutine((TimerUpdateImageWeapon3(PlayerParametrs.TimeReloadWeapon3)));
                StartCoroutine(TimerActivationWord());
                break;
        }
    }
    //1 скил осн режим
    private IEnumerator TimerUpdateImageWeapon1(float timer)
    {
        float maxTimer = timer;
        while (timer > 0)
        {
            ImageWeapon1_1.fillAmount = timer / maxTimer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            ImageWeapon1_1.fillAmount = 1;
            StartCoroutine(TimerEndActivationShield());
            StopCoroutine(TimerUpdateImageWeapon1(0));
        }
    }
    private  IEnumerator TimerActivationShield()
    {
        float scale = 0;
        while (scale < 1.3)
        {
            playerShoot.weapons[0].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale += 0.1f;
        }
        if (scale >= 1)
        {
            playerShoot.SwitchIsChieldActiv(true);
            StopCoroutine(TimerActivationShield());
        }
    }
    private IEnumerator TimerEndActivationShield()
    {
        float scale = 1.3f;
        while (scale > 0.9f)
        {
            playerShoot.weapons[0].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale -= 0.1f;
        }
        if (scale <= 0.9f)
        {
            playerShoot.SwitchIsChieldActiv(false);
            playerShoot.weapons[0].SetActive(false);
            StopCoroutine(TimerEndActivationShield());
        }
    }
    //3 скил осн режим
    private IEnumerator TimerUpdateImageWeapon3(float timer)
    {
        float maxTimer = timer;
        while (timer > 0)
        {
            ImageWeapon1_3.fillAmount = timer / maxTimer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            ImageWeapon1_3.fillAmount = 1;
            StartCoroutine(TimerEndActivationWord());
            StopCoroutine(TimerUpdateImageWeapon3(0));
        }
    }
    private IEnumerator TimerActivationWord()
    {
        float scale = 0;
        while (scale < 5)
        {
            playerShoot.weapons[2].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale += 2f;
        }
        if (scale >= 5)
        {
            StartCoroutine(TimerEndActivationWord());
            StopCoroutine(TimerActivationWord());
        }
    }
    private IEnumerator TimerEndActivationWord()
    {
        float scale = 5;
        while (scale > 0.9f)
        {
            playerShoot.weapons[2].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale -= 2f;
        }
        if (scale <= 0.9f)
        {
            playerShoot.weapons[2].SetActive(false);
            StopCoroutine(TimerEndActivationWord());
        }
    }
}
