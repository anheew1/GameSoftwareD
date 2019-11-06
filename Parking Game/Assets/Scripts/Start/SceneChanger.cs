using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToSelectMap()
    {
        SceneManager.LoadScene("SelectMap");
    }
    public void ChangeToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void ChangeSceneTo(string sceneName)
    {   
        SceneManager.LoadScene(sceneName);
    }
}
