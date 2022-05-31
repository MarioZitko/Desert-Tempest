using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : MonoBehaviour
{

    public int maxHealth = 100;
    public float attackRange = 1f;
    public int attackDamage = 20;
    public Animator animator;
    int currentHealth;
    public Transform player;
    public bool isFlipped = false;
    public LayerMask attackMask;
    public Transform attackPointHyena;
    public GameObject lootDrop;


    // Start is called before the first frame update
    void Start(){
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage){
        
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0){

            Die();
        }
    }

    void Die(){

        animator.SetBool("IsDead", true);
        Invoke("Freeze", 1.0f);
        this.enabled = false;
        StartCoroutine(delete());

    }

    IEnumerator delete(){

        yield return new WaitForSeconds (2);
        Destroy(gameObject);
        Vector3 pos = transform.position;
        pos.y += 0.5f;
        Instantiate(lootDrop, pos, Quaternion.identity);
    }


    void Freeze(){
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void LookAtPlayer(){
        
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped){

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped){

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack(){
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointHyena.position, attackRange, attackMask );

        foreach(Collider2D enemy in hitEnemies){
            
            enemy.GetComponent<Player_Stats>().UpdateHealth(-attackDamage);
            
        }
    }

    void OnDrawGizmosSelected(){

        if (attackPointHyena == null)return;

        Gizmos.DrawWireSphere(attackPointHyena.position, attackRange);
    }



}
