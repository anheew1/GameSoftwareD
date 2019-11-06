using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void changeToSelectMap()
    {
        SceneManager.LoadScene("SelectMap");
    }
    public void changeToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void changeToSample()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
