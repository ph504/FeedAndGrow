using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorCodile : Creature
{
    public float attack;
    public float startSize;    
    public float attackSpeed;
    public override float GetAttack()
    {
        return attack;
    }
    public override float GetSize()
    {
        return startSize;
    }
}

