using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private SceneChanger SceneChanger;
    private bool isUIopen = false;
    // Start is called before the first frame update
    void Start()
    {
        SceneChanger = GameObject.Find("EventSystem").GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !isUIopen)
        {
            Image StartAlert = GameObject.Find("StartAlert").GetComponent<Image>();
            Text text = StartAlert.GetComponentInChildren<Text>();
            StartAlert.enabled = false;
            text.enabled = false;
            isUIopen = true;
        }
        
    }
    private void OnGUI()
    {
        if (!isUIopen) return;
        // Make a background box
        GUI.Box(new Rect(10, 10, 640, 300), "Select Map");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Level 0"))
        {
            SceneChanger.ChangeSceneTo("Stage00");
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Level 1"))
        {
            SceneChanger.ChangeSceneTo("Stage01");
        }

        if (GUI.Button(new Rect(20, 100, 80, 20), "Level 2"))
        {
            SceneChanger.ChangeSceneTo("Stage02");
        }
    }
}
