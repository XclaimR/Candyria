using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHeath = 100;
    int currentHealth;
    public Animator animator;
    public Rigidbody2D rb;
    public float x_damage;
    public float y_damage;
    void Start()
    {
        currentHealth = maxHeath;
    }

    // Update is called once per frame
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Enemy_Damage");
        rb.AddForce(new Vector2(x_damage * Input.GetAxis("Horizontal"), y_damage));
        //Play Hurt Animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        //Die Animation
        
        //Disable Enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
