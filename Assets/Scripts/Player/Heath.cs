using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    public static Heath Intance;
    [SerializeField] private float currtenheath;
    [SerializeField] private float maxheath;

    public float Mau {get; private set;}

    private void Awake() 
    {
        Intance = this;    
    }
    void Start()
    {
        Mau = currtenheath;
        CapNhatLuongMau(Mau,maxheath); 
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDame(10);
            
        }
    }

    public void TakeDame(float mau)
    {
        if (mau < 0)
        {
            return;
        }
        if (Mau > 0f)
        {
            Mau -= mau;
            CapNhatLuongMau(Mau,maxheath);  
        }
        
         
    }

    public void CapNhatLuongMau(float mauht , float mautd)
    {
        UIManager.Intance.CapNhatLuongMau(mauht,mautd);
    }
}
