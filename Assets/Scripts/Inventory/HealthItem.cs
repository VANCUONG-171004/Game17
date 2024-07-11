using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Health")]
public class HealthItem : IventoryItem
{
    public float luongMauHoi;

    public override bool UseItem()
    {
        if (Heath.Intance.DieuKien)
        {
            Heath.Intance.HoiMau(luongMauHoi);
            return true;
        }
        return false;
    }
}
