using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Intance;
    [SerializeField] private int numberSlot;
    public int NumberSlot => numberSlot;

    [Header("Items")]
    [SerializeField] private IventoryItem[] iventoryItems ;
    public IventoryItem[] IventoryItems => iventoryItems;

    private void Start() 
    {
        iventoryItems = new IventoryItem[numberSlot];    
    }

    private void Awake() 
    {
        Intance = this;   
    }

    public void AddItems(IventoryItem itemforAdd, int soluong)
    {
        if (itemforAdd == null)
        {
            return;
        }

        List<int> index = KiemTraTonTaiMuc(itemforAdd.ID);
        if (itemforAdd.IsTieuThu)
        {
            if (index.Count > 0)
            {
                for (int i = 0; i < index.Count; i++)
                {
                    if (iventoryItems[index[i]].soluonghientai < itemforAdd.soluongMax)
                    {
                        iventoryItems[index[i]].soluonghientai += soluong;
                        if (iventoryItems[index[i]].soluonghientai > itemforAdd.soluongMax)
                        {
                            int soluongconlai = iventoryItems[index[i]].soluonghientai - itemforAdd.soluongMax;
                            iventoryItems[index[i]].soluonghientai = itemforAdd.soluongMax;
                            AddItems(itemforAdd,soluongconlai);
                        }

                        IventoryUI.Intance.HienThiItemIventory(itemforAdd,iventoryItems[index[i]].soluonghientai, index[i]);
                        return;
                    }
                }
            }
        }

        if (soluong <= 0)
        {
            return;
        }
        if (soluong > itemforAdd.soluongMax)
        {
            AddItemForDisble(itemforAdd,itemforAdd.soluongMax);
            soluong -= itemforAdd.soluongMax;
            AddItems(itemforAdd,soluong);
        }
        else
        {
            AddItemForDisble(itemforAdd,soluong);
        }
    }
    //kiem tra xem muc co toon tai hay k
    private List<int> KiemTraTonTaiMuc(string itemID)
    {
        List<int> indexItem = new List<int>();
        for (int i = 0; i < iventoryItems.Length; i++)
        {
            if (iventoryItems[i] != null)
            {
                if (iventoryItems[i].ID == itemID)
                {
                    indexItem.Add(i);
                }
            }
        }

        return indexItem;
    }
    //thêm mục vào ô trống
    private void AddItemForDisble(IventoryItem item, int soluong)
    {
        for (int i = 0; i < iventoryItems.Length; i++)
        {
            if (iventoryItems[i] == null)
            {
                iventoryItems[i] = item.CopyItem();
                iventoryItems[i].soluonghientai = soluong;
                IventoryUI.Intance.HienThiItemIventory(item,soluong,i);
                return;
            }
        }
    }
    //sử lý loại bỏ một mục khỏi kho đồ
    private void ElimItem(int index)
    {
        IventoryItems[index].soluonghientai--;
        if (iventoryItems[index].soluonghientai <= 0)
        {
            iventoryItems[index].soluonghientai = 0;
            iventoryItems[index] = null;
            IventoryUI.Intance.HienThiItemIventory(null,0,index);

        }
        else
        {
           IventoryUI.Intance.HienThiItemIventory(iventoryItems[index],iventoryItems[index].soluonghientai,index);
        }
    }

    public void UseItem(int index)
    {
        if (iventoryItems[index] == null)
        {
            return;
        }
        if (iventoryItems[index].UseItem())
        {
            ElimItem(index);
        }
    }

    private void SlotInterrationResdata(Seledted seledted, int Index)
    {
        switch (seledted)
        {
            case Seledted.Use:
                UseItem(Index);
                break;
            case Seledted.Equira:
                break;
            case Seledted.Remover:
                break;
        }
    }

    private void OnEnable() 
    {
        ItemSlot.EventSlot += SlotInterrationResdata;    
    }
    private void OnDisable() 
    {
        ItemSlot.EventSlot -= SlotInterrationResdata;   
    }
}
