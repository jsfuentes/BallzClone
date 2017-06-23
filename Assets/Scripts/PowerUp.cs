using UnityEngine;
using System.Collections;

public class PowerUp : SpawnableObject 
{
    public override void Init(int hits, Utility.SpawnTypes type)
    {
        base.Init(hits, type);
    }

    protected override void TakeHit()
    {
        base.TakeHit();


    }
}
