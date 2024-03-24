using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void Button_start()
    {
        SceneManager.LoadScene("LV1");
    }
    public void Button_Quit() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void Button_About()
    {
        SceneManager.LoadScene("About");
    }
}
