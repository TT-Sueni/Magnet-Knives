
using UnityEngine;

using UnityEngine.UI;

public class Knives : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] Image enemyLifeBar;

    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask bounceableMask;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask knifeMask;
    [SerializeField] Vector3 rotation = new Vector3(1, 1, 1);
    Rigidbody rb;
    BoxCollider bx;
    SphereCollider spc;
    public bool isGrounded;
    float distance;
    float closestTarget = 0;
    GameObject target;
    Shooting shooting;
    Vector3 targetposition;
    bool wall = false;
    float bounceSpeed = 20;
    int collisionCounter = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spc = GetComponent<SphereCollider>();
        bx = GetComponent<BoxCollider>();
        isGrounded = false;

    }


    void Update()
    {
        if (wall)
        {
            transform.position = Vector3.MoveTowards(transform.position, CheckForColliders(), bounceSpeed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {


        if (CheckLayerInMask(groundMask, collision.gameObject.layer))
        {
            Debug.Log("toco suelo");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            isGrounded = true;
            //knife.layer = 11;
            //spc.enabled = false;
            //bx.enabled = true;

            Suspension();
            wall = false;



        }
        else if (CheckLayerInMask(enemyMask, collision.gameObject.layer))
        {

            ObjectPool.Instance.ReturnToQueue("Knife", knife);
            knife.SetActive(false);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            if (collisionCounter == 0)
            {
                enemyLifeBar.fillAmount -= 0.05f;
            }
            else if (collisionCounter == 1)
            {
                enemyLifeBar.fillAmount -= 0.1f;
            }
            else if (collisionCounter == 2)
            {
                enemyLifeBar.fillAmount -= 0.15f;
            }
            else if (collisionCounter == 3)
            {
                enemyLifeBar.fillAmount -= 0.2f;
            }
            collisionCounter = 0;


            wall = false;

        }
        else if (CheckLayerInMask(bounceableMask, collision.gameObject.layer))
        {

            if (CheckForColliders() != Vector3.zero)
            {
                wall = true;
            }
            else
            {
                wall = false;
                Vector3 direction = transform.position - new Vector3(1, 1, 1);
                rb.AddForce(direction.normalized * bounceSpeed, ForceMode.Impulse);

            }

        }
        if (isGrounded)
        {
            if (CheckLayerInMask(playerMask, collision.gameObject.layer))
            {
                Debug.Log("toco jugador");
                ObjectPool.Instance.ReturnToQueue("Knife", knife);
                knife.SetActive(false);
                isGrounded = false;
                rb.useGravity = true;
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            wall = false;
            CheckForColliders();
        }



    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    private void Suspension()
    {
        rb.useGravity = false;
        Vector3 position = gameObject.transform.position;
        Vector3 suspension = new Vector3(0, 1, 0);

        var magia = position + suspension;
        gameObject.transform.position = magia;
        rb.AddTorque(transform.rotation * rotation, ForceMode.Impulse);

    }
    private Vector3 CheckForColliders()
    {

        Collider[] collider = Physics.OverlapSphere(transform.position, 15f);
        if (collider.Length > 0)
        {
            foreach (Collider c in collider)
            {
                distance = Vector3.Distance(transform.position, c.transform.position);


                if (closestTarget == 0 || distance <= closestTarget)
                {

                   /* if (CheckLayerInMask(knifeMask, c.gameObject.layer))
                    {
                        Knives targetKnife = c.gameObject.GetComponent<Knives>();
                        if (targetKnife.isGrounded)
                        {
                            
                                Debug.Log("entro");
                            closestTarget = distance;
                            target = c.gameObject;

                            targetposition = c.transform.position;
                            

                        }

                    }
                    else*/ if (CheckLayerInMask(enemyMask, c.gameObject.layer))
                    {
                        Debug.Log("entro enemigo");
                        closestTarget = distance;

                        targetposition = c.GetComponent<Enemy>().transform.position;
                        Debug.Log(targetposition);

                    }
                    /*else
                    {
                        Vector3 defaultToFloor = new(-1, -2, 0);
                        targetposition = transform.position + defaultToFloor;
                    }*/
                }
            }



        }
        return targetposition;
    }
}



