using System.Collections;
using UnityEngine;

public class DashMechanicWithoutRigidbody : MonoBehaviour
{
    public CharacterController controller;  // คอมโพเนนต์ CharacterController ของ Player
    public float dashSpeed = 20f;           // ความเร็วในการ dash
    public float dashDuration = 0.2f;       // ระยะเวลาที่ dash จะดำเนิน
    public float dashCooldown = 1f;         // ระยะเวลารอคอยระหว่างการ dash

    private bool isDashing = false;
    private bool canDash = true;
    private Vector3 dashDirection;

    void Update()
    {
        // ตรวจจับการกดปุ่ม Q เพื่อ dash
        if (Input.GetKeyDown(KeyCode.Q) && canDash)
        {
            // เก็บทิศทางการเคลื่อนที่ในขณะที่กดปุ่ม Q (ใน Local Space ของ Player)
            Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

            if (inputDirection.magnitude == 0)
            {
                // ถ้าไม่มี input, dash ไปข้างหน้าในทิศทางที่ตัวละครหันหน้าอยู่
                dashDirection = transform.forward;
            }
            else
            {
                // ใช้ Transform.TransformDirection เพื่อแปลงจาก Local Space เป็น World Space
                dashDirection = transform.TransformDirection(inputDirection);
            }

            StartCoroutine(Dash());
        }

        // การเคลื่อนที่ปกติ ถ้าไม่ได้กำลัง dash
        if (!isDashing)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
            controller.Move(transform.TransformDirection(move) * Time.deltaTime * 5f); // ความเร็วปกติในการเดิน
        }
    }

    IEnumerator Dash()
    {
        canDash = false;  // ปิดการใช้งาน dash จนกว่าจะครบระยะ cooldown
        isDashing = true;  // กำหนดสถานะการ dash

        float startTime = Time.time;

        // ทำการ dash ในช่วงเวลาของ dashDuration
        while (Time.time < startTime + dashDuration)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            yield return null;
        }

        isDashing = false;  // สิ้นสุดสถานะการ dash

        // รอคอยช่วง cooldown ก่อนที่จะสามารถ dash ได้อีกครั้ง
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
