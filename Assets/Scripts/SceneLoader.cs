using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentSceneName);
    }
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
