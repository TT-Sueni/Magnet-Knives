
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class BounceBehavior : MonoBehaviour
{
    /*
    [SerializeField] GameObject knife;
    [SerializeField] float range = 20;
    [SerializeField] LayerMask enemyLayer;
    List<float> enemiesinRange = new List<float>();
    float currentKnifeDistance;
    Vector3 tpTarget;
    bool onTarget;
    Vector3 closesttargetPosition;
    float closesttarget;
    void Update()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Knives.CheckLayerInMask(enemyLayer, collision.gameObject.layer))
        {
            Collider[] collider = Physics.OverlapSphere(collision.transform.position, range, enemyLayer);




            if (collider.Length > 0)
            {

                foreach (Collider c in collider)
                {

                    currentKnifeDistance = Vector3.Distance(c.transform.position, player.transform.position);

                    knivesinRange.Add(currentKnifeDistance);

                }
                closesttarget = knivesinRange.Min();
                foreach (Collider c in collider)
                {


                    if (closesttarget == Vector3.Distance(c.transform.position, player.transform.position))
                    {



                        closesttargetPosition = c.transform.position;

                        player.transform.position = closesttargetPosition;
                    }

                }
                knivesinRange.Clear();



            }

        }
    }
    */
}
