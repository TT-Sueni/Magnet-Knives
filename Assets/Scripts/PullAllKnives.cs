using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PullAllKnives : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float pullRange = 2000;
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
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Collider[] collider = Physics.OverlapSphere(player.transform.position, pullRange, knifeLayer);




            if (collider.Length > 0)
            {

                foreach (Collider c in collider)
                {

                    c.transform.position = Vector3.MoveTowards(c.transform.position, player.transform.position, 50f * Time.deltaTime);



                }
                
              
                
                knivesinRange.Clear();



            }
        }
    }
}
