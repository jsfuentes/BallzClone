using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shape : SpawnableObject 
{
    private List<Color> _colorScale;
    private int _colorShiftRate;

    public int ScoreAward = 10;
	void Start ()
    {
        // use this so that we can manually place blocks
        if (debug)
        {
            hits = 20;
        }
	}

    /// <summary>
    /// Called by ShapeManager immediately after spawning
    /// </summary>
    /// <param name="hits">Hits.</param>
    /// <param name="type">Type.</param>
    public override void Init(int hits, Utility.SpawnTypes type)
    {
        base.Init(hits, type);

        _colorShiftRate = GameManager.instance.SpawnManager.ColorShiftRate;
        _colorScale = GameManager.instance.SpawnManager.ColorDifficultyScale;

        SetText(hits.ToString());

       // GetComponent<SpriteRenderer>().color = CalculateColor();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {
            TakeHit();
        }
    }

    protected override void TakeHit()
    {
        base.TakeHit();

        if (hits - 1 != 0)
        {
            hits--;
            // update the text on the object
            SetText(hits.ToString());
            //GetComponent<SpriteRenderer>().color = CalculateColor();
        }
        else
        {
            // remove from list of shapes and destroy
            List<GameObject> spawned = GameManager.instance.SpawnManager.SpawnedObjects;
            if (spawned != null)
            {
                spawned.Remove(gameObject);
            }
            GameManager.instance.ScoreManager.Score += ScoreAward;
            GameManager.instance.ScoreManager.UpdateScoreText();
            Destroy(gameObject);
        }
    }
        
    private void SetText(string text)
    {
        transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = text;
    }

    private Color CalculateColor()
    {
        //buckets of size _colorShiftRate
        if (hits < _colorShiftRate)
        {
            return _colorScale[0];
        }
        else if (hits < 2 * _colorShiftRate)
        {
            return _colorScale[1];
        }
        else if (hits < 3 * _colorShiftRate)
        {
            return _colorScale[2];
        }
        else if (hits < 4 * _colorShiftRate)
        {
            return _colorScale[3];
        }
        else if (hits < 5 * _colorShiftRate)
        {
            return _colorScale[4];
        }
        else if (hits < 6 * _colorShiftRate)
        {
            return _colorScale[5];
        }
        else
        {
            return _colorScale[6];
        }
    }

}
