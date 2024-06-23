using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private int per;

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }

    public float GetDamage() { return damage; }
}
