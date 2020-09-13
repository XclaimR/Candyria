using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public Rigidbody2D rb;
    public float x_damage;
    public float y_damage;

    void Update()
    {
        if(transform.position.y <= -20)
        {
            TakeDamage(9999999);
        }
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        rb.AddForce(new Vector2(-x_damage*Input.GetAxis("Horizontal"), y_damage));
        if(health <= 0)
        {
            Debug.Log("Player Dead");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }




}
