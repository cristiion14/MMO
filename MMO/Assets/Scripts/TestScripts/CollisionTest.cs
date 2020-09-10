using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "PlayerWeapon")
        {
            Debug.Log(" Player Weapon Collision Test Successful");
        }

        if (collision.gameObject.name == "PlayerTwo")
        {
            Debug.Log(" Player Collision Test Successful");
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
