using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletSpeed = 4.5f;
    private GameObject player;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }
    private void Update() {
        if (Vector2.Distance(player.transform.position, transform.position) > 15f)
        {
            Destroy(gameObject);
        }
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
    }
}
