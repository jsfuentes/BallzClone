using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Singleton class for the game manager. This should be the central 
/// point to access everything we need.
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	public int numOfBalls = 3;

    private AimManager _aimManager;
    private ShapeManager _shapeManager;
	private List<GameObject> _ballsInPlay;
    private ScoreManager _scoreManager;


    // Property for Player Aim
    public AimManager AimManager
    {
        get
        {
            if (_aimManager == null)
            {
                _aimManager = GameObject.FindObjectOfType<AimManager>();
            }
            return _aimManager;
        }
    }

    // Property for ShapeManager
    public ShapeManager ShapeManager
    {
        get
        {
            if (_shapeManager == null)
            {
                _shapeManager = GetComponent <ShapeManager>();
            }
            return _shapeManager;
        }
    }

	public List<GameObject> Balls
    {
        get
        {
            return _ballsInPlay;
        }

        set
        {
            _ballsInPlay = value;
        }
    }

    public ScoreManager ScoreManager
    {
        get
        {
            return _scoreManager;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //make sure this is not destoyed on scene reload or change
        DontDestroyOnLoad(gameObject);
        this.Init();
    }

    private void Init()
    {
        // level setup here

        _ballsInPlay = new List<Ball>();
        _aimManager = GameObject.FindObjectOfType<AimManager>().GetComponent<AimManager>();
        _shapeManager = GetComponent<ShapeManager>();
        _scoreManager = GetComponent<ScoreManager>();

        _shapeManager.Init();
    }
}
