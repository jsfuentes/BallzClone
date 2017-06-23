﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Shape manager. This class works to manage all the blocks balls can hit
/// This class handles spawning and keeps a reference to all blocks
/// </summary>
public class SpawnManager : MonoBehaviour {

    public List<GameObject> SpawnableShapes;
    public List<GameObject> SpawnablePowerUps;

    private List<GameObject> _spawnedObjects;

    private List<Transform> SpawnLocations;

    private int _readyToSpawn = 0;

    private Object _lockObject;

    public List<GameObject> SpawnedObjects
    {
        get
        {
            return _spawnedObjects;
        }
        set
        {
            _spawnedObjects = value;
        }
    }

    public void Init()
    {
        _spawnedObjects = new List<GameObject>();
        SpawnLocations = new List<Transform>();
        for (int i = 0; i < transform.childCount; ++i)
        {
            SpawnLocations.Add(transform.GetChild(i));
        }
        _lockObject = new Object();

        SpawnObjects();
    }

    public void ReadyToSpawn()
    {
        lock (_lockObject)
        {
            _readyToSpawn++;
            Debug.Log(_readyToSpawn);
            if (_readyToSpawn == _spawnedObjects.Count)
            {
                SpawnObjects();
                _readyToSpawn = 0;
            }
        }

    }
          
    private void SpawnObjects()
    {
        // determine how many spots we are going to fill
        int spotsToFill = Random.Range(2, SpawnLocations.Count - 2);

        List<bool> filledSpots = new List<bool>();
        for (int i = 0; i < SpawnLocations.Count; ++i)
        {
            filledSpots.Add(false);
        }

        while (spotsToFill > 0)
        {
            int index = Random.Range(0, SpawnLocations.Count);
            if (filledSpots[index] == false)
            {
                filledSpots[index] = true;
                spotsToFill--;

                // determine what to spawn
                // 75% chance we spawn a shape, then choose a random shape
                // 25% chance we spawn a powerup
                float chance = Random.Range(0, 10.0f);
                if (chance <= 75.0f)
                {
                    int slot = Random.Range(0, SpawnableShapes.Count);
                    GameObject shape = (GameObject)Instantiate(SpawnableShapes[slot], SpawnLocations[index].position, Quaternion.identity);
                    _spawnedObjects.Add(shape);
                }
                else
                {
                    int slot = Random.Range(0, SpawnablePowerUps.Count);
                    GameObject powerUp = (GameObject)Instantiate(SpawnablePowerUps[slot], SpawnLocations[index].position, Quaternion.identity);
                    _spawnedObjects.Add(powerUp);
                }
            }
        }
    }
}