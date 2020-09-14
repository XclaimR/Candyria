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
    public EnemyMovement em;

    void Start()
    {
        currentHealth = maxHeath;
    }

    // Update is called once per frame
    
    public void TakeDamage(int damage,float axis)
    {
        currentHealth -= damage;
        animator.SetTrigger("Enemy_Damage");
        if(axis < 0)
        {
            rb.AddForce(new Vector2(-x_damage, y_damage));
        }
        if(axis > 0)
        {
            rb.AddForce(new Vector2(x_damage, y_damage));
        }
        else
        {
            rb.AddForce(new Vector2(0, y_damage));
        }
        
        
         
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
