using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {


    public GameObject character;
    private Rigidbody2D rigid;

    //public CharacterMover characterMover;
    public GameObject projectilePrefab;

    public float shotForce;
    public float degrees;
    public float characterSpeed;

    public Vector3 aim;
    public Vector3 shoot;

    public Vector2 movement;
    
    
    // Use this for initialization
	void Start () {


        rigid = character.GetComponent<Rigidbody2D>();
       //characterMover = character.GetComponent<CharacterMover>();


    }
	
	
    
    
    // Gets Input
	void Update () {

        movement.x = 0;
        movement.y = 0;

        if (Input.GetMouseButtonDown(0)) {
           aim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            aim.z = 0;
            fireProjectile(aim);
          
        }

        //sets input vector for FixedUpdate
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");



    }


    //handles movement
    private void FixedUpdate()
    {
        if (movement.x != 0.0f || movement.y != 0.0f)
        {
            rigid.MovePosition(rigid.position + movement * characterSpeed * Time.fixedDeltaTime);

        }


    }



    //angles the projectile and launches it
    public void fireProjectile(Vector3 aim) {


        shoot = (character.transform.position - aim).normalized;
        degrees = Mathf.Atan2(shoot.y, shoot.x) * (180 / Mathf.PI) + 90.0f; //spawn angle of projectiles



        GameObject projectile = GameObject.Instantiate(projectilePrefab, character.transform.position,transform.rotation) as GameObject;

        

        projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, degrees);

       Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();

        rigid.AddForce(-shoot * shotForce);



    }


    public void GameOver() {


    }
    






}
