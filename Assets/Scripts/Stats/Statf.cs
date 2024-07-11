using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statf")]
public class Statf : ScriptableObject
{
    [Header("Statf")]
    [Header("EXP")]
    public float CapDo;
    public float expCanDats;
    public float HeSoTangTruong;

    public float exp;
    public float exphientai;
    public float SoKinhNghiemCanDat;
    [Header("Velocity")]
    public float velocity;
    [Header("Health")]
    public float currtenheath;
    public float maxheath;
    [Header("Mana")]
    public float currtenmana;
    public float manamax;
    [Header("Damage")]
    public int minDamage;
    public int maxDamage;
    [Header("Coin")]
    public int Coin;
}
