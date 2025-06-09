using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float TPRange = 20;
    [SerializeField] LayerMask knifeLayer;
    List<float> knivesinRange = new List<float>();
    float currentKnifeDistance;
    Vector3 tpTarget;
    bool onTarget;
    Vector3 closesttargetPosition;
    float closesttarget;


    void Start()
    {

    }


    void Update()
    {
        CheckForColliders();

    }
    private void CheckForColliders()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Collider[] collider = Physics.OverlapSphere(player.transform.position, TPRange, knifeLayer);

            


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
                        
                        player.transform.position = Vector3.MoveTowards(player.transform.position, closesttargetPosition, 50f * Time.deltaTime);

                        //closesttargetPosition;
                    }

                }
                knivesinRange.Clear();



            }

        }
    }



   
}
