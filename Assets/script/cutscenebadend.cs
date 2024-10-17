using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าตัวละครที่ชนคือ Player
        {
            SceneManager.LoadScene("bad end"); // เปลี่ยนชื่อเป็นชื่อฉากที่คุณต้องการ
        }
    }
}