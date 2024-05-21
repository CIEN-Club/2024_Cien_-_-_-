using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        positions = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            timer = 0.0f;
            GameObject enemy = GameManager.Instance.PoolingManager.Get(Random.Range(0, 2));
            enemy.transform.position = positions[Random.Range(1, positions.Length)].position;
        }
    }
}
