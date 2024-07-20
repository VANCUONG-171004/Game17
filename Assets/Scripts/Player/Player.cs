using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public float fasingDir = 1;
    private bool FashingRight = true;

    public float dashDir { get; private set; }

    [Header("Dash setting")]
    public float DashSpeed = 30f;

    public float DashTime;
    private float _dashTime;
    private bool IsDashing = false;

    [Header("Mover")]
    private Vector2 MoveInput;
    private float MoveSpeed = 5;



    public GameObject bulletPrefab;
    public Transform localtransform;
    private Mana manas;

    public ParticleSystem particlesSystem;
    private bool isMoving = false;

    public float rotationSpeed = 180f; // Tốc độ quay của player

    private Vector3 shootDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        manas = GetComponent<Mana>();
    }
    void Start()
    {
        particlesSystem.Stop();
    }

    void Update()
    {
        
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Mover", MoveInput.sqrMagnitude);

        FlipControler(MoveInput.x);

        CheckInput();


        // Kiểm tra trạng thái di chuyển của nhân vật
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (!isMoving)
            {
                isMoving = true;
                particlesSystem.Play();
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                particlesSystem.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Lấy hướng nhắm bắn từ vị trí của chuột
            shootDirection = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

            if (shootDirection.x < 0 && fasingDir == 1)
            {
                return;
            }
            else if (shootDirection.x > 0 && fasingDir == -1)
            {
                return;
            }


            if (manas.mana >= 5)
            {
                manas.TakeMana(5);
                GameObject news = Instantiate(bulletPrefab, localtransform.position, transform.rotation);

                news.GetComponent<Rigidbody2D>().velocity = shootDirection * 20;
            }



            // Tính toán góc xoay và xoay player
            // float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(MoveInput.x * MoveSpeed, MoveInput.y * MoveSpeed);
    }


    public void CheckInput()
    {
        Dash();

    }

    //Quay đầu
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

    // Kĩ Năng Dash
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && IsDashing == false)
        {
            MoveSpeed += DashSpeed;
            _dashTime = DashTime;
            IsDashing = true;
        }

        if (_dashTime <= 0 && IsDashing == true)
        {
            MoveSpeed -= DashSpeed;
            IsDashing = false;
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }

    }

    void RotatePlayerTowards(Vector3 direction)
    {
        // Tính toán góc quay cần thiết
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Quay player về hướng mới
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
    }

}
