using UnityEngine;
using System.Collections;

public abstract class SpawnableObject : MonoBehaviour 
{
    public Utility.SpawnTypes Type;

    private const float AnimateTime = 0.5f;
    private const float ShiftDistance = 1.0f;

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

    /// <summary>
    /// This is just for debug
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShiftDown();
        }
    }

    public virtual void Init(int hits, Utility.SpawnTypes type)
    {
        this.hits = hits;
    }

    public void ShiftDown()
    {
        StartCoroutine(AnimateShift());

    }

    private IEnumerator AnimateShift()
    {
        float currentLerp = 0f;
        float progress = 0f;
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 endPos = startPos - new Vector3(0, ShiftDistance, 0);

        while (progress < 1.0f)
        {
            currentLerp += Time.deltaTime;
            progress = currentLerp / AnimateTime;
            //move downward
            Vector3 pos = Vector3.Lerp(startPos, endPos, progress);

            transform.position = pos;
            yield return null;
        }
        GameManager.instance.SpawnManager.ReadyToSpawn();

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
