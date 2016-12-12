using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{

    public MissileController myMissle;
    public SFX splat; //on death play this
    public GameObject other;

    private void Start()
    {
        splat = GetComponent<SFX>();
    }


    //Enemy Projectiles will collide with static terrain, allowing the player to find cover
    private void OnTriggerEnter2D(Collider2D collision)
    {

        other = collision.gameObject;

        if (other.layer ==8) //player 
        {
            other.GetComponent<PlayerHealth>().ReceiveDamage(myMissle.damage);

            //soundeffect
            if (splat) {splat.PlaySoundEffect(); }
            
            

        }

        
        Destroy(gameObject, .25f);



    }
}
