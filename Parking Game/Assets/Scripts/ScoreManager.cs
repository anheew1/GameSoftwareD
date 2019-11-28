using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
     public static bool[] Score = {false, false, false};        //점수

    public static int TimeLimit = 60;           //제한시간

    public static int DamageLimit;         //스테이지 별 남겨야하는 파손도

    public static bool IsReverseParking = false;   //후진 주차가 되어 있는가


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
     void Update()
    {
        
        
        Debug.Log(Score[0]);
        Debug.Log(Score[1]);
        Debug.Log(Score[2]);
    }
    public static void initRank()
    {
        for (int i = 0; i < 3; i++)
        {
            Score[i] = false;
        }
    }

    public static int getRank()
    {
        int Rank = 0;
        for (int i = 0; i < 3; i++)
        {
            if (Score[i] == true)
                Rank++;
        }
        return Rank;
    }
    
    public static void calcScore()
    {
        // 제한 시간 준수 확인
        if(TimeLimit > TimeManager.Timer)
        {
            Score[0] = true;
        }
        // 제한 데미지 준수 확인
        if(DamageLimit < CarUIManager.Damage)
        {
            Score[1] = true;
        }
        // 후진 주차 확인
        if(IsReverseParking)
        {
            Score[2] = true;
        }
    }
}
