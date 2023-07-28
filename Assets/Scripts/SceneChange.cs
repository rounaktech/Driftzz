using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string SceneName;
    public void SceneChangerXD()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
