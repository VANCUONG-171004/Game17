using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUFO : Enemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletsPos;

    [SerializeField] private float Sice;
    private Transform player;

    private float timer;
    void Start()
    {
        health.maxValue = 100;
        health.value = health.maxValue;
        health.fillRect.GetComponent<Image>().color = fullHealthColor;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDame(10);
        }
    }

    public void Shoot()
    {
        float Distance = Vector2.Distance(player.position, transform.position);
        if (Distance < Sice)
        {
            Instantiate(bullet, bulletsPos.position, Quaternion.identity);
        }

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Sice);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            
            bullet bullets = other.GetComponent<bullet>();
            Exp.Intance.ThangCap(Random.Range(5,10));
            TakeDame(bullets.Damage);
            Destroy(other.gameObject);
        }

    }
}
