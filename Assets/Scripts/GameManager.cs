using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton class for the game manager. This should be the central 
/// point to access everything we need.
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    // Property for Player Ball

    // Property for ShapeManager

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
    }
}
