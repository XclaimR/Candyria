using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Transform weaponObject;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Player Attacking");
                Attack();
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }
        
    }

    void Attack()
    {
        //Play Attack Animation
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponObject.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        //Detect Enemies in Range
        //Damage Them
    }

    void OnDrawGizmosSelected()
    {
        if(weaponObject == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(weaponObject.position, attackRange);
    }
}
