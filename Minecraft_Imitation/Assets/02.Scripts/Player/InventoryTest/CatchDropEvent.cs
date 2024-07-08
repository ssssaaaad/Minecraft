using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatchDropEvent : MonoBehaviour, IDropHandler
{
    ItemImage previous;
    ItemImage following;
    bool checkKind;
    int totalCnt;
    int exceededCnt;
    int maxCnt = 64;

    public void OnDrop(PointerEventData eventData)
    {
        following = DragItemEvent.dragItemImage;
        previous = GetComponentInChildren<ItemImage>();
        if (transform.childCount == 0) // 그 칸에 아무것도 없으면 자리만 바꿔줌.
        {
            DragItemEvent.dragingItem.transform.SetParent(transform);
            DragItemEvent.dragingItem.transform.localPosition = Vector3.zero;
        }
        else // 그 칸에 뭐가 있으면
        {
            CalculateCount(previous, following);
        }
    }


    bool CheckKind(ItemImage previous, ItemImage following) // 종류 같은지 검사.
    {
        if (previous.particleKind == following.particleKind)
        {
            return checkKind = true;
        }
        else
        {
            return checkKind = false;
        }
    }

    void CalculateCount(ItemImage previous, ItemImage following) // 카운트 계산.
    {
        if (checkKind) // 종류가 같다면. //0708 진행중.
        {
            if (previous.count + following.count <= maxCnt) // maxCnt == 64
            {
                // 우선 숫자 증가시켜.
                previous.ChangeItemCnt(following.count); // 주운 개수만큼 증가.

            }
            else // 초과할경우
            {
                print("초과함");
                totalCnt = previous.count + following.count;
                exceededCnt = totalCnt - maxCnt; // 초과양.
                previous.ChangeItemCnt(maxCnt - previous.count);
                following.ChangeItemCnt(exceededCnt - following.count);

            }
        }
        else // 종류가 다르다면 위치만 서로 바꿔준다.
        {
            DragItemEvent dragItemCs = following.GetComponent<DragItemEvent>();
            dragItemCs.SwitchPos(previous);
            DragItemEvent.dragingItem.transform.SetParent(transform);
            DragItemEvent.dragingItem.transform.localPosition = Vector3.zero;
        }
    }


}
