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

    public void ChangeToNext()
    {
        string curSceneName = SceneManager.GetActiveScene().name;
        if (curSceneName == "SampleScene")
        {
            SceneManager.LoadScene("Stage00");
        }
        else if (curSceneName.Contains("Stage"))
        {

            int stageNum = int.Parse(curSceneName.Substring(5));
            stageNum += 1;
            string nextStageName = "";
            if(stageNum < 10)
            {
                nextStageName = "Stage" + "0" + stageNum;
            }
            else
            {
                nextStageName = "Stage" + stageNum;
            }

            SceneManager.LoadScene(nextStageName);

            Debug.Log("Try to Load scene :" + nextStageName);
        }
        else
        {
            Debug.Log("ChangeToNext function is only activated " +
                "if activated scene is stage of SampleScene");
        }
    }
    public void RestartScene()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex);
    }
}
