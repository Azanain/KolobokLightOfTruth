using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScills : MonoBehaviour
{
    private Image ImageWeapon1_1;
    private Image ImageWeapon2_1;
    private Image ImageWeapon3_1;

    //private Image ImageWeapon1_2;
    private Image ImageWeapon2_2;
    //private Image ImageWeapon3_2;

    private PlayerShoot playerShoot;
    private Explosion explosion;

    private bool Weapon1_1IsActive;
    //public static bool Weapon1_2IsActive { get; private set; }

    //public static bool Weapon2_2IsActive { get; private set; }
    public static bool Weapon3_1IsActive { get; private set; }
    //public static bool Weapon3_2IsActive { get; private set; }
    private void Awake()
    {
        EventManager.ButtonEvent += StartTimerReloadawapon;
        playerShoot = GetComponent<PlayerShoot>();
        explosion = GetComponent<Explosion>();
        ImageWeapon1_1 = GameObject.FindGameObjectWithTag("ShieldOfFaith").GetComponent<Image>();
        ImageWeapon2_1 = GameObject.FindGameObjectWithTag("RayOfHope").GetComponent<Image>();
        ImageWeapon3_1 = GameObject.FindGameObjectWithTag("WordOfPower").GetComponent<Image>();

       // ImageWeapon1_2 = GameObject.FindGameObjectWithTag("ShieldOfFaith_2").GetComponent<Image>();
        ImageWeapon2_2 = GameObject.FindGameObjectWithTag("RayOfHope_2").GetComponent<Image>();
       // ImageWeapon3_2 = GameObject.FindGameObjectWithTag("WordOfPower_2").GetComponent<Image>();
        
        //playerShoot.weapons[0].SetActive(true);

        ImageWeapon1_1.fillAmount = 1;
        ImageWeapon2_1.fillAmount = 1;
        ImageWeapon3_1.fillAmount = 1;
        ImageWeapon2_2.fillAmount = 0;
    }
    private void StartTimerReloadawapon(byte button)
    {
        switch (button)
        {
            case 1://1_1
                if (!Weapon1_1IsActive)
                {
                    Weapon1_1IsActive = true;
                    StartCoroutine((TimerUpdateImageWeapon1(PlayerParametrs.TimeReloadWeapon1)));
                    EventManager.Dash(80);
                    StartCoroutine(TimerActivationShield());
                    EventManager.AudioWeapon1();
                }
                break;
            case 3://3_1
                if (!Weapon3_1IsActive)
                {
                    Weapon3_1IsActive = true;
                    //EventManager.Discarding(3);
                    EventManager.Jump(3);
                    StartCoroutine(TimerActivationWord(5));
                    StartCoroutine((TimerUpdateImageWeapon3(PlayerParametrs.TimeReloadWeapon3)));
                    playerShoot.weapons[3].SetActive(true);
                    Debug.Log(PlayerParametrs.DamageWeapon3);
                    EventManager.AudioWeapon3();
                }
                break;
            //case 4://1_2
            //    if (!Weapon1_2IsActive)
            //    {
            //        Weapon1_2IsActive = true;
            //        StartCoroutine(TimerUpdateImageWeapon1_2(PlayerParametrs.TimeReloadWeapon1_2));
            //        EventManager.Dash(10);
            //        playerShoot.weapons[1].SetActive(true);
            //        StartCoroutine(TimerActivationShield_2());
            //    }
            //    break;
            case 5://2_2
                StartCoroutine(UpdateImageWeapon2_2(PlayerParametrs.TimeReloadWeapon2_2));
                break;
            //case 6://3_2
            //    if (!Weapon3_2IsActive)
            //    {
            //        Weapon3_2IsActive = true;
            //        //EventManager.Discarding(8);
            //        EventManager.Jump(5);
            //        playerShoot.weapons[4].SetActive(true);
            //        StartCoroutine((TimerUpdateImageWeapon3_2(PlayerParametrs.TimeReloadWeapon3_2)));
            //        StartCoroutine(TimerActivationWord_2(10));
            //    }
            //    break;
        }
    }
    //1_1 скил осн режим
    private IEnumerator TimerUpdateImageWeapon1(float timer)
    {
        EventManager.CanMove();
        float maxTimer = timer;
        while (timer > 0)
        {
            ImageWeapon1_1.fillAmount = 1-timer / maxTimer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            EventManager.CanMove();
            ImageWeapon1_1.fillAmount = 1;
            Weapon1_1IsActive = false;
            StartCoroutine(TimerEndActivationShield());
            StopCoroutine(TimerUpdateImageWeapon1(0));
        }
    }
    private  IEnumerator TimerActivationShield()
    {
        Enemy enemy;
        float scale = 0f;
        while (scale < 3f)
        {
            //playerShoot.weapons[0].SetActive(true);
            playerShoot.weapons[0].transform.localScale = new Vector3(1, 1, 1);
            playerShoot.weapons[3].transform.localScale = new Vector3(scale, scale, scale);
            Collider[] colliders = Physics.OverlapSphere(transform.position, scale);
            foreach (var foe in colliders)
            {
                if (foe.CompareTag("Enemy"))
                {
                    enemy = foe.GetComponent<Enemy>();
                    int damage = (int)(PlayerParametrs.DamageWeapon1 + PlrMove.moveVelosity);
                    enemy.TakeDamage(damage);
                }
            }
            yield return new WaitForSeconds(0.1f);
            scale += 1f;
        }
        if (scale >= 1f)
        {
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
            playerShoot.weapons[0].SetActive(false);
            StopCoroutine(TimerEndActivationShield());
        }
    }
    //3_1 скил осн режим
    private IEnumerator TimerUpdateImageWeapon3(float timer)
    {
        float maxTimer = timer;
        while (timer > 0)
        { 
            ImageWeapon3_1.fillAmount = 1 - timer / maxTimer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            ImageWeapon3_1.fillAmount = 1;
            Weapon3_1IsActive = false;
            StartCoroutine(TimerEndActivationWord());
            StopCoroutine(TimerUpdateImageWeapon3(0));
        }
    }
    private IEnumerator TimerActivationWord(int damage)
    {
        Enemy enemy;
        float scale = 0;
        while (scale < 5)
        {
            playerShoot.weapons[3].transform.localScale = new Vector3(scale, scale, scale);
            Collider[] colliders = Physics.OverlapSphere(transform.position, scale);
            foreach (var foe in colliders)
            {
                if (foe.CompareTag("Enemy"))
                {
                    enemy = foe.GetComponent<Enemy>();
                    enemy.TakeDamage(PlayerParametrs.DamageWeapon3);
                }
            }
            yield return new WaitForSeconds(0.1f);
            explosion.Explode(scale);
            scale += 2f;
        }
        if (scale >= 5)
        {
            EventManager.Discarding(3);
            StartCoroutine(TimerEndActivationWord());
            StopCoroutine(TimerActivationWord(damage));
        }
    }
    private IEnumerator TimerEndActivationWord()
    {
        float scale = 5;
        while (scale > 0.5f)
        {
            playerShoot.weapons[3].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale -= 2f;
        }
        if (scale <= 0.5f)
        {
            playerShoot.weapons[3].SetActive(false);
            StopCoroutine(TimerEndActivationWord());
        }
    }
    ////3_2
    //private IEnumerator TimerUpdateImageWeapon3_2(float timer)
    //{
    //    float maxTimer = timer;
    //    while (timer > 0)
    //    {
    //        ImageWeapon3_2.fillAmount = timer / maxTimer;
    //        yield return new WaitForSeconds(0.1f);
    //        timer -= 0.1f;
    //    }
    //    if (timer <= 0)
    //    {
    //        ImageWeapon3_2.fillAmount = 1;
    //        Weapon3_2IsActive = false;
    //        StartCoroutine(TimerEndActivationWord_2());
    //        StopCoroutine(TimerUpdateImageWeapon3_2(0));
    //    }
    //}
    //private IEnumerator TimerActivationWord_2(int damage)
    //{
    //    Enemy enemy;
    //    float scale = 0;
    //    while (scale < 5)
    //    {
    //        playerShoot.weapons[4].transform.localScale = new Vector3(scale, scale, scale);
    //        Collider[] colliders = Physics.OverlapSphere(transform.position, scale);
    //        foreach (var foe in colliders)
    //        {
    //            if (foe.CompareTag("Enemy"))
    //            {
    //                enemy = foe.GetComponent<Enemy>();
    //                enemy.TakeDamage(PlayerParametrs.DamageWeapon3_2);
    //            }
    //        }
    //        yield return new WaitForSeconds(0.1f);
    //        explosion.Explode(scale);
    //        scale += 2f;
    //    }
    //    if (scale >= 5)
    //    {
    //        EventManager.Discarding(3);
    //        StartCoroutine(TimerEndActivationWord_2());
    //        StopCoroutine(TimerActivationWord(damage));
    //    }
    //}
    //private IEnumerator TimerEndActivationWord_2()
    //{
    //    float scale = 5;
    //    while (scale > 0.9f)
    //    {
    //        playerShoot.weapons[4].transform.localScale = new Vector3(scale, scale, scale);
    //        yield return new WaitForSeconds(0.1f);
    //        scale -= 2f;
    //    }
    //    if (scale <= 0.9f)
    //    {
    //        playerShoot.weapons[4].SetActive(false);
    //        StopCoroutine(TimerEndActivationWord());
    //    }
    //}
    ////1_2 скил 
    //private IEnumerator TimerUpdateImageWeapon1_2(float timer)
    //{
    //    float maxTimer = timer;
    //    while (timer > 0)
    //    {
    //        ImageWeapon1_2.fillAmount = timer / maxTimer;
    //        yield return new WaitForSeconds(0.1f);
    //        timer -= 0.1f;
    //    }
    //    if (timer <= 0)
    //    {
    //        ImageWeapon1_2.fillAmount = 1;
    //        Weapon1_2IsActive = false;
    //        StartCoroutine(TimerEndActivationShield_2());
    //        StopCoroutine(TimerUpdateImageWeapon1_2(0));
    //    }
    //}
    //private IEnumerator TimerActivationShield_2()
    //{
    //    float scaleX = 0f;
    //    float scaleY = 0f;
    //    float scaleZ = 0f;
    //    while (scaleX < 1f)
    //    {
    //        playerShoot.weapons[1].transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    //        yield return new WaitForSeconds(0.1f);
    //        scaleX += .1f; scaleY += 0.08f; scaleZ += 0.03f;
    //    }
    //    if (scaleX >= 1f)
    //    {
    //        StopCoroutine(TimerActivationShield_2());
    //    }
    //}
    //private IEnumerator TimerEndActivationShield_2()
    //{
    //    float scaleX = 1f;
    //    float scaleY = 0.5f; 
    //    float scaleZ = 0.2f;
    //    while (scaleX >= 0.1f)
    //    {
    //        playerShoot.weapons[1].transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    //        yield return new WaitForSeconds(0.1f);
    //        scaleX -= .1f; scaleY -= 0.04f; scaleZ -= 0.01f;
    //    }
    //    if (scaleX <= 0.1f)
    //    {
    //        StopCoroutine(TimerEndActivationShield_2());
    //    }
    //}
    //2-2
    private IEnumerator UpdateImageWeapon2_2(float timer)
    {
        float maxTimer = timer;
        while (timer > 0)
        {
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        if (timer <= 0)
        {
            StopCoroutine(UpdateImageWeapon2_2(0));
        }
    }
    private void OnDestroy()
    {
        EventManager.ButtonEvent -= StartTimerReloadawapon;
    }
}
