using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {


    //set in inspector
    public GameObject character;
    public CharacterBaseData[] characterChoices;


    [SerializeField]
    private DataController gameDataController;
    private CharacterBaseData chosen;
    

    //set by CharacterBaseData
    public GameObject projectilePrefab;
    public float characterSpeed;
    public float fireRate;



    //for shooting alignment
    public float shotForce;
    public float degrees;
    public Vector3 aim;
    public Vector3 shoot;

    //shooting variables
    public float firingTimer; //allows fire once under zero
    public float firingDelay; //timer start value
    public float baseFireRate;

    //for movement
    public Vector2 movement;
    private Rigidbody2D rigid;

    //Game systems linkage
    public HotZoneController hotzoneRoot;
    public SingleHotzone hotzone;
    public bool hotzoneAlive;
    
    
    
    
    // Setup Character from DataController, and BaseData
    void Start () {

        gameDataController = FindObjectOfType<DataController>();

        int gender = 0; //testing
        if (gameDataController == null) {
            Debug.Log("No Data Controller Present");
            
            
                        
            //use for build
            //Application.Quit();
            
        }
        else { gender = gameDataController.genderChoice; } //desired behavior, gender was selected from main menu
        

        chosen = characterChoices[gender];

        //enable helicopter sound
        if (gender == 2) {
            character.GetComponent<AudioSource>().Play();
        }



        character.GetComponent<SpriteRenderer>().sprite = chosen.gameSprite;

        projectilePrefab = chosen.projectile;

        characterSpeed = chosen.moveSpeed;
        character.GetComponent<PlayerHealth>().Initialize(chosen.maxHealth);



        //fire rate
        fireRate = chosen.fireRate;
        firingDelay = baseFireRate / fireRate;
        firingTimer = 0.0f; 

                
        rigid = character.GetComponent<Rigidbody2D>();
        
        


    }




	
	
    
    
    // Gets Input
	void Update () {



        //fire code
        firingTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) &&firingTimer <0.0f) {

            firingTimer = firingDelay;
            aim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            aim.z = 0;
            fireProjectile(aim);
          
        }

        //movement code; first reset movement
        movement.x = 0;
        movement.y = 0;

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


    public void NewWave(int objectiveNum) {

        // {Survive,Hotzone1,Hotzone2,Hotzone3,Hotzone4,Hotzone5}

        if (objectiveNum == 0) { hotzoneRoot.DeactivateHotzones(); }
        else
        {
            hotzoneRoot.ActivateHotzone(objectiveNum - 1);

        }


    }


    public void ZoneDeath(string deadZone) {

        Debug.Log("FailedToProtect " + deadZone);
        GameOver();
    }




    public void GameOver() {



    }
    






}
