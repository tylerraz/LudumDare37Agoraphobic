using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

    public float damage;
    public float lifetime;
    public float timer;

	// Use this for initialization
	void Start () {

        timer = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {

        if(timer>lifetime)
        {
            Destroy(gameObject);

        }

        timer += Time.deltaTime;

	
	}







}
