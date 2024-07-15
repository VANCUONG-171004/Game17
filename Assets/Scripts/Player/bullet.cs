using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public static bullet Intance;
    private float bulletSpeed = 4.5f;
    private GameObject player;
    [SerializeField] private Statf statf;
    public int Damage;
    private void Awake() 
    {
        Intance = this;    
    }

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Damage = Random.Range(statf.minDamage,statf.maxDamage);    
    }
    private void Update() {
        if (Vector2.Distance(player.transform.position, transform.position) > 15f)
        {
            Destroy(gameObject);
        }
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
    }

}
