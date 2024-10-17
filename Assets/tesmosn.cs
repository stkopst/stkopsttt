using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;

    // ปรับองศาการหมุนในแกน Z
    public float zRotationOffset = 90f;

    void Update()
    {
        // คำนวณทิศทางไปยังเป้าหมาย
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // ทำให้มอนหันหน้าแค่ในแกน XZ

        if (direction != Vector3.zero)
        {
            // สร้างการหมุนไปยังเป้าหมาย
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // ปรับหมุนในแกน Z ตามค่าที่กำหนด
            targetRotation *= Quaternion.Euler(0, 0, zRotationOffset);

            // หมุนมอนสเตอร์ไปยังทิศทางที่ปรับแล้ว
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
