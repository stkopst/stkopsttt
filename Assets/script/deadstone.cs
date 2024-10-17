using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float damageAmount = 10f; // จำนวนความเสียหายที่วัตถุทำ

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าผู้เล่นชนวัตถุนี้หรือไม่
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}