﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Singleton class for the game manager. This should be the central
/// point to access everything we need.
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
	public int numOfBalls = 3;
    public int powerUpsGatheredThisTurn = 0;
    public GameObject breakParticles;

    private AimManager _aimManager;
    private SpawnManager _spawnManager;
	private List<GameObject> _ballsInPlay;
    private ScoreManager _scoreManager;

    // this manages turns
    private bool _canShoot = true;


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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 2;
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Time.timeScale = 1;
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
        //this.Init();

        SceneManager.activeSceneChanged += OnLevelLoaded;

    }

    private void Init()
    {
        // level setup here - camera aspect ratio
       // ben wuz h3r3
//        Camera.main.aspect = Screen.width / Screen.height;

        _ballsInPlay = new List<GameObject>();
        _aimManager = GameObject.FindObjectOfType<AimManager>().GetComponent<AimManager>();
        _spawnManager = transform.GetChild(1).GetComponent<SpawnManager>();
        _scoreManager = GetComponent<ScoreManager>();

        _spawnManager.Init();
    }

    public void CleanUpForGameOver()
    {
        _spawnManager.CleanUp();
        _scoreManager.Score = 0;
        _scoreManager.UpdateScoreText();
        _canShoot = true;
    }

    void OnLevelLoaded(Scene scene, Scene sceneTwo)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            Init();
        }
    }
	public void MoveAimManager(float newX){
		_aimManager.moveX(newX);
	}

    public void SpawnParticles(Vector3 location)
    {
        GameObject particles = (GameObject) Instantiate(breakParticles, location, Quaternion.identity);

        //destroy after 2 seconds to be safe
        Destroy(particles.gameObject, 5.0f);
    }
}
