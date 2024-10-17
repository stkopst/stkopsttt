using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // วาดลูกศรแสดงทิศทางการหันหน้า
        Gizmos.color = Color.green; // กำหนดสีของลูกศร
        Gizmos.DrawRay(transform.position, transform.forward * 500); // วาดลูกศรไปข้างหน้า 2 หน่วย
    }
}