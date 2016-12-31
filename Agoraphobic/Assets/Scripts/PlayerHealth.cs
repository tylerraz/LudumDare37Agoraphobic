using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    public float maxHealth;
    public float currentHealth;
    public GameObject Player;
    public Text healthText;

    [SerializeField]
    private bool invulnerable;
    [SerializeField]
    private float invulnTime;

    [SerializeField]
    private Animator myAnimator;


    private void Start()
    {
        invulnerable = false;
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("Invulnerable", false);
        
    }

    public void Initialize(float maxH)
    {
        maxHealth = maxH;
        currentHealth = maxH;
        DisplayHealth();

    }

    //called by enemies
    public void ReceiveDamage(float damage)
    {

        if(invulnerable) { return; }

        currentHealth -= damage;
        DisplayHealth();

        invulnerable = true;
        myAnimator.SetBool("Invulnerable", true);
        StartCoroutine(Invulnerability());

        if (currentHealth<= 0.0f)
        {
            Die();
        }
    }

    private IEnumerator Invulnerability() {

        
        yield return new WaitForSeconds(invulnTime);

        invulnerable = false;
        myAnimator.SetBool("Invulnerable", false);
    }



    //used by powerups
    public void GainHealth(float health)
    {
        currentHealth += health;
        

        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        DisplayHealth();
    }



    private void Die()
    {
        Player.GetComponent<PlayerController>().GameOver("You died!");

    }

	
	public void DisplayHealth(){

        string display = currentHealth.ToString() + "/" + maxHealth.ToString();
        healthText.text = display;

    }


}
