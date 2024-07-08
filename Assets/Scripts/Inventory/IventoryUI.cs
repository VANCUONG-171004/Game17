using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class IventoryUI : MonoBehaviour
{
    public static IventoryUI Intance;
    [SerializeField] private GameObject panelIventoryDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemTilte;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private ItemSlot slotPrefab;

    [SerializeField] private Transform content;

    public ItemSlot slotSeccion {get; private set;}

    private List<ItemSlot> slots = new List<ItemSlot>();

    private void Awake() 
    {
        Intance = this;    
    }

    private void Start() 
    {
        CreateSlotIvnetory();    
    }

    private void Update() 
    {
        TheoDoiTuiDoHienTai();    
    }
    private void CreateSlotIvnetory()
    {
        for (int i = 0; i < Inventory.Intance.NumberSlot; i++)
        {
            ItemSlot numberSlot = Instantiate(slotPrefab,content);
            numberSlot.Index = i;
            slots.Add(numberSlot);

        }
    }

    private void TheoDoiTuiDoHienTai()
    {
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;
        if (gameObject == null)
        {
            return;
        }
        ItemSlot slot = gameObject.GetComponent<ItemSlot>();
        if (slot != null)
        {
            slotSeccion = slot;
        }
    }

    public void HienThiItemIventory(IventoryItem itemPorAdd, int soluong,int itemIndex)
    {
        ItemSlot slot = slots[itemIndex];
        if (itemPorAdd != null)
        {
            slot.showSlotUI(true);
            slot.CapNhatSlot(itemPorAdd, soluong);
        }
        else
        {
            slot.showSlotUI(false);
        }
    }

    private void HienItemInvetoryDescription(int index)
    {
        if (Inventory.Intance.IventoryItems[index] != null)
        {
            itemIcon.sprite = Inventory.Intance.IventoryItems[index].Icon;
            itemTilte.text = Inventory.Intance.IventoryItems[index].title;
            itemDescription.text = Inventory.Intance.IventoryItems[index].Description;
            panelIventoryDescription.SetActive(true);
        }
        else
        {
            panelIventoryDescription.SetActive(false);
        }
    }

    private void TuongTacSuKienClick(Seledted seledted , int index)
    {
        if (seledted == Seledted.Click)
        {
            HienItemInvetoryDescription(index);
        }
    }

    private void OnEnable() 
    {
        ItemSlot.EventSlot += TuongTacSuKienClick;    
    }

    private void OnDisable() 
    {
        ItemSlot.EventSlot -= TuongTacSuKienClick;    
    }
}
