using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private SceneChanger SceneChanger;
    private List<GameData> dataList;
    private GameObject selectMap;
    private bool isUIopen = false;
    // Start is called before the first frame update
    void Start()
    {
        SceneChanger = GameObject.Find("EventSystem").GetComponent<SceneChanger>();
        selectMap = GameObject.Find("SelectMap");
        selectMap.SetActive(false);

        dataList = SaveLoadManager.Load();
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
            selectMap.SetActive(true);
        }
        
    }
    
}
