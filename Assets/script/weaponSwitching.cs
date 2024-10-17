using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> weapons;  // ลิสต์ของอาวุธที่สามารถสลับได้
    private int selectedWeaponIndex = 0;  // อาวุธที่ถูกเลือกอยู่ตอนนี้

    void Start()
    {
        SelectWeapon();  // เริ่มต้นโดยการเลือกอาวุธที่ index 0
    }

    void Update()
    {
        // การเลือกอาวุธผ่านปุ่ม 1, 2 เป็นต้น
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeaponIndex = 0;  // เลือกอาวุธที่ตำแหน่งแรก (0)
            SelectWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeaponIndex = 1;  // เลือกอาวุธที่ตำแหน่งที่สอง (1)
            SelectWeapon();
        }

        // การเลือกอาวุธผ่าน Scroll Wheel ของเมาส์
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            // เลื่อน Scroll ขึ้น
            selectedWeaponIndex = (selectedWeaponIndex + 1) % weapons.Count;  // เลือกอาวุธถัดไป
            SelectWeapon();
        }
        else if (scroll < 0f)
        {
            // เลื่อน Scroll ลง
            selectedWeaponIndex = (selectedWeaponIndex - 1 + weapons.Count) % weapons.Count;  // เลือกอาวุธก่อนหน้า
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        // ปิดการแสดงผลอาวุธทุกชิ้น
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == selectedWeaponIndex);  // เปิดการแสดงผลเฉพาะอาวุธที่ถูกเลือก
        }
    }
}
