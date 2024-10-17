using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnKeyPress : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true; // แสดงเคอร์เซอร์เมาส์
        Cursor.lockState = CursorLockMode.None; // ปลดล็อคเคอร์เซอร์จากกลางจอ
        
        if (Input.GetKeyDown(KeyCode.Return)) // ตรวจสอบว่ากดปุ่ม Enter
        {
            SceneManager.LoadScene("main menu"); // เปลี่ยนชื่อเป็นชื่อฉากที่คุณต้องการ
        }
    }
}