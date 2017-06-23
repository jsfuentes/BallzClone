using UnityEngine;
using System.Collections;

public class PowerUp : SpawnableObject
{
    enum TypesOfPowerup {AddBall}
    public int TypeOfPowerup = (int)TypesOfPowerup.AddBall;
    public override void Init(int hits, Utility.SpawnTypes type)
    {
        base.Init(hits, type);
    }

    protected override void TakeHit()
    {
        base.TakeHit();

    }
    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.GetComponent<Ball>())
        {
            TakeHit();
            //Debug.Log("coll");
            if(TypeOfPowerup == (int)TypesOfPowerup.AddBall)
            {
                //add a Ball
                GameManager.instance.SpawnManager.SpawnedObjects.Remove(gameObject);
                Destroy(gameObject);
                GameManager.instance.powerUpsGatheredThisTurn++;
            }
        }
    }
}
