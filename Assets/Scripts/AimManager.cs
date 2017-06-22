using UnityEngine;
using System.Collections;

public class AimManager : MonoBehaviour {

    public GameObject BallPrefab;
    private Vector2 _positionOfFirstTouch;
    private Vector2 _positionOfMostRecentTouch;
    private bool _firstTouchSet = false;
    private bool _mostRecentTouchSet = false;


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
    lineRenderer.SetPosition(1, new Vector3(_positionOfMostRecentTouch.x , _positionOfMostRecentTouch.y, 0));
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
