using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class Creature
{
    public float health;
    public float speed;
    public float rotateSpeed;

    public abstract float  GetAttack();
    public abstract float GetSize();
}
