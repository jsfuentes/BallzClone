using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () 
    {
	    // start movement here

	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}


    public void Init(Vector2 direction)
    {
        direction.Normalize();

        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Force);
    }
}
