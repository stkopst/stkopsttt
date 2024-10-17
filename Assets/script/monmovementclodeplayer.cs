using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMovementClosePlayer : MonoBehaviour
{
    private Transform player; // ตัวแปรสำหรับตำแหน่งของผู้เล่น
    private float dist; // ระยะห่างระหว่างมอนสเตอร์และผู้เล่น
    public float moveSpeed; // ความเร็วในการเคลื่อนที่
    public float howClose; // ระยะที่มอนสเตอร์เริ่มเคลื่อนที่ไปหาผู้เล่น

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ค้นหาผู้เล่นที่มีแท็ก "Player"
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position); // คำนวณระยะห่างระหว่างมอนสเตอร์และผู้เล่น

        if (dist <= howClose)
        {
            // มองไปที่ผู้เล่น
            Vector3 direction = (player.position - transform.position).normalized; // คำนวณทิศทางไปหาผู้เล่น
            transform.LookAt(player); // หมุนมอนสเตอร์ไปหาผู้เล่น

            // เคลื่อนที่ไปหาผู้เล่น
            transform.position += direction * moveSpeed * Time.deltaTime; // เคลื่อนที่ไปตามทิศทางที่คำนวณ
        }

        if (dist <= 1.5f)
        {
            // เพิ่มโค้ดสำหรับการโจมตีหรือการกระทำอื่นๆ ที่ต้องการที่นี่
        }
    }
}
