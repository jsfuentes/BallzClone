using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Singleton class for the game manager. This should be the central 
/// point to access everything we need.
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private AimManager aimManager;
    private ShapeManager shapeManager;

    private List<Ball> ballsInPlay;

    // Property for Player Aim
    public AimManager AimManager
    {
        get
        {
            if (aimManager == null)
            {
                aimManager = GameObject.FindObjectOfType<AimManager>();
            }
            return aimManager;
        }
    }

    // Property for ShapeManager
    public ShapeManager ShapeManager
    {
        get
        {
            if (shapeManager == null)
            {
                shapeManager = GameObject.FindObjectOfType<ShapeManager>();
            }
            return shapeManager;
        }
    }

    public List<Ball> Balls
    {
        get
        {
            return ballsInPlay;
        }

        set
        {
            ballsInPlay = value;
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
        ballsInPlay = new List<Ball>();
        aimManager = GameObject.FindObjectOfType<AimManager>();
        shapeManager = GameObject.FindObjectOfType<ShapeManager>();


    }
}
