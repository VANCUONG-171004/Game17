using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mana : MonoBehaviour
{
    [SerializeField] private float currtenmana;
    [SerializeField] private float manamax;
    [SerializeField] private float manahoi;


    private Heath heath;

    public float mana {get; private set;}

    private void Awake() 
    {
        heath = GetComponent<Heath>();    
    }
    void Start()
    {
        mana = currtenmana;
        CapNhatMana(mana,manamax);

        InvokeRepeating(nameof(TuDongHoiMana),1,1); 
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TakeMana(10);
        }
        
    }
    public void TakeMana(float manabitru)
    {
        if (manabitru<0)
        {
            return;
        }
        if (mana < manabitru)
        {
            return;
        }
        if (mana > 0)
        {
            mana -= manabitru;
            CapNhatMana(mana,manamax);
        }
        
    }

    public void TuDongHoiMana()
    {
        if (heath.Mau > 0 && mana < manamax)
        {
            mana += manahoi;
            CapNhatMana(mana,manamax);
        }
    }


    public void CapNhatMana(float manaht, float manatd)
    {
        UIManager.Intance.CapNhatMana(manaht,manatd);
    }
}
