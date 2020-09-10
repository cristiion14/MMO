using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasicEnemy : MonoBehaviour
{
    public Image HealthBar;
    public Text HealthPercentDisplay;
    public float MaxHealth;
    public float CurrentHealth;

    public float dmgdonetest;

    private Animator anim;
    public GameObject bloodEfect;



    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(dmgdonetest);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D playerWeapon = collision.contacts[0].collider;

        if (playerWeapon.gameObject.tag == "PlayerWeapon")
        {
            CurrentHealth -= 5;
            Debug.Log("Hit");
        }
        if (collision.gameObject.tag == "Ground")
        {
            
            Debug.Log("GroundCheck");
        }

    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        HealthBar.fillAmount = (CurrentHealth / MaxHealth);
        int hpDisplay = (int)((CurrentHealth / MaxHealth) * 100);
        if (hpDisplay < 0)
        {
            HealthPercentDisplay.text = "0 %";

        }
        else
            HealthPercentDisplay.text = hpDisplay.ToString() + " %";

    }

    public void Death()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
