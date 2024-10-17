using UnityEngine;

public class AIIController : MonoBehaviour
{
    public Transform player; // อ้างอิงไปยังตำแหน่งของผู้เล่น
    public float detectionRange = 10f; // ระยะที่ AI สามารถตรวจจับผู้เล่น

    void OnDrawGizmos()
    {
        // ตั้งค่าสีของ Gizmos
        Gizmos.color = Color.red;

        // วาดเส้นวงกลมที่แสดงระยะตรวจจับ
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // วาดเส้นจาก AI ไปยังผู้เล่น
        if (player != null)
        {
            Gizmos.color = Color.green; // เปลี่ยนสีเป็นเขียว
            Gizmos.DrawLine(transform.position, player.position);
        }
    }

    void Update()
    {
        // โค้ดอื่น ๆ สำหรับ AI
    }
}