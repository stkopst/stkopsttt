using UnityEngine;

public class monani : MonoBehaviour
{
    private Animator animator; // ตัวแปรสำหรับ Animator
    public float speed = 3f;   // ความเร็วในการเคลื่อนที่
    private Transform target;   // ตำแหน่งเป้าหมาย (เช่น ผู้เล่น)

    void Start()
    {
        // เชื่อมต่อ Animator Component
        animator = GetComponent<Animator>();

        // กำหนดให้ target เป็นตำแหน่งผู้เล่น (หา GameObject ที่ชื่อ Player)
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // ตรวจสอบระยะห่างระหว่างมอนสเตอร์และผู้เล่น
        float distance = Vector3.Distance(transform.position, target.position);

        // ถ้าห่างจากผู้เล่นน้อยกว่าระยะที่กำหนดให้มอนสเตอร์วิ่ง
        if (distance < 10f) // คุณสามารถปรับระยะนี้ได้
        {
            animator.SetBool("isRunning", true);
            // มอนสเตอร์เคลื่อนที่ไปยังผู้เล่น
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // หากอยู่ใกล้ผู้เล่นมากพอ (ระยะที่ต้องการโจมตี)
            if (distance < 1.5f) // ปรับระยะโจมตีตามต้องการ
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}