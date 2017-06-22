using UnityEngine;
using System.Collections;

public class AimManager : MonoBehaviour {
	private readonly float _AIM_HEIGHT = 0.4f;

    public GameObject BallPrefab;
    private Vector2 _positionOfFirstTouch;
    private Vector2 _positionOfMostRecentTouch;
    private bool _firstTouchSet = false;
    private bool _mostRecentTouchSet = false;
	private Vector3 _lineToTouch;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
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
        SpawnBall(direction);
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
	_lineToTouch = new Vector3 (scaleRatio * lineToTouchX, _AIM_HEIGHT, 0);
	lineRenderer.SetPosition(1, _lineToTouch);
  }
  void deleteLine(){
    LineRenderer lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.SetPosition(1, transform.position);
  }

    void SpawnBall(Vector2 direction)
    {
        GameObject ball = (GameObject) Instantiate(BallPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Ball>().Init(direction);
    }
}
