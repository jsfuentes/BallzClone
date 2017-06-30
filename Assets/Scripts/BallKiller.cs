using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BallKiller : MonoBehaviour {

	public float FirstBallX;
	public bool FirstBallFound = false;
	public int NumberOfBalls = 0;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<Ball>())
        {
            if (!FirstBallFound)
            {
                FirstBallX = coll.gameObject.transform.position.x;
                FirstBallFound = true;
                coll.rigidbody.velocity = new Vector2(0, 0);
				coll.gameObject.GetComponent<Ball>().active = false;

            }
            else
            {
                //Debug.Log("collision");
                //coll.rigidbody.velocity = new Vector2((FirstBallX-coll.gameObject.transform.position.x), 0);
                if (FirstBallX > coll.gameObject.transform.position.x)
                {
                    coll.rigidbody.velocity = new Vector2(10, 0);
                }
                if (FirstBallX < coll.gameObject.transform.position.x)
                {
                    coll.rigidbody.velocity = new Vector2(-10, 0);
                }
                coll.gameObject.GetComponent<Ball>().active = false;
                coll.gameObject.GetComponent<Ball>().FirstBallX = FirstBallX;
                //Destroy(coll.gameObject, 1);


            }
            //coll.gameObject.GetComponent<Ball>().speed = 0;
            coll.rigidbody.angularVelocity = 0f;
            NumberOfBalls++;

            if (GameManager.instance.numOfBalls == NumberOfBalls)
            {
                // we have all the balls and need to switch state
                GameManager.instance.SpawnManager.ShiftObjects();
                NumberOfBalls = 0;

                //update ball count now that we are done to reflect collected balls
                GameManager.instance.numOfBalls += GameManager.instance.powerUpsGatheredThisTurn;
                GameManager.instance.powerUpsGatheredThisTurn = 0;
				GameManager.instance.MoveAimManager (FirstBallX);
				FirstBallFound = false;

            }
        }
         else if (coll.gameObject.GetComponent<Shape>())
        {
            //handle game over
            Debug.Log("GameOver");
            GameManager.instance.CleanUpForGameOver();
            SceneManager.LoadScene(2);
        }
	}
}
