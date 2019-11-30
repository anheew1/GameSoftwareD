using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
/// <summary>
/// 안희운 개발
/// </summary>

public class GameData
{
    public string stage;
    public string score;
    public string time;

    public GameData(string stage,string score,string time)
    {
        this.stage = stage;
        this.score = score;
        this.time = time;
    }
}

public class SaveLoadManager : MonoBehaviour
{
    public static string m_time = "";
    public static string m_score = "";

    private static List<GameData> dataList = new List<GameData>();
    private static bool isLoaded = false;

    public static List<GameData> Load()
    {
        
        string filePath = Application.dataPath + "/Resources" + "/gameData.json";

        CheckAndCreateFile();
        
        string jsonString = File.ReadAllText(filePath);
        if (jsonString.Equals(""))
        {
            return dataList;
        }

        JsonData jsonData = JsonMapper.ToObject(jsonString);

        for(int i=0;i< jsonData.Count;i++)
        {
            GameData data = new GameData(jsonData[i]["stage"].ToString(), 
                jsonData[i]["score"].ToString(), jsonData[i]["time"].ToString());

            dataList.Add(data);
        }

        isLoaded = true;

        return dataList;
    }
    public List<GameData> getData()
    {
        if (isLoaded)
        {
            return dataList;
        }
        else
        {
            Debug.LogError("'getData()' must called after call 'Load()' ");
            return null;
        }
        
    }
    public static void Save(string stage,string score="",string time = "")
    {

        if(score == "")
        {
            score = m_score;
        }
        if(time == "")
        {
            time = m_time;
        }

        string filePath = Application.dataPath + "/Resources" + "/gameData.json";
        CheckAndCreateFile();

        GameData data = new GameData(stage, score, time);
        bool isDataExists = false;
        for(int i = 0; i < dataList.Count; i++)
        {
            if (data.stage.Equals(dataList[i].stage))
            {
                dataList[i] = data;
                isDataExists = true;
                break;
            }
        }
        if (!isDataExists)
        {
            dataList.Add(data);
        }
        
        JsonData jsonData = JsonMapper.ToJson(dataList);

        File.WriteAllText(filePath, jsonData.ToString());
    }
    private static void CheckAndCreateFile()
    {
        string directoryPath = Application.dataPath + "/Resources";
        string filePath = directoryPath + "/gameData.json";
        if (!File.Exists(filePath))
        {
            Directory.CreateDirectory(directoryPath);
            File.Create(filePath).Dispose();
        }
        
        
    }
}
