using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private LayerMask mask;
    private int damage;
    [SerializeField] private int lifeTime;
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
        Debug.Log($"charged  = {damage}");
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
        Invoke("DestroyBullet", lifeTime);
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
    }
    private void DestroyBullet()
    {
        poolObject.ReturnToPool();
    }
    private void OnDestroy()
    {
        EventManager.ShootChargedLaserEvent -= CheckDamage;
    }
}
