using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyBoss : MonoBehaviour
{
    private static BulletEnemyBoss Intance;

    private GameObject enemy;
    
    private void Awake() 
    {
        Intance = this;    
    }
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        if (Vector2.Distance(this.transform.position, enemy.transform.position) > 15f)
        {
            Destroy(gameObject);            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Heath heath = other.GetComponent<Heath>();
            heath.TakeDame(Random.Range(15,25));
            Destroy(gameObject);
        }    
    }
}
