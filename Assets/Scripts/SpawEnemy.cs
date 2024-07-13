using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    private float time;

    private void Update()   
    {
        time += Time.deltaTime;
        if (time >= 5)
        {
            time = 0;
            SpawEnemys();
        }    
    }

    public void SpawEnemys()
    {
        GameObject enemy = ObjectPool.Intance.GetPoolObject();
        if (enemy != null)
        {
            enemy.transform.position = this.transform.position;
            enemy.SetActive(true);
        }
    }
}
