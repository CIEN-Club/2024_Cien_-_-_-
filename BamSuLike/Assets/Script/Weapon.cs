using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int id;

    [SerializeField]
    private int prefapId;

    [SerializeField]
    private float damage;

    [SerializeField]
    private int count;

    [SerializeField]
    private float speed;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                break;
            default:
                break;
        }

        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(5, 2);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if(id == 0)
        {
            Batch();
        }
    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default: 
                break;
        }
    }

    void Batch()
    {
        for(int i = 0; i < count; i++)
        {
            Transform bulletTr;
            
            if(i < transform.childCount)
            {
                bulletTr = transform.GetChild(i);
            }
            else
            {
                bulletTr = GameManager.Instance.PoolingManager.Get(prefapId).transform;
                bulletTr.parent = transform;
            }

            bulletTr.localPosition = Vector3.zero;
            bulletTr.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bulletTr.Rotate(rotVec);
            bulletTr.Translate(bulletTr.up * 1.5f, Space.World);
            bulletTr.GetComponent<Bullet>().Init(damage, -1); // -1 is infinite num;
        }
    }
}
