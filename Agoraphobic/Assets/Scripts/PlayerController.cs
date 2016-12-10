using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {


    public Transform character;
    public GameObject projectilePrefab;
    public float shotForce;
    public float degrees;

    public Vector3 aim;
    public Vector3 shoot;

    private Vector2 movement;
    
    
    // Use this for initialization
	void Start () {
	


	}
	
	
    
    
    // Update is called once per frame
	void Update () {

        movement.x = 0;
        movement.y = 0;

        if (Input.GetMouseButtonDown(0)) {
           aim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fireProjectile(aim);
          
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");



    }


    public void fireProjectile(Vector3 aim) {


        shoot = (character.transform.position - aim).normalized;
        degrees = Mathf.Atan2(shoot.y, shoot.x) * (180 / Mathf.PI) + 90.0f; //spawn angle of projectiles



        GameObject projectile = GameObject.Instantiate(projectilePrefab, character.transform.position,transform.rotation) as GameObject;

        

        projectile.transform.rotation = Quaternion.Euler(0.0f, 0.0f, degrees);

       Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();

        rigid.AddForce(-shoot * shotForce);



    }


    






}
