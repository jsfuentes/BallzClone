using UnityEngine;
using System.Collections;

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
		if(coll.gameObject.GetComponent<Ball>()){
			if(!FirstBallFound){
				FirstBallX = coll.gameObject.transform.position.x;
				FirstBallFound = true;
				coll.rigidbody.velocity = new Vector2(0,0);
			}
			else{
				//Debug.Log("collision");
				//coll.rigidbody.velocity = new Vector2((FirstBallX-coll.gameObject.transform.position.x), 0);
				if(FirstBallX > coll.gameObject.transform.position.x){
					coll.rigidbody.velocity = new Vector2(10, 0);
				}
				if(FirstBallX < coll.gameObject.transform.position.x){
					coll.rigidbody.velocity = new Vector2(-10, 0);
				}
				coll.gameObject.GetComponent<Ball>().active = false;
				coll.gameObject.GetComponent<Ball>().FirstBallX = FirstBallX;
				//Destroy(coll.gameObject, 1);
			}
			//coll.gameObject.GetComponent<Ball>().speed = 0;
			coll.rigidbody.angularVelocity = 0f;
			NumberOfBalls++;
		}
	}
}
