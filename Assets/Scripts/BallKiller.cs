﻿using UnityEngine;
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
		Debug.Log("collision");
		if(coll.gameObject.GetComponent<Ball>()){
			if(!FirstBallFound){
				FirstBallX = coll.gameObject.transform.position.x;
				FirstBallFound = true;
			}
			//coll.gameObject.GetComponent<Ball>().speed = 0;
			coll.rigidbody.velocity = new Vector2(0,0);
			coll.rigidbody.angularVelocity = 0f;
			NumberOfBalls++;
		}
	}
}