using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour {


    private Rigidbody2D self;
    public float speed;

    private void Start()
    {
        self = gameObject.GetComponent<Rigidbody2D>();

    }



    public void Move(Vector2 movement)
    {

        self.MovePosition(speed * movement);

    }

}
