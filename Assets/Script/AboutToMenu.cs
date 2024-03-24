using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutToMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void Button_Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
