using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{

    public MissileController myMissle;
    public AudioSource splatClip; //on death play this
    public GameObject other;


    //Enemy Projectiles will collide with static terrain, allowing the player to find cover
    private void OnTriggerEnter2D(Collider2D collision)
    {

        other = collision.gameObject;

        if (other.layer ==8) //player 
        {
            other.GetComponent<PlayerHealth>().ReceiveDamage(myMissle.damage);

            if (splatClip)
            {
                splatClip.Play();
            }

        }

        
        Destroy(gameObject, .25f);



    }
}
