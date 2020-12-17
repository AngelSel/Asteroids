using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Pool Config",fileName = "PoolConfig")]
public class PoolConfig : UnityEngine.ScriptableObject
{
    [SerializeField] private int _poolSize = default;
    [SerializeField] private GameObject _prefab = default;

    public int PoolSize => _poolSize;
    public GameObject Prefab => _prefab;
}

