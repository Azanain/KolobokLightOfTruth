using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScills : MonoBehaviour
{
    private Image ImageWeapon1_1;
    private Image ImageWeapon2_1;
    private Image ImageWeapon3_1;

    private Image ImageWeapon1_2;
    private Image ImageWeapon2_2;
    private Image ImageWeapon3_2;

    private PlayerShoot playerShoot;
    private Explosion explosion;

    private Button buttonsWeapon1;
    private Button buttonsWeapon3;

    private bool weapon1_2Isactive;
    private bool weapon3_2Isactive;
    [SerializeField] private float dashForce;
    private void Awake()
    {
        EventManager.ButtonEvent += StartTimerReloadawapon;
        playerShoot = GetComponent<PlayerShoot>();
        explosion = GetComponent<Explosion>();
        ImageWeapon1_1 = GameObject.FindGameObjectWithTag("ShieldOfFaith").GetComponent<Image>();
        ImageWeapon2_1 = GameObject.FindGameObjectWithTag("RayOfHope").GetComponent<Image>();
        ImageWeapon3_1 = GameObject.FindGameObjectWithTag("WordOfPower").GetComponent<Image>();

        ImageWeapon1_2 = GameObject.FindGameObjectWithTag("ShieldOfFaith_2").GetComponent<Image>();
        ImageWeapon2_2 = GameObject.FindGameObjectWithTag("RayOfHope_2").GetComponent<Image>();
        ImageWeapon3_2 = GameObject.FindGameObjectWithTag("WordOfPower_2").GetComponent<Image>();

        buttonsWeapon1 = GameObject.FindGameObjectWithTag("ShieldOfFaith").GetComponent<Button>();
        buttonsWeapon3 = GameObject.FindGameObjectWithTag("WordOfPower").GetComponent<Button>();
        buttonsWeapon1.interactable = true;
        buttonsWeapon3.interactable = true;
        playerShoot.weapons[0].SetActive(true);

        ImageWeapon1_1.fillAmount = 1;
        ImageWeapon2_1.fillAmount = 1;
        ImageWeapon3_1.fillAmount = 1;
        ImageWeapon2_2.fillAmount = 0;
    }
    private void StartTimerReloadawapon(byte button)
    {
        switch (button)
        {
            case 1:
                if (!PlayerShoot.IsCheldActiv)
                { 
                    StartCoroutine((TimerUpdateImageWeapon1(PlayerParametrs.TimeReloadWeapon1)));
                    EventManager.Dash(dashForce);
                    playerShoot.weapon1_1.SetActive(true);
                    StartCoroutine(TimerActivationShield());
                    playerShoot.SwitchIsChieldActiv(true);
                    buttonsWeapon1.interactable = false;
                }
                break;
            case 3:
                if (!PlayerShoot.IsWordActiv)
                {
                    EventManager.Discarding(3);
                    //EventManager.Jump(1);
                    StartCoroutine((TimerUpdateImageWeapon3(PlayerParametrs.TimeReloadWeapon3)));
                    StartCoroutine(TimerActivationWord(5));
                    playerShoot.SwitchIsWordActiv(true);
                    buttonsWeapon3.interactable = false;
                }
                break;
            case 4:
                if (!weapon1_2Isactive)
                { 
                    weapon1_2Isactive = true;
                    StartCoroutine(TimerUpdateImageWeapon1_2(PlayerParametrs.TimeReloadWeapon1_2));
                    playerShoot.weapons[0].SetActive(true);
                    playerShoot.weapon1_2.SetActive(true);
                    StartCoroutine(TimerActivationShield_2());
                }
                break;
            case 6:
                if (!weapon3_2Isactive)
                {
                    weapon3_2Isactive = true;
                    EventManager.Discarding(8);
                    //EventManager.Jump(2);
                    StartCoroutine((TimerUpdateImageWeapon3(PlayerParametrs.TimeReloadWeapon3)));
                    StartCoroutine(TimerActivationWord(10));
                    playerShoot.SwitchIsWordActiv(true);
                    buttonsWeapon3.interactable = false;
                }
                break;
        }
    }

    //1_1 скил осн режим
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
            buttonsWeapon1.interactable = true;
            playerShoot.SwitchIsChieldActiv(false);
            StartCoroutine(TimerEndActivationShield());
            StopCoroutine(TimerUpdateImageWeapon1(0));
        }
    }
    private  IEnumerator TimerActivationShield()
    {
        float scale = 0f;
        while (scale < 3f)
        {
            playerShoot.weapons[0].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale += 1f;
        }
        if (scale >= 1f)
        {
            playerShoot.SwitchIsChieldActiv(true);
            StopCoroutine(TimerActivationShield());
        }
    }
    private IEnumerator TimerEndActivationShield()
    {
        float scale = 3f;
        while (scale > 0.9f)
        {
            playerShoot.weapons[0].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale -= 1f;
        }
        if (scale <= 0.9f)
        {
            playerShoot.SwitchIsChieldActiv(false);
            playerShoot.weapons[0].SetActive(false);
            playerShoot.weapon1_1.SetActive(false);
            StopCoroutine(TimerEndActivationShield());
        }
    }
    //3_1 скил осн режим
    private IEnumerator TimerUpdateImageWeapon3(float timer)
    {
        float maxTimer = timer;
        while (timer > 0)
        {
            ImageWeapon3_1.fillAmount = timer / maxTimer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            ImageWeapon3_1.fillAmount = 1;
            playerShoot.SwitchIsWordActiv(false);
            buttonsWeapon3.interactable = true;
            StartCoroutine(TimerEndActivationWord());
            StopCoroutine(TimerUpdateImageWeapon3(0));
        }
    }
    private IEnumerator TimerActivationWord(int damage)
    {
        float scale = 0;
        while (scale < 5)
        {
            playerShoot.weapons[2].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            explosion.Explode(scale);
            scale += 2f;
        }
        if (scale >= 5)
        {
            //нанесение урона 
            EventManager.Discarding(3);
            StartCoroutine(TimerEndActivationWord());
            StopCoroutine(TimerActivationWord(damage));
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

    //1_2 скил 
    private IEnumerator TimerUpdateImageWeapon1_2(float timer)
    {
        float maxTimer = timer;
        while (timer > 0)
        {
            ImageWeapon1_2.fillAmount = timer / maxTimer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            ImageWeapon1_2.fillAmount = 1;
            weapon1_2Isactive = false;
            StartCoroutine(TimerEndActivationShield_2());
            StopCoroutine(TimerUpdateImageWeapon1_2(0));
        }
    }
    private IEnumerator TimerActivationShield_2()
    {
        float scaleX = 0f;
        float scaleY = 0f;
        float scaleZ = 0f;
        while (scaleX < 1f)
        {
            playerShoot.weapon1_2.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            yield return new WaitForSeconds(0.1f);
            scaleX += .1f; scaleY += 0.08f; scaleZ += 0.03f;
        }
        if (scaleX >= 1f)
        {
            playerShoot.SwitchIsChieldActiv(true);
            StopCoroutine(TimerActivationShield_2());
        }
    
    }
    private IEnumerator TimerEndActivationShield_2()
    {
        float scaleX = 1f;
        float scaleY = 0.5f; 
        float scaleZ = 0.2f;
        while (scaleX >= 0.1f)
        {
            playerShoot.weapon1_2.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            yield return new WaitForSeconds(0.1f);
            scaleX -= .1f; scaleY -= 0.04f; scaleZ -= 0.01f;
        }
        if (scaleX <= 0.1f)
        {
            StopCoroutine(TimerEndActivationShield_2());
        }
    }


    private void OnDestroy()
    {
        EventManager.ButtonEvent -= StartTimerReloadawapon;
    }
}
