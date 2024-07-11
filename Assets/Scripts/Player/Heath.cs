using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] private Statf statf;
    public static Heath Intance;
    [SerializeField] protected GameObject floatingTextPrefab;
    public bool DieuKien => Mau < statf.maxheath;
    public float Mau {get; private set;}

    private void Awake() 
    {
        Intance = this;    
    }
    void Start()
    {
        Mau = statf.currtenheath;
        CapNhatLuongMau(Mau,statf.maxheath); 
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
        ShowDamage(mau.ToString());
        if (mau < 0)
        {
            return;
        }
        if (Mau > 0f)
        {
            Mau -= mau;
            CapNhatLuongMau(Mau,statf.maxheath);  
        }
        
         
    }
    public void HoiMau(float mau)
    {
        ShowDamage(mau.ToString());
        if (mau < 0)
        {
            return;
        }
        if (Mau >= statf.maxheath)
        {
            Mau = statf.manamax;
            CapNhatLuongMau(Mau,statf.maxheath);   
        }
        if (Mau > 0f)
        {
            Mau += mau;
            CapNhatLuongMau(Mau,statf.maxheath);  
        }
        
         
    }
    public virtual void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

            Destroy(prefab, 1f);
        }
    }

    public void CapNhatLuongMau(float mauht , float mautd)
    {
        UIManager.Intance.CapNhatLuongMau(mauht,mautd);
    }
}
