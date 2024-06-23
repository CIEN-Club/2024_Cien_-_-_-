using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    [SerializeField]
    private SpawnData[] spawnDatas;

    int level;
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
        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10f), spawnDatas.Length - 1);

        if (timer > spawnDatas[level].spawnTime)
        {
            timer = 0.0f;
            GameObject enemy = GameManager.Instance.PoolingManager.Get(0);
            enemy.GetComponent<Enemy>().Init(spawnDatas[level]);
            enemy.transform.position = positions[Random.Range(1, positions.Length)].position;


            GameObject hpBar = GameManager.Instance.PoolingManager.Get(2);
            hpBar.GetComponent<HpBar>().init(enemy.GetComponent<Enemy>());
        }
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
