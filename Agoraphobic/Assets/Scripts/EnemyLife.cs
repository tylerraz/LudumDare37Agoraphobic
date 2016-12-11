using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

    public float healthMax;
    public float currentHealth;
    public float damageReduction;
    public float meleeDamage;

    private void Start()
    {
        currentHealth = healthMax;
    }

    public void TakeDamage(float damage) {

        currentHealth = currentHealth - (Mathf.Max(1,damage - damageReduction)); //always do 1 minimum damage

        if (currentHealth < 0.0) { Die(); }


    }

    public void Die() {



        Destroy(gameObject, .25f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject other = collision.gameObject;

        if(other.layer == 8) //player 
        {
            TakeDamage(10);
            other.GetComponent<PlayerHealth>().ReceiveDamage(meleeDamage);

        } else if(other.layer == 9) //projectile
            {

            MissileController missile = other.GetComponent<MissileController>();
            TakeDamage(missile.damage);
            missile.Die();
            

        }


        


    }









}
