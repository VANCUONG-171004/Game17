using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : Enemy
{

    [SerializeField] private float range;
    [SerializeField] private float rangedame;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    
    private float time;
    private Transform player;
    private void Start() 
    {
        health.maxValue = 2000;
        health.value = health.maxValue;
        health.fillRect.GetComponent<Image>().color = fullHealthColor;
        player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    private void Update() 
    {
        time  += Time.deltaTime;
        if (time >= 2)
        {
            MoveEnemy();
        }
        
        
    }

    public void MoveEnemy()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= range && distanceFromPlayer>= rangedame)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, 15 * Time.deltaTime);
            
        }else if (distanceFromPlayer < rangedame)
        {
            Debug.Log("dame player");
            time = 0;
            CreateBullets();
        }
        
    }
    
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, rangedame);     
    }

    private void CreateBullets()
    {
        for (int i = 0; i < 10; i++)
        {
            float angle = (i * 2 * Mathf.PI) / 10;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle) * bulletSpeed, Mathf.Sin(angle) * bulletSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            bullet bullets = other.GetComponent<bullet>();
            Exp.Intance.ThangCap(Random.Range(5,10));
            TakeDame(bullets.Damage);
            PlayHitEffect();
            Destroy(other.gameObject);
        }

    }
}
