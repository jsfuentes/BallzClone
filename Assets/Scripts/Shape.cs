using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shape : MonoBehaviour {

    public Utility.ShapeTypes Type;

    private Color _blockColor;
    private int _hits;

    public int Hits
    {
        get
        {
            return _hits;
        }
        set
        {
            _hits = value;
        }
    }


	void Start ()
    {

	}


	void Update ()
    {

	}

    /// <summary>
    /// Called by ShapeManager immediately after spawning
    /// </summary>
    /// <param name="hits">Hits.</param>
    /// <param name="type">Type.</param>
    void Init(int hits, Utility.ShapeTypes type)
    {
        _hits = hits;
        _type = type;

        SetText(_hits.ToString());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Ball>())
        {

        }
    }

    private void TakeHit()
    {
        if (_hits - 1 != 0)
        {
            _hits--;
            // update the text on the object
            SetText(_hits.ToString());
        }
        else
        {
            // remove from list of shapes and destroy
            List<GameObject> shapes = GameManager.instance.ShapeManager.Shapes;
            if (shapes != null)
            {
                shapes.Remove(gameObject);
            }
            Destroy(gameObject);
        }

    }

    private void SetText(string text)
    {
        transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = text;
    }

    private void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
