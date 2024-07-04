using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour
{
    public static InventoryPopup instance;
    public GameObject[] quickSlot = new GameObject[0];
    public GameObject[] inven = new GameObject[0];
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSameCnt(int slotNum, int changeToValue)
    {
        ItemImage pop = quickSlot[slotNum].GetComponentInChildren<ItemImage>();
        pop.ChangeItemCnt(-pop.count + changeToValue); 
    }


    public void SetItemPositionInQuickSlot(GameObject item, int i)
    {
        item.transform.parent = quickSlot[i].transform;
        item.transform.localPosition = Vector3.zero;
        item.transform.localScale = Vector3.one;
    }

    public void SetItemPosInInven(GameObject item) // Quick슬롯에 자리 없을때 들어오게.
    {
        for(int i =0; i< inven.Length; i++)
        {
            if (inven[i].transform.childCount == 0)
            {
                item.transform.parent = inven[i].transform;
                item.transform.localPosition = Vector3.zero;
                item.transform.localScale = Vector3.one;
                return;
            }
        }
    }

}
