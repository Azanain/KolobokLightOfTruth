using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerAudio playerAudio;

    [Header("WeaponsData")]
    public GameObject[] weapons;//1 - ���, 2 - �����, 3 - ����� ����
    public GameObject weapon1_1;
    public GameObject weapon1_2;//scale x:1 y:0.5 z:0.2
    [SerializeField] private GameObject chargedLaser;
    [SerializeField] private Transform firePointLaser;
    private byte numberWeapon;
    private Pool pool;

//    [SerializeField] private float forceDiscarding;

    public static bool IsCheldActiv { get; private set; }
    public static bool IsLaserActiv { get; private set; }
    public static bool IsWordActiv { get; private set; }
    public static bool IsBackShieldActiv { get; private set; }
    private void Awake()
    {
        EventManager.ButtonEvent += CheckWeapons;
        EventManager.ShootEvent += ShootLaser;
        EventManager.ShootChargedLaserEvent += ShootLaser_2;
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
            EventManager.Discarding(1);
            pool.GetFreeElement(firePointLaser.transform.position, firePointLaser.transform.rotation);
            playerAudio.ShootWeapon2();
        }
    }
    private void ShootLaser_2(int damage)
    {
        Instantiate(chargedLaser, firePointLaser.position, firePointLaser.rotation);
        //EventManager.Discarding(forceDiscarding);
        playerAudio.ShootWeapon2();
    }
    private void OnDestroy()
    {
        EventManager.ShootEvent -= ShootLaser;
        EventManager.ButtonEvent -= CheckWeapons;
        EventManager.ShootChargedLaserEvent -= ShootLaser_2;
    }
}
