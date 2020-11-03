using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawning : MonoBehaviour
{

    public GameObject[] chunksPrefabs;

    private Transform _playerTransorm;
    private float _spawn = 0f;
    private float _chunkLength = 8f;
    private int _chunksAmount = 3;
    private float _startZone = 15.0f;
    private GameManager _game;
    private List<GameObject> _activeChunks;
    public CoinGenerator _coinGenerator;

    void GameOverConfirmed()
    {
        DeleteChunks();
        _coinGenerator.FreeCoins();
        Configure();

    }

    private void OnEnable()
    {
        GameManager.GameOver += GameOverConfirmed;
    }

    private void OnDisable()
    {
        GameManager.GameOver -= GameOverConfirmed;
    }

    void Start()
    {
        _game = GameManager.Instanse;
        _activeChunks = new List<GameObject>();
        Configure();

    }

    void Configure()
    {
        DeleteChunks();
        _playerTransorm = GameObject.FindGameObjectWithTag("Player").transform;
        _spawn = 0f;
        for (int i = 0; i < _chunksAmount; i++)
        {
            Spawn();
            Vector3 currPos = Vector3.up * _spawn;
            _coinGenerator.CoinSpawn(currPos.y);
        }
    }

    void Update()
    {
        if (_game.IsGameOver)
            return;
        if(_playerTransorm.position.y - _startZone > (_spawn - _chunksAmount * _chunkLength))
        {
            Spawn();
            Vector3 currPos = Vector3.up * _spawn;
            _coinGenerator.CoinSpawn(currPos.y);
            DeleteChunk();
        }  
    }

    private void Spawn()
    {
        int chunk = Random.Range(0, chunksPrefabs.Length);
        var obj = Instantiate(chunksPrefabs[chunk], transform, true) as GameObject;
        Vector3 currPos = Vector3.up * _spawn;
        if(chunk == 0 || chunk == 1)
        {
            if(Random.Range(0,2)==1)
                currPos.x = -4;
        }
        obj.transform.localPosition = currPos;
        if (chunk == 2 || chunk == 1)
            _spawn += 9f;
        _spawn += _chunkLength;
        _activeChunks.Add(obj);

    }

    private void DeleteChunk()
    {
        Destroy(_activeChunks[0]);
        _activeChunks.RemoveAt(0);
    }

    private void DeleteChunks()
    {
        for(int i =0;i<_activeChunks.Count;i++)
        {
            Destroy(_activeChunks[i]);
            _activeChunks.RemoveAt(i);
        }
    }
}
