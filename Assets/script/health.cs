using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // ค่าพลังชีวิตสูงสุด
    private int currentHealth;  // พลังชีวิตปัจจุบัน

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่าพลังชีวิตเริ่มต้น
    }

    // ฟังก์ชันสำหรับรับความเสียหาย
    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // ลดพลังชีวิตตามค่าความเสียหายที่รับมา
        Debug.Log("Damage taken! Current health: " + currentHealth);

        // ถ้าพลังชีวิตหมด
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ฟังก์ชันที่ทำงานเมื่อพลังชีวิตหมด
    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        // สามารถใส่โค้ดสำหรับการทำลายวัตถุ หรือทำอะไรก็ได้เมื่อพลังชีวิตหมด
        Destroy(gameObject);
    }
}