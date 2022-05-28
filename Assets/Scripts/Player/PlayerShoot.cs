using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerAudio playerAudio;

    [Header("WeaponsData")]
    public GameObject[] weapons;//1 - щит, 2 - лазер, 3 - слово силы
    [SerializeField] private GameObject chargedLaser;
    [SerializeField] private Transform firePointLaser;
    private Pool pool;

    private void Awake()
    {
        EventManager.ShootEvent += ShootLaser;
        EventManager.ShootChargedLaserEvent += ShootLaser_2;
        playerAudio = GetComponentInChildren<PlayerAudio>();
        pool = GetComponent<Pool>();
    }
    private void Start()
    {
        firePointLaser = GameObject.FindGameObjectWithTag("FirePointLaser").transform;
    }
    private void ShootLaser()
    {
        EventManager.Discarding(1);
        pool.GetFreeElement(firePointLaser.transform.position, firePointLaser.transform.rotation);
        playerAudio.ShootWeapon2_1();
    }
    private void ShootLaser_2(int damage)
    {
        Instantiate(chargedLaser, firePointLaser.position, firePointLaser.rotation);
        playerAudio.ChargingLaser(false);
    }
    private void OnDestroy()
    {
        EventManager.ShootEvent -= ShootLaser;
        EventManager.ShootChargedLaserEvent -= ShootLaser_2;
    }
}
