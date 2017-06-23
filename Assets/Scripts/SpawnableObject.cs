using UnityEngine;
using System.Collections;

public abstract class SpawnableObject : MonoBehaviour 
{
    public Utility.SpawnTypes Type;

    protected Color _blockColor;
    protected int hits;

    [Tooltip("This will init _hits to 20 for debug")]
    public bool debug;


    public int Hits
    {
        get
        {
            return hits;
        }
        set
        {
            hits = value;
        }
    }

    public virtual void Init(int hits, Utility.SpawnTypes type)
    {

    }

    public void ShiftDown()
    {

    }

    /// <summary>
    /// Either subtracts one from hits or removes the ball and updates the score
    /// </summary>
    protected virtual void TakeHit()
    {
        // if we ever need general hit data

    }

    protected void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
