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
            Vector3 randowPosition = new Vector3(
              Random.Range(-90,-35),
              Random.Range(-22,18),
              0  
            );
            enemy.transform.position = randowPosition;
            enemy.SetActive(true);
        }
    }
}
