using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private LayerMask mask;
    private int damage;
    [SerializeField] private float lifeTime;
    //[SerializeField] private bool isRicochet;
    private PoolObject poolObject;
    public bool IsCharge;
    private void Awake()
    {
        damage = PlayerParametrs.DamageWeapon2;
        poolObject = GetComponent<PoolObject>();
    }
    private void Start()
    {
         EventManager.ShootChargedLaserEvent += CheckDamage;
    }
    private void CheckDamage(int damageChargedLaser)
    {
        damage = damageChargedLaser;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //if (isRicochet)
        //{
        //    Ray ray = new Ray(transform.position, transform.forward);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + 0.1f, mask))
        //    {
        //        Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
        //        float rot = Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg; ;
        //        transform.eulerAngles = new Vector3(rot, 0, 0);
        //    }
        //}
        StartCoroutine(TimerLife());
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            if (IsCharge)
                enemy.TakeDamage(ButtonRay.DamageWeapon2_2);
            else
                enemy.TakeDamage(damage);
        }
        if (other.CompareTag("Wall") || other.CompareTag("Ground"))
        {
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        poolObject.ReturnToPool();
        StopCoroutine(TimerLife());
    }
    private IEnumerator TimerLife()
    {
        float timer = lifeTime;
        while (timer >= 0)
        {
            timer -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        if (timer <= 0)
        {
            DestroyBullet();
        }
    }
    private void OnDestroy()
    {
        EventManager.ShootChargedLaserEvent -= CheckDamage;
    }
}
