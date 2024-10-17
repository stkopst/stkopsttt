using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHealth : MonoBehaviour
{
    public float maxHealth = 100f; // สุขภาพสูงสุด
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // กำหนดสุขภาพเริ่มต้น
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // ลดสุขภาพ
        Debug.Log("Damage taken! Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die(); // ถ้าสุขภาพ ≤ 0 ให้เรียกฟังก์ชัน Die()
        }
    }

    void Die()
    {
        Debug.Log("Monster has died!");
        // เปลี่ยนไปยังฉากใหม่
        SceneManager.LoadScene("good end"); 
        Destroy(gameObject);
        Cursor.visible = true; // แสดงเคอร์เซอร์เมาส์
        Cursor.lockState = CursorLockMode.None; // ปลดล็อคเคอร์เซอร์จากกลางจอ
    }
}