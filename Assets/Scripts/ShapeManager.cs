using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Shape manager. This class works to manage all the blocks balls can hit
/// This class handles spawning and keeps a reference to all blocks
/// </summary>
public class ShapeManager : MonoBehaviour {

    private List<GameObject> _shapes;

    public List<GameObject> Shapes
    {
        get
        {
            return _shapes;
        }
        set
        {
            _shapes = value;
        }
    }

	void Start () 
    {
	    
	}
	
	void Update () 
    {
	
	}

    public void Init()
    {
        _shapes = new List<GameObject>();
    }
          
    public void SpawnShapes()
    {
        
    }
}
