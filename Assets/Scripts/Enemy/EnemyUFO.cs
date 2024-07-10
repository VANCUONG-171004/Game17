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

    public void TakeDame(int dame)
    {
        ShowDamage(dame.ToString());
        if (dame < 0)
        {
            return;
        }
        health.value -= dame;
        UpdateHealthColor();
    }


    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,Sice);    
    }
}
