using UnityEngine;
using System.Collections;

public class AIshooting : MonoBehaviour {

    public PlayerController myPlayer;

    public GameObject EnemyProjectile; //prefab
    public Vector3 myTarget;

    public float fireDelaySeconds;
    public float fireTimer;
    public float shotForce;
   


	// Use this for initialization
	void Start () {

        myPlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        fireTimer += Time.deltaTime;

        if (fireTimer > fireDelaySeconds)
        {
            fireTimer = 0.0f;
            LaunchEnemyProjectile();

        }
	
	}

    void LaunchEnemyProjectile() {

        myTarget = myPlayer.character.transform.position;

        Vector3 shoot = (transform.position - myTarget).normalized;
        float degrees = Mathf.Atan2(shoot.y, shoot.x) * (180 / Mathf.PI) + 90.0f; //spawn angle of projectiles



        GameObject projectile = GameObject.Instantiate(EnemyProjectile, transform.position, transform.rotation) as GameObject;



        projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, degrees);

        Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();

        rigid.AddForce(-shoot * shotForce);

    }




}
