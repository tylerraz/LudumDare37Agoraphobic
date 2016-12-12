using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    public float maxHealth;
    public float currentHealth;
    public GameObject Player;
    public Text healthText;

    private void Start()
    {

    }

    public void Initialize(float maxH)
    {
        maxHealth = maxH;
        currentHealth = maxH;
        DisplayHealth();

    }

    //used by enemies
    public void ReceiveDamage(float damage)
    {
        currentHealth -= damage;
        DisplayHealth();
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
        DisplayHealth();
    }



    public void die()
    {
        Player.GetComponent<PlayerController>().GameOver();

    }

	
	public void DisplayHealth(){

        string display = currentHealth.ToString() + "/" + maxHealth.ToString();
        healthText.text = display;

    }


}
