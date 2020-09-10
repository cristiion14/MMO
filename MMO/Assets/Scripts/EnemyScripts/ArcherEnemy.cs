using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject target;

    float maximHealth;
    float currentHealth;
    float damage;
    public float attackSpeed;
    float drop;


    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            Vector2 shootingDirection = new Vector2(target.transform.position.x, target.transform.position.y);
            shootingDirection.Normalize();
            arrow.GetComponent<Rigidbody2D>().velocity =shootingDirection * attackSpeed;
            Destroy(arrow, 2.0f);



            time = time - interpolationPeriod;


    
        
        }
    }

}
