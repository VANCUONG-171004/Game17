using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForArgena : MonoBehaviour
{
    [SerializeField] private IventoryItem iventoryItem;
    [SerializeField] private int soluongnhat;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Intance.AddItems(iventoryItem,soluongnhat);
            Destroy(gameObject);
        }    
    }
}
