using UnityEngine;
using System.Collections;

public class TimeDeactivator : MonoBehaviour {

    public float timer;
    public float lifetime;

	// Use this for initialization
	void Start () {

        timer = 0;
	
	}

    private void OnEnable()
    {

        timer = 0;

    }



    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (timer > lifetime) {
            gameObject.SetActive(false);
        }

	}
}
