using UnityEngine;

public class RotateToNearTarget : MonoBehaviour
{
    [SerializeField] private float radiusSphere;
    [SerializeField] private LayerMask layers;
    [SerializeField] private float Y;
    private Transform gun;
    private Transform nearest;
    private Vector2 range;
    public static bool enemyFound;
    private void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Transform>();
    }
    /// <summary>
    /// поиск ближайшей цели
    /// </summary>
    public void RotateToNearEnemy()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, radiusSphere, layers);
        if (colls.Length > 0)
        {
            enemyFound = true;
            float dist = Mathf.Infinity;
            nearest = colls[0].transform;
            foreach (var foe in colls)
            {
                range = foe.transform.position - transform.position;
                float curDistance = range.sqrMagnitude;
                if (curDistance < dist && foe.CompareTag("Enemy"))
                {
                    nearest = foe.transform;
                    dist = curDistance;
                    LookAtNearestEnemy(nearest);
                }
            }
        }
        else
            enemyFound = false;
    }
    /// <summary>
    /// порот к ближайше цели
    /// </summary>
    /// <param name="nearest"></param>
    private void LookAtNearestEnemy(Transform nearest)
    {
        transform.LookAt(nearest);
        Vector3 pos = new Vector3(nearest.position.x, nearest.position.y + Y, nearest.position.z);
        gun.LookAt(pos);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
       //Gizmos.DrawSphere(transform.position, radiusSphere);
    }

}
