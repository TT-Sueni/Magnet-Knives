

using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public GameObject currentHitObj;

    [SerializeField] private float sphereRadius;
    [SerializeField] private float sphereMaxDistance;
    [SerializeField] private LayerMask targetLayer;

    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance;
    void Start()
    {

    }


    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, sphereMaxDistance, targetLayer, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObj = hit.transform.gameObject;
            currentHitDistance = hit.distance;


        }
        else
        {
            currentHitDistance = sphereMaxDistance;
            currentHitObj = null;
        }

        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin+ direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }

}
