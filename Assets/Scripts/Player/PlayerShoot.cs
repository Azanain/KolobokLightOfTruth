using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Explosion explosion;
    private PlayerAudio playerAudio;
    [Header("WeaponsData")]
    [SerializeField] GameObject[] weapons;//1 - щит, 2 - лазер, 3 - слово силы
    [SerializeField] private Transform firePointLaser;
    private byte numberWeapon;
  // [SerializeField] private GameObject bulletLazer;
    Pool pool;

    public static bool isCheldActiv { get; private set; }

    private void Awake()
    {
        //weapons[2].SetActive(true);
        explosion = GetComponentInChildren<Explosion>();
        EventManager.ButtonEvent += CheckWeapons;
        playerAudio = GetComponent<PlayerAudio>();
        EventManager.ShootEvent += ShootLaser;
       // weapons[2].SetActive(false);
        pool = GetComponent<Pool>();
    }

    private void CheckWeapons(byte numWeapon)
    {
        numberWeapon = numWeapon;
        switch (numWeapon)
        {
            case 1:
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                StartCoroutine(TimerActivationSheld());
                break;
            case 2:
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
                isCheldActiv = false;
                break;
            case 3:
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
                isCheldActiv = false;
                StartCoroutine(TimerActivationWord());
                break;

            default:
                isCheldActiv = false;
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                break;
        }
    }

    private IEnumerator TimerActivationSheld()
    {
        float scale = 0;
        while (scale < 1.3)
        {
            weapons[0].transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(0.1f);
            scale += 0.1f;
        }
        if (scale >= 1)
        {
            isCheldActiv = true;
            StopCoroutine(TimerActivationSheld());
        }
    }

    private IEnumerator TimerActivationWord()
    {
        float scale = 0;
        while (scale < 11)
        {
            weapons[2].transform.localScale = new Vector3(scale, scale, scale);
            explosion.Explode(scale);
            yield return new WaitForSeconds(0.05f);
            scale += 3f;
        }
        if (scale >= 9.9f)
        {
            StopCoroutine(TimerActivationWord());
            StartCoroutine(TimerActivationWordRevers(scale));
        }
    }

    private IEnumerator TimerActivationWordRevers(float scale)
    {
        while (scale > 0.5f)
        {
            weapons[2].transform.localScale = new Vector3(scale, scale, scale);
            explosion.Explode(scale);
            yield return new WaitForSeconds(0.05f);
            scale -= 3f;
        }
        if (scale < 0.5f)
        {
            weapons[2].SetActive(false);
            StopCoroutine(TimerActivationWordRevers(scale));
        }
    }

    private void ShootLaser()
    {
        if (numberWeapon == 2)
        {
           // Instantiate(bulletLazer, firePointLaser.position, firePointLaser.rotation);
            pool.GetFreeElement(firePointLaser.transform.position, firePointLaser.transform.rotation);
            playerAudio.ShootWeapon1();
        }
    }

    private void OnDestroy()
    {
        EventManager.ShootEvent -= ShootLaser;
        EventManager.ButtonEvent -= CheckWeapons;
    }
}
