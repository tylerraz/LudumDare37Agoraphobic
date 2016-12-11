using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


    public enum EnemyAI_State {ChasePlayer, Wander,ShootPlayer,MoveToObjective}
    public EnemyAI_State currentAI;
    public Rigidbody2D myRigid;
    public PlayerController playerController;
    public GameObject playerCharacter;
    public float speed;

    //for random range 
    public Vector2 Xmapbounds;
    public Vector2 Ymapbounds;

    public Vector3 targetPosition;
    public Vector3 moveVector;

    public bool moving;
    
    // Use this for initialization
	void Start () {

        myRigid = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        playerCharacter = playerController.character;
        targetPosition = transform.position; //won't move by default
        moving = true;

        StartCoroutine("MovementLoop");
	
	}



    private IEnumerator MovementLoop()
    {

        float delay = 0.5f;
        if (currentAI == EnemyAI_State.Wander) { delay = 2.0f; } //longer delay if random


        while (moving) { 
        targetPosition = ChooseMoveTarget();


        yield return new WaitForSeconds(delay);

        }

    }





    private void FixedUpdate()
    {

        moveVector = (targetPosition - transform.position).normalized * speed * Time.fixedDeltaTime;

        myRigid.MovePosition(transform.position+moveVector);
    }

    public Vector3 ChooseMoveTarget() {

        switch (currentAI)
        {
            case EnemyAI_State.ChasePlayer: {
                    
                    return playerCharacter.transform.position;
                }
            case EnemyAI_State.MoveToObjective: {

                    return transform.position;
                }

            case EnemyAI_State.Wander:
                {
                    return new Vector3(Random.Range(Xmapbounds.x,Xmapbounds.y),Random.Range(Ymapbounds.x,Ymapbounds.y),0);
                }

            default:
                {
                    return transform.position;

                }




        }

    }



}
