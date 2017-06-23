using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shape : SpawnableObject 
{
	private Combos _comboManager;

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

        SetText(hits.ToString());
		_comboManager = GameObject.FindGameObjectWithTag ("Combo").GetComponent<Combos> ();
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
        }
        else
        {
			_comboManager.AddToCombo ();
            // remove from list of shapes and destroy
            List<GameObject> spawned = GameManager.instance.SpawnManager.SpawnedObjects;
            if (spawned != null)
            {
                spawned.Remove(gameObject);
            }
            GameManager.instance.ScoreManager.Score++;
            GameManager.instance.ScoreManager.UpdateScoreText();
            Destroy(gameObject);

        }
    }
        
    private void SetText(string text)
    {
        transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = text;
    }

}
