using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject enemy;
    [SerializeField] Image enemyLifeBar;
    [SerializeField] float enemyMovementSpeed;
    [SerializeField] UIManager UI;

 
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemyMovementSpeed * Time.deltaTime);
        Vector3 floor = new Vector3(0, transform.position.y, 0);
        transform.position -= floor;
        transform.LookAt(target.transform);
        if (enemyLifeBar.fillAmount <= 0)
        {
            UI.Credits();
           Destroy(enemy);
        }
        
    }
}
