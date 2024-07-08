using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    private bool isDragging;
    private Vector3 initialPosition;

    public Transform player;


    void Start()
    {
        
    }

    void Update()
    {
        initialPosition = player.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            // Đặt lại vị trí của camera khi nhả chuột
            transform.position = initialPosition;
        }

        if (isDragging)
        {
            Vector3 currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-currentPos.x * 5f, -currentPos.y * 5f, 0);
            transform.Translate(move, Space.World);
        }
    }
}