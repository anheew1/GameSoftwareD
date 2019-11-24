using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    private SceneChanger SceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        SceneChanger = GameObject.Find("EventSystem").GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneChanger.ChangeToSelectMap();
        }
        
    }
}
