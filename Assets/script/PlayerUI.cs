using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthSlider; // ตัวแปรสำหรับ Slider

    private PlayerHealth playerHealth; // อ้างอิงถึง PlayerHealth

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); // หา PlayerHealth ที่แนบอยู่
        if (healthSlider != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth; // ตั้งค่า Max Value
            healthSlider.value = playerHealth.GetHealth(); // ตั้งค่า Value เริ่มต้น
        }
    }

    void Update()
    {
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.value = playerHealth.GetHealth(); // อัปเดต Slider ตามสุขภาพปัจจุบัน
        }
    }
}