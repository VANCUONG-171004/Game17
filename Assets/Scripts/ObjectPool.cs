using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Intance;

    private List<GameObject> pooledObject = new List<GameObject>();
    private int amount = 5;
    [SerializeField] private GameObject enemyPrefab;
    private void Awake() 
    {
        if (Intance == null)
        {
            Intance = this;
        }    
    }
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }

    // Update is called once per frame
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }
        return null;
    }
}
