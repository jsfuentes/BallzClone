using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AimManager : MonoBehaviour {
	private readonly float _AIM_HEIGHT = 2.5f;
	private readonly float _TIME_TO_WAIT = .3f;

    public GameObject BallPrefab;
    private Vector2 _positionOfFirstTouch;
    private Vector2 _positionOfMostRecentTouch;
    private bool _firstTouchSet = false;
    private bool _mostRecentTouchSet = false;
    private Vector3 _lineToTouch;
    private Text _ballsText;
	private bool justEmptiedBallz = false;

    // Use this for initialization
    void Start () {
       _ballsText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () {
    _ballsText.text = "x" + GameManager.instance.numOfBalls;
        if (GameManager.instance.CanShoot == false)
        {
            return;
        }
	   if(Input.GetMouseButton(0) && !_firstTouchSet){
       setFirstPosition();
     }
     if(Input.GetMouseButton(0)){
       setMostRecentPosition();
     }
     if(_firstTouchSet && _mostRecentTouchSet){
       drawAimLine();
       if(!Input.GetMouseButton(0)){
        //shoot the ballz
        Vector2 direction = new Vector2(_positionOfMostRecentTouch.x - transform.position.x, _positionOfMostRecentTouch.y - transform.position.y);
       
        //set turn
        GameManager.instance.CanShoot = false;
		justEmptiedBallz = true;
        StartCoroutine(SpawnBalls(direction));
        _firstTouchSet = false;
        _mostRecentTouchSet = false;
        deleteLine();
        }
      }
     }

  void setFirstPosition(){
    _positionOfFirstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    _firstTouchSet = true;
  }
  void setMostRecentPosition(){
    _positionOfMostRecentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    _mostRecentTouchSet = true;
  }
  void drawAimLine(){
    LineRenderer lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.SetPosition(0, transform.position);
	float lineToTouchX = _positionOfMostRecentTouch.x - transform.position.x;
	float lineToTouchY = _positionOfMostRecentTouch.y - transform.position.y;
	//scale pt to get pt on line at aim height
	float scaleRatio = _AIM_HEIGHT/lineToTouchY;
     _lineToTouch = new Vector3 (scaleRatio * lineToTouchX + transform.position.x, _AIM_HEIGHT + transform.position.y, 0);
	lineRenderer.SetPosition(1, _lineToTouch);
  }
  void deleteLine(){
    LineRenderer lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.SetPosition(1, transform.position);
  }

	/// <summary>
	/// Spawns the balls and give GameManager a list of balls.
	/// </summary>
	/// <param name="direction">Direction.</param>

    IEnumerator SpawnBalls(Vector2 direction) {
		if (justEmptiedBallz) {
			List<GameObject> Balls = GameManager.instance.Balls;
			for (int i = 0; i < Balls.Count; i++) {
				if (!Balls [i].GetComponent<Ball> ().active) {
					Destroy (Balls [i]);
					GameManager.instance.Balls.Remove (Balls [i]);
				}
			}
		}
		justEmptiedBallz = false;

        //Debug.Log ("Balls Spawned Num " + GameManager.instance.numOfBalls);
        int numberOfBallsToSpawn = GameManager.instance.numOfBalls;
		for(int i = 0; i < numberOfBallsToSpawn; i++){
            GameObject ball = (GameObject) Instantiate(BallPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Ball>().Init(direction);
			GameManager.instance.Balls.Add (ball);
			yield return new WaitForSeconds (_TIME_TO_WAIT);
		}



	}
	public void moveX(float newX){
		transform.position = new Vector2(newX, transform.position.y);
	}
}
