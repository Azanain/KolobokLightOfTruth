using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float force;
    [HideInInspector] public Collider scale;
    public void Explode(float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<Rigidbody>())
            {
                colliders[i].GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
            }
        } 
    }
}
