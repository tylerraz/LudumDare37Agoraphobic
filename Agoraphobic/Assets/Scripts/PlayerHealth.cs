using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {


    public float maxHealth;
    public float currentHealth;
    public GameObject Player;


    private void Start()
    {

        currentHealth = maxHealth;

    }

    //used by enemies
    public void ReceiveDamage(float damage)
    {
        currentHealth -= damage;
        
        if (currentHealth<= 0.0f)
        {
            die();
        }
    }

    //used by powerups
    public void GainHealth(float health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth) { currentHealth = maxHealth; }

    }



    public void die()
    {
        Player.GetComponent<PlayerController>().GameOver();

    }

	
	

}
