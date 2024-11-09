using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float rayDistance = 0.2f;
    void Update()
    {
        // 获取鼠标在世界坐标中的位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10f));
        //mousePosition.z = 0;

        //int groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
        //// 进行射线检测，使用层掩码
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, rayDistance, groundLayerMask);
        //if (mousePosition.y < hit.point.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2))
        //{
        //    // 根据射线检测结果调整小球的y坐标
        //    transform.position = new Vector3(mousePosition.x, hit.point.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2), transform.position.z);
        //}
        //else
        //{
        //    // 如果没有检测到地面，保持小球在之前的高度
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        //}
    }

}