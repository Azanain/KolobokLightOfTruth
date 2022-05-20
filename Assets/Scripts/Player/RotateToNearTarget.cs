using UnityEngine;

public class RotateToNearTarget : MonoBehaviour
{
    [SerializeField] private float radiusSphere;
    [SerializeField] private LayerMask layers;
    [SerializeField] private float speedRotation;
    [SerializeField] private float offsetX;
    private PlrMove plrMove;
    private Transform nearest;
    private Vector2 range;

    private void Awake()
    {
        plrMove = GetComponent<PlrMove>();
    }

    /// <summary>
    /// поиск ближайшей цели
    /// </summary>
    public void RotateToNearEnemy()
    {
        //if (ReloadScills.IsLaserActiv)
        //{
            Collider[] colls = Physics.OverlapSphere(transform.position, radiusSphere, layers);
            if (colls.Length > 0)
            {
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
                        plrMove.speed = 0;
                        Debug.Log("enemyy");
                        LookAtNearestEnemy(nearest);
                    }
                }
                plrMove.speed = PlayerParametrs.Speed;
                Debug.Log("управление востановлена");
            }
        //}
    }
    /// <summary>
    /// порот к ближайше цели
    /// </summary>
    /// <param name="nearest"></param>
    private void LookAtNearestEnemy(Transform nearest)
    {
        Vector3 positionEnemy = new Vector3(nearest.position.x + offsetX, transform.position.y, nearest.position.z);
        transform.LookAt(positionEnemy);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radiusSphere);
    }
}
