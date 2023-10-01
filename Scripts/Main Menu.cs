using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LevelOne () {
        Debug.Log("Going to Level 1");
        SceneManager.LoadScene(1);
    }
    public void LevelTwo () {
        Debug.Log("Going to Level 2");
        SceneManager.LoadScene(2);
    }
    public void LevelThree () {
        Debug.Log("Going to Level 3");
        SceneManager.LoadScene(3);
    }
    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }
}
