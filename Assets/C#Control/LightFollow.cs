using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float rayDistance = 0.2f;
    void Update()
    {
        // ��ȡ��������������е�λ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10f));
        //mousePosition.z = 0;

        //int groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
        //// �������߼�⣬ʹ�ò�����
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, rayDistance, groundLayerMask);
        //if (mousePosition.y < hit.point.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2))
        //{
        //    // �������߼��������С���y����
        //    transform.position = new Vector3(mousePosition.x, hit.point.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2), transform.position.z);
        //}
        //else
        //{
        //    // ���û�м�⵽���棬����С����֮ǰ�ĸ߶�
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        //}
    }

}