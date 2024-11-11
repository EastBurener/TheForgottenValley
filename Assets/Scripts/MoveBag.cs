using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 因为实现背包的移动，所以增加IDragHandler事件
/// 移动背包移动的是他的中心点，这样看起来平滑并且不会一下子移动很远
/// </summary>
public class MoveBag : MonoBehaviour,IDragHandler
{
    private RectTransform startRect;

    private void Awake()
    {
        startRect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        startRect.anchoredPosition += eventData.delta;//移动中心点
    }
}

