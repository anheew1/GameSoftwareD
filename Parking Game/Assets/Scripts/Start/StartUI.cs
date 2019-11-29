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
            Image title = GameObject.Find("Title").GetComponent<Image>();
            Text text = StartAlert.GetComponentInChildren<Text>();
            StartAlert.enabled = false;
            text.enabled = false;
            title.enabled = false;
            isUIopen = true;
            selectMap.SetActive(true);
        }
        if (isUIopen)
        {
            MarkStarsAndTimes();
        }
    }

    private void MarkStarsAndTimes()
    {
        if (dataList == null) return;
        for(int gi=0;gi< dataList.Count;gi++)
        {
            GameData gameData = dataList[gi];
            GameObject stageLabel;
            if (gameData.stage.Length > 1) {
                stageLabel = GameObject.Find("Stage" + gameData.stage);
            }
            else
            {
                stageLabel = GameObject.Find("Stage0" + gameData.stage);
            }

            Image[] stars = stageLabel.transform.Find("Stars").GetComponentsInChildren<Image>();
            int score = int.Parse(gameData.score);
            for(int i =0; i < score; i++)
            {
                stars[i].color = new Color(255, 255, 0, 255); // Yellow
            }

            Text timeText = stageLabel.transform.Find("Time").GetComponent<Text>();
            float time = float.Parse(gameData.time);
            int minute = (int) time / 60;
            time -= 60 * minute;
            timeText.text = minute + ":" + time.ToString("0.00");

        }
    }
    
}
