using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private int damage;
    [SerializeField] private int lifeTime;

    private PoolObject poolObject;
    
    private void Awake()
    {
        //добавить коротину урона 
        poolObject = GetComponent<PoolObject>();
    }
    
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Invoke("DestroyBullet", lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        poolObject.ReturnToPool();
    }
}
