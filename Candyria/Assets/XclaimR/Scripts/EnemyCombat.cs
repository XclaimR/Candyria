using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 20;
    public Animator animator;

    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time >= nextAttackTime)
        {
            if (collision.gameObject == GameObject.FindGameObjectWithTag("Player") && collision.gameObject != GameObject.FindGameObjectWithTag("Weapon"))
            {
                Debug.Log(collision.gameObject.tag);
                animator.SetTrigger("Player_Damage");
                collision.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }
    }
}
