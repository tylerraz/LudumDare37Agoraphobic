using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

    public float damage;
    public float lifetime;
    public float timer;

    [SerializeField]
    private Animator myAnim;
    [SerializeField]
    private Rigidbody2D myRB2D;
    [SerializeField]
    private Collider2D myCollider;


	// Use this for initialization
	void Start () {

        timer = 0.0f;
        myAnim = GetComponent<Animator>();
        myRB2D = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

	}
	
	// Update is called once per frame
	void Update () {

        if(timer>lifetime)
        {
            Die();

        }

        timer += Time.deltaTime;

	
	}

    public void Die() {


        myRB2D.velocity = Vector2.zero;
        myCollider.enabled = false;

        if (myAnim != null)
            {
            myAnim.enabled = true;
            myAnim.SetBool("Exploding", true);
            Destroy(gameObject, 1f);

        }
        else
        {
            Destroy(gameObject, .1f);
        }

        
    }







}
