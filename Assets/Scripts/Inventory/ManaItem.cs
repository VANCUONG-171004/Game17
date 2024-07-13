using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Mana")]
public class ManaItem : IventoryItem
{
    [SerializeField] public float luongMPhoi;


    public override bool UseItem()
    {
        if (Mana.Intance.Dieukien)
        {
            Mana.Intance.HoiMana(luongMPhoi);
            return true;
        }
        return false;
    }
    
}
