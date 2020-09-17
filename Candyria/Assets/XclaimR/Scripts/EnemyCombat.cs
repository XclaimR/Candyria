using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 20;
    public Animator animator;

    public float buttonRate = 0.5f;
    float nextButtonTime = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time >= nextButtonTime)
        {
            if (collision.gameObject == GameObject.FindGameObjectWithTag("Player") && collision.gameObject != GameObject.FindGameObjectWithTag("Weapon"))
            {
                Debug.Log(collision.gameObject.tag);
                animator.SetTrigger("Player_Damage");
                collision.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
                nextButtonTime = Time.time + 1 / buttonRate;
            }
        }
    }
}
