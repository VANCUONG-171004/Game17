using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollow : Enemy
{
    public float fasingDir = 1;
    private bool FashingRight = true;
    [SerializeField] private float Speed;
    [SerializeField] private float lineOfSize;
    [SerializeField] private float shootingRange;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPos;
    private Transform player;
    private float timer;

    void Start()
    {
        health.maxValue = 100;
        health.value = health.maxValue;
        health.fillRect.GetComponent<Image>().color = fullHealthColor;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSize && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);
            FacePlayer();
        }
        else if (distanceFromPlayer <= shootingRange && timer > 2)
        {
            timer = 0;
            Instantiate(bulletPrefab, bulletPos.transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDame(Random.Range(5, 10));
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSize);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private void FacePlayer()
    {
        // Xác định hướng mà kẻ địch nên quay đầu
        if (player.position.x > transform.position.x && FashingRight)
        {
            Flip();
        }

        else if (player.position.x < transform.position.x && !FashingRight)
        {
            Flip();
        }

    }
    public void Flip()
    {
        fasingDir = fasingDir * -1;
        FashingRight = !FashingRight;
        transform.Rotate(0, 180, 0);
    }
    public void FlipControler(float x)
    {
        if (x > 0 && !FashingRight)
            Flip();
        else if (x < 0 && FashingRight)
            Flip();
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
