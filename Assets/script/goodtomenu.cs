using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goodtomenu : MonoBehaviour
{
    public void goodtomain()
    {
        Cursor.visible = true; // แสดงเคอร์เซอร์เมาส์
        Cursor.lockState = CursorLockMode.None; // ปลดล็อคเคอร์เซอร์จากกลางจอ
         SceneManager.LoadSceneAsync(1);
    }
   
    }

