using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Seledted
{
    Click,
    Use,
    Equira,
    Remover
}
public class ItemSlot : MonoBehaviour
{
    public static Action<Seledted, int > EventSlot;
    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject banner;
    [SerializeField] private TextMeshProUGUI soluongTMP;

    public int Index {get; set;}

    public void CapNhatSlot(IventoryItem item, int soluong)
    {
        itemIcon.sprite = item.Icon;
        soluongTMP.text = soluong.ToString();
    }

    public void showSlotUI(bool estto)
    {
        itemIcon.gameObject.SetActive(estto);
        banner.SetActive(estto);
    }

    public void ClickSlot()
    {
        EventSlot?.Invoke(Seledted.Click, Index);
    }
}
