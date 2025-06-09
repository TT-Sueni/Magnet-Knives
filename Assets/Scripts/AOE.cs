using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AOE : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float AOERange = 20f;
    [SerializeField] LayerMask enemyLayer;
    List<float> enemiesinRange = new List<float>();


    PlayerMovement playerMovement;





    // Update is called once per frame
    void Update()
    {
        AOEBehaviour();


    }

    private void AOEBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Collider[] collider = Physics.OverlapSphere(player.transform.position, AOERange, enemyLayer);




            if (collider.Length > 0)
            {

                foreach (Collider c in collider)
                {
                    Image enemylife = c.transform.GetChild(1).GetChild(1).GetComponent<Image>();
                    enemylife.fillAmount -= 0.1f;
 
                }
               //agregar movementspeed por un tiempo limitado


                enemiesinRange.Clear();



            }

        }
    }
}
