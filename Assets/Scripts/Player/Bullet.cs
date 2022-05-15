using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int lifeTime;

    private PoolObject poolObject;
    
    private void Awake()
    {
        poolObject = GetComponent<PoolObject>();
    }
    
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Invoke("DestroyBullet", lifeTime);
    }
    
    private void DestroyBullet()
    {
        poolObject.ReturnToPool();
    }
}
