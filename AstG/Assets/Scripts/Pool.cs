using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    public GameObject poolObjectPrefab;
    public int poolSize;

    List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolObjectPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    /*
    private void Start()
    {
        pool = new List<GameObject>();

        for(int i =0;i<poolSize;i++)
        {
            GameObject obj = (GameObject)Instantiate(poolObjectPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }*/

    public GameObject Instantiat(Vector3 position)
    {
        foreach(var item in pool)
        {
            if(!item.activeInHierarchy)
            {
                item.transform.position = position;
                item.SetActive(true);
                return item;
            }
        }

        Quaternion rotation = new Quaternion(0,0,0,0);
        GameObject obj = (GameObject)Instantiate(poolObjectPrefab,position,rotation);
        pool.Add(obj);
        return obj;


    }

    public void FreePool()
    {
        foreach(var item in pool)
        {
            if(item.activeInHierarchy)
            {
                item.SetActive(false);
            }
        }
    }


}
