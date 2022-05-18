using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerAudio playerAudio;

    [Header("WeaponsData")]
    public GameObject[] weapons;//1 - щит, 2 - лазер, 3 - слово силы
    public GameObject weapon1_1;
    public GameObject weapon1_2;//scale x:1 y:0.5 z:0.2
    [SerializeField] private Transform firePointLaser;
    private byte numberWeapon;
    private Pool pool;

    public static bool IsCheldActiv { get; private set; }
    public static bool IsLaserActiv { get; private set; }
    public static bool IsWordActiv { get; private set; }
    public static bool IsBackShieldActiv { get; private set; }
    private void Awake()
    {
        EventManager.ShootChargeLazerEvent += ShootLaser_2;
        EventManager.ButtonEvent += CheckWeapons;
        EventManager.ShootEvent += ShootLaser;
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
                break;
        }
    }

    public void SwitchIsChieldActiv(bool isActiv)
    {
        IsCheldActiv = isActiv;
    }
    public void SwitchIsWordActiv(bool isActiv)
    {
        IsWordActiv = isActiv;
    }

    private void ShootLaser()
    {
        if (numberWeapon == 2)
        {
            pool.GetFreeElement(firePointLaser.transform.position, firePointLaser.transform.rotation);
            playerAudio.ShootWeapon2();
        }
    }
    private void ShootLaser_2()
    {
        if (numberWeapon == 2)
        {
            Debug.Log("shoot charge lazer");
            //pool.GetFreeElement(firePointLaser.transform.position, firePointLaser.transform.rotation);
            //playerAudio.ShootWeapon2();
        }
    }
    private void OnDestroy()
    {
        EventManager.ShootEvent -= ShootLaser;
        EventManager.ButtonEvent -= CheckWeapons;
        EventManager.ShootChargeLazerEvent -= ShootLaser_2;
    }
}
