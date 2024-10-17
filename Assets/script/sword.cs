using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour
{
    public Camera playerCamera; // กล้องของผู้เล่น
    public float fireRate = 0.5f; // อัตราการยิง
    public float bulletRange = 100f; // ระยะทางของกระสุน
    public int bulletDamage = 10; // ความเสียหายของกระสุน
    public LayerMask hitLayer; // เลเยอร์ที่กระสุนจะตรวจสอบการชน

    public GameObject muzzleFlashEffect; // เอฟเฟกต์การยิง
    public GameObject hitEffect; // เอฟเฟกต์เมื่อกระสุนชน

    private float nextFireTime = 0f;

    private Animator animator; // ตัวแปรสำหรับ Animator

    void Awake()
    {
        // หา Animator component จาก GameObject นี้
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ตรวจสอบการคลิกเมาส์ซ้ายเพื่อยิง
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // กำหนดเวลายิงครั้งถัดไป
            Shoot();
        }
    }

    void Shoot()
    {
        // แสดงเอฟเฟกต์การยิงที่ปากกระบอกปืน (ถ้ามี)
        if (muzzleFlashEffect != null)
        {
            Instantiate(muzzleFlashEffect, transform.position, transform.rotation);
        }

        // แสดงแอนิเมชันการยิง
        if (animator != null)
        {
            animator.SetTrigger("slash"); // ใช้ Trigger ที่ชื่อว่า "slash" เพื่อเล่นแอนิเมชัน
        }

        // สร้าง Raycast จากกล้องไปในทิศทางที่กล้องมอง (กลางหน้าจอ)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // จุดกึ่งกลางหน้าจอ (0.5, 0.5)
        if (Physics.Raycast(ray, out RaycastHit hit, bulletRange, hitLayer))
        {
            // ตรวจสอบว่ากระสุนโดนอะไร
            Debug.Log("Hit: " + hit.transform.name);

            // แสดงเอฟเฟกต์เมื่อกระสุนโดนเป้าหมาย (ถ้ามี)
            if (hitEffect != null)
            {
                Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            // ถ้าโดนวัตถุที่มีคอมโพเนนต์ Health
            if (hit.transform.TryGetComponent<Health>(out Health targetHealth))
            {
                targetHealth.TakeDamage(bulletDamage);
            }

            // ตรวจสอบว่ากระสุนโดนวัตถุที่มีคอมโพเนนต์ bossHealth หรือไม่
            if (hit.transform.TryGetComponent<bossHealth>(out bossHealth bossTargetHealth))
            {
                bossTargetHealth.TakeDamage(bulletDamage);
            }
        }
    }
}