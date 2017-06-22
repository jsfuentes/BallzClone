using UnityEngine;
using System.Collections;

public class BallKiller : MonoBehaviour {

	public float FirstBallX;
	public bool FirstBallFound = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("collision");
		if(coll.gameObject.GetComponent<Ball>()){
			if(!FirstBallFound){
				FirstBallX = coll.gameObject.transform.position.x;
				FirstBallFound = true;
			}
			Destroy(coll.gameObject);
		}
	}
}
