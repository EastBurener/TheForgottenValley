using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/// <summary>
/// 为了实现点击物品跟随鼠标移动，所以它添加上IBeginDragHandler,IDragHandler,IEndDragHandler三个事件
/// 注意添加这三个接口时添加头文件：using UnityEngine.EventSystems;
/// </summary>
public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    /// <summary>
    /// 记录原来的父级位置，因为可能进行物品交换位置，所以记录原先的父级
    /// 因为我们的层级关系是有两层的，该代码是在Item身上。
    /// Item层级关系：Slot(Clone)->Item,我们改变Item的位置所以找到Slot（Clone）
    /// </summary>
    public Transform startParent;
    public InventoryBag PlayerBag;//玩家的背包
    private int startID;//当前初始的序号，点击物品的刚开始序号，因为交换挪位置，所以也要记录下来
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        startParent = transform.parent;
        startID = startParent.GetComponent<Slot>().slotId;
        transform.SetParent(transform.parent.parent);//我们点击物品后我们要脱离原来的父物体，这样物品就不会被装备栏覆盖掉不显示了
        transform.position = eventData.position;//物品跟随鼠标的位置
        GetComponent<CanvasGroup>().blocksRaycasts = false;//防止拖拽的物体挡住鼠标的射线检测
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)//这里判断鼠标拖动物体是否到场景中，如果在场景的话就直接返回原来的位置，不进行判断的话会报错
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage")//判断下面物体的名字是：ItemImage 那么互换位置
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);//这里两个parent是因为第一时间检测到的是ItemImage，我们要找的是Slot，所以是两个parent
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //bagList的物品存储位置改变，我们要改变背包里面的顺序，这样才不会挪动了位置不会保存，下面这里两个Item的进行调换
                var temp = PlayerBag.bagList[startID];
                PlayerBag.bagList[startID] =
                    PlayerBag.bagList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotId];
                PlayerBag.bagList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotId] = temp;
            
            
                //进行交换位置，改变父子级别
                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = startParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(startParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;//当操作进行完后要把他设置成true，可以进行以后的射线检测
                return;
            }
            
            //下面的逻辑和上面的大致相同
            //这里是判断移动的位置是空位置的话就简单地移动位置即可，不用交换的操作
            if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                PlayerBag.bagList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotId] = PlayerBag
                    .bagList[startID];
        
                //这里的判断是当你移动该物品，最后又移动到原来的位置，如果移动两者前后序号一样就不用操作，如果不一样就设置原来的为空
                if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotId!=startID)
                    PlayerBag.bagList[startID] = null;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        
        
        //其他任何位置都设置成原来的位置
        transform.SetParent(startParent);
        transform.position = startParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
