using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawning : MonoBehaviour
{

    public GameObject[] chunksPrefabs;

    private Transform playerTransorm;
    private float spawn = 0f;
    private float chunkLength = 8f;
    private int chunksAmount = 3;
    private float startZone = 15.0f;
    GameManager game;
    private List<GameObject> activeChunks;
    public CoinGenerator coinGenerator;

    void GameOverCOnfirmed()
    {
        DeleteChunks();
        coinGenerator.FreeCoins();
        Configure();

    }

    private void OnEnable()
    {
        GameManager.GameOver += GameOverCOnfirmed;
    }

    private void OnDisable()
    {
        GameManager.GameOver -= GameOverCOnfirmed;
    }

    void Start()
    {
        game = GameManager.Instanse;
        activeChunks = new List<GameObject>();
        Configure();

    }

    void Configure()
    {
        DeleteChunks();
        playerTransorm = GameObject.FindGameObjectWithTag("Player").transform;
        spawn = 0f;
        for (int i = 0; i < chunksAmount; i++)
        {
            Spawn();
            Vector3 currPos = Vector3.up * spawn;
            coinGenerator.CoinSpawn(currPos.y);
        }
    }

    void Update()
    {
        if (game.IsGameOver)
            return;
        if(playerTransorm.position.y - startZone > (spawn - chunksAmount * chunkLength))
        {
            Spawn();
            Vector3 currPos = Vector3.up * spawn;
            coinGenerator.CoinSpawn(currPos.y);
            DeleteChunk();
        }  
    }

    private void Spawn()
    {
        GameObject obj;
        int chunk = Randomizer();
        obj = Instantiate(chunksPrefabs[chunk]) as GameObject;
        obj.transform.SetParent(transform);
        Vector3 currPos = Vector3.up * spawn;

        if(chunk == 0 || chunk == 1)
        {
            if(Random.Range(0,2)==1)
                currPos.x = -4;
        }
        //obj.transform.position = currPos;
        obj.transform.localPosition = currPos;
        if (chunk == 2 || chunk == 1)
            spawn += 9f;
        spawn += chunkLength;
        activeChunks.Add(obj);

    }

    private int Randomizer()
    {
        return Random.Range(0, chunksPrefabs.Length);
    }

    private void DeleteChunk()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

    private void DeleteChunks()
    {
        for(int i =0;i<activeChunks.Count;i++)
        {
            Destroy(activeChunks[i]);
            activeChunks.RemoveAt(i);
        }
    }
}
