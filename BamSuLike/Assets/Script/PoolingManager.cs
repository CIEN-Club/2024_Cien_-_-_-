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

        // ���� �ִ� GameObject�� �ִ� �� Ȯ��
        foreach(GameObject items in pools[index])
        {
            // ���� �ִ� GameObject�� �ִٸ�
            if (!items.activeSelf)
            {
                // �ش� GameObject�� ���
                items.SetActive(true);
                select = items;
                break;
            }
        }

        // ���� �ִ� GameObject�� ���ٸ� ���� ����
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
