using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipscene : MonoBehaviour
{
    public void gomainmenu()
    {
         SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
