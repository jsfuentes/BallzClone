using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed;
    public bool active = true;
    public float FirstBallX;
	public bool killme= false;
	public bool firstBall = false;
    private float _ballDeathRange = 1f;

	// Use this for initialization
	void Start ()
    {
	    // start movement here

	}

	// Update is called once per frame
	void Update ()
    {
      if(!active && !firstBall){
        if((transform.position.x < (FirstBallX + _ballDeathRange/2)) && (transform.position.x > (FirstBallX - _ballDeathRange/2))){
			GameManager.instance.Balls.Remove (gameObject);
			Destroy (gameObject);
        }
      }
	}


    public void Init(Vector2 direction)
    {
        direction.Normalize();

        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Force);
    }

	public void moveDown()
	{

	}
}
