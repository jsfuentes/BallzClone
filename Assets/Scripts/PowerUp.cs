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
    void OnTriggerEnter2D(Collider2D coll) {
        TakeHit();
        //Debug.Log("coll");
        if(TypeOfPowerup == (int)TypesOfPowerup.AddBall){
          //add a Ball
          Destroy(gameObject);
          //TODO: make this not happen till the end of the round
          GameManager.instance.numOfBalls++;

        }
    }
}
