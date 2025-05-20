
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class BounceBehavior : MonoBehaviour
{/*
    [SerializeField] LayerMask bounceableMask;
    float distance;
    float closestTarget = 0;
    GameObject target;
    Shooting shooting;
    Vector3 targetposition;
    void Start()
    {

    }


    void Update()
    {
        
      

    }
    private void OnCollisionEnter(Collision collision)
    {
      if (Knives.CheckLayerInMask(bounceableMask, collision.gameObject.layer))
        {

            transform.position = Vector3.MoveTowards(transform.position, CheckForColliders(), 10 * Time.deltaTime);

        }

    }
    private Vector3 CheckForColliders()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 19f);
        foreach (Collider c in collider)
        {
            distance = Vector3.Distance(transform.position, c.transform.position);
            GameObject cc = c.GetComponent<GameObject>();

            if (closestTarget == 0 || distance <= closestTarget)
            {

                if (Knives.CheckLayerInMask(knifeMask, c.gameObject.layer))
                {
                    Knives targetKnife = c.gameObject.GetComponent<Knives>();
                    if (targetKnife.isGrounded)
                    {
                        Debug.Log("entro");

                        closestTarget = distance;
                        target = c.gameObject;
                        c.GetComponent<Enemy>();
                        Vector3 targetposition = cc.transform.position;


                    }

                }
                else if (CheckLayerInMask(enemyMask, c.gameObject.layer))
                {
                    Debug.Log("entro enemigo");
                    closestTarget = distance;


                    target = cc;
                    targetposition = c.GetComponent<Enemy>().transform.position;
                    //Debug.Log(targetposition);

                }




            }





        }
        //Debug.Log(target);
        return targetposition;

    }
    */
}
