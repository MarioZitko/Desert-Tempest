using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Player_Stats playerStats;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRange2 = 0.7f;
    public LayerMask enemyLayers;
    public int attackStamina1 = 10;
    public int attackStamina2 = 20;
    public int attackDamage = 20;
    public int attackDamage2 = 40;
    public float attackRate = 3f;
    public float attackRate2 = 3f;
    float nextAttackTime = 0;

    public void Attack(){
        if (playerStats.CheckStamina(attackStamina1)){
            if (Time.time >= nextAttackTime){
                animator.SetTrigger("Attack");
                Invoke("DoDamage", 0.5f);
                
                nextAttackTime = Time.time + 2f / attackRate;
                playerStats.UpdateStamina(-attackStamina1);
            }
        }
    }

    void DoDamage(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers );
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Hyena>().TakeDamage(attackDamage);
        }
    }

    public void Attack2(){
        if (playerStats.CheckStamina(attackStamina2)){
            if (Time.time >= nextAttackTime){

                animator.SetTrigger("Attack2");
                Invoke("DoDamage2", 1f);
                
                nextAttackTime = Time.time + 2f / attackRate2;
                playerStats.UpdateStamina(-attackStamina2);
            }
        }
    }

    void DoDamage2(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange2, enemyLayers );
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Hyena>().TakeDamage(attackDamage2);
        }
    }


    void OnDrawGizmosSelected(){
        if (attackPoint == null)return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}