using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IventoryItem : ScriptableObject
{
    [Header("Info")]
    public string ID;
    public string title;
    public Sprite Icon;
    [TextArea] public string Description;

    public bool IsTieuThu;
    public bool IsMax;

    public int soluongMax;
    public int soluonghientai;

    public IventoryItem CopyItem()
    {
        IventoryItem newIntance = Instantiate(this);
        return newIntance;
    }

    public virtual bool UseItem()
    {
        return true;
    }
}
