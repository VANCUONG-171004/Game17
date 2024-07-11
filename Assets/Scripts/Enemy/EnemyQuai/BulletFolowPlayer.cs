using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFolowPlayer : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position, Speed * Time.deltaTime);
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
