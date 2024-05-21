using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;

    [SerializeField]
    List<GameObject>[] pools;

    // Start is called before the first frame update
    void Start()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 쉬고 있는 GameObject가 있는 지 확인
        foreach(GameObject items in pools[index])
        {
            // 쉬고 있는 GameObject가 있다면
            if (!items.activeSelf)
            {
                // 해당 GameObject를 사용
                items.SetActive(true);
                select = items;
                break;
            }
        }

        // 쉬고 있는 GameObject가 없다면 새로 생성
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
