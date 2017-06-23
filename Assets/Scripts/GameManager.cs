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
    private SpawnManager _spawnManager;
	private List<GameObject> _ballsInPlay;
    private ScoreManager _scoreManager;
    private bool _canShoot = false;


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
    public SpawnManager SpawnManager
    {
        get
        {
            if (_spawnManager == null)
            {
                Debug.Log("null");
                _spawnManager = transform.GetChild(1).GetComponent<SpawnManager>();
            }
            return _spawnManager;
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

    public bool CanShoot
    {
        get
        {
            return _canShoot;
        }
        set
        {
            _canShoot = value;
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

        _ballsInPlay = new List<GameObject>();
        _aimManager = GameObject.FindObjectOfType<AimManager>().GetComponent<AimManager>();
        _spawnManager = transform.GetChild(1).GetComponent<SpawnManager>();
        _scoreManager = GetComponent<ScoreManager>();

        _spawnManager.Init();
    }
}
