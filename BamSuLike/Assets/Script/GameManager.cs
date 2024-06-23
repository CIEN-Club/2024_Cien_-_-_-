using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTime;
    public float maxGameTime = 2 * 60f;

    public PoolingManager PoolingManager;
    public Player player;

    private void Awake()
    {
        Instance = this;
        gameTime = 0;
    }


    private void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
