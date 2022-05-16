using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Explosion explosion;
    private PlayerAudio playerAudio;
    [Header("WeaponsData")]
    [SerializeField] GameObject[] weapons;//1 - ���, 2 - �����, 3 - ����� ����
    [SerializeField] private Transform firePointLaser;
    private byte numberWeapon;
    Pool pool;

    public static bool IsCheldActiv { get; private set; }
    public static bool IsLaserActiv { get; private set; }
    private void Awake()
    { 
        EventManager.ButtonEvent += CheckWeapons;
        EventManager.ShootEvent += ShootLaser;
        explosion = GetComponentInChildren<Explosion>();
        playerAudio = GetComponent<PlayerAudio>();
        pool = GetComponent<Pool>();
        CheckWeapons(0);
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
                IsLaserActiv = false;
                StartCoroutine(TimerActivationSheld());
                break;
            case 2:
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
                IsCheldActiv = false;
                IsLaserActiv = true;
                break;
            case 3:
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
                IsCheldActiv = false;
                IsLaserActiv = false;
                EventManager.Jump();
                StartCoroutine(TimerActivationWord());
                break;

            default:
                IsCheldActiv = false;
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                    IsLaserActiv = false;
                    IsCheldActiv = false;
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
            IsCheldActiv = true;
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
            pool.GetFreeElement(firePointLaser.transform.position, firePointLaser.transform.rotation);
            playerAudio.ShootWeapon2();
        }
    }

    private void OnDestroy()
    {
        EventManager.ShootEvent -= ShootLaser;
        EventManager.ButtonEvent -= CheckWeapons;
    }
}