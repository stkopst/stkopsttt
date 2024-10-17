using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับการโหลดฉากใหม่
using System.Collections; // ใช้สำหรับ Coroutine

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // สุขภาพสูงสุด
    private float currentHealth;

    private Coroutine healingCoroutine; // สำหรับ Coroutine ฟื้นฟูเลือด

    void Start()
    {
        currentHealth = maxHealth; // เริ่มต้นค่าความสุขภาพ
        StartHealing(); // เริ่มฟื้นฟูเลือด
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Health: " + currentHealth); // แสดงค่าความสุขภาพใน Console
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Cursor.visible = true; // แสดงเคอร์เซอร์เมาส์
        Cursor.lockState = CursorLockMode.None; // ปลดล็อคเคอร์เซอร์
        Debug.Log("Player has died!");
        // เปลี่ยนไปยังฉากเมนู (เช่น "MainMenu")
        SceneManager.LoadScene("main menu");
    }

    public float GetHealth()
    {
        return currentHealth; // คืนค่าความสุขภาพปัจจุบัน
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // ตรวจสอบไม่ให้เกินค่าสูงสุด
        }
    }

    private void StartHealing()
    {
        if (healingCoroutine != null)
        {
            StopCoroutine(healingCoroutine); // หยุด Coroutine ก่อนหน้านี้ถ้ามี
        }
        healingCoroutine = StartCoroutine(HealOverTime());
    }

    private IEnumerator HealOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // รอ 5 วินาที
            Heal(5f); // ฟื้นฟูเลือด 5 HP
            Debug.Log("Player healed 5 HP: " + currentHealth);
        }
    }
}