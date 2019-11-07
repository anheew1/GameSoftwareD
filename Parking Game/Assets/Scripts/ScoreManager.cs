using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
     public static bool[] Score = {false, false, false};        //점수

    public int TimeLimit;           //제한시간

    public int DamageLimit;         //스테이지 별 남겨야하는 파손도

    public bool IsReverseParking;   //후진 주차가 되어 있는가

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
     void Update()
    {
        //스테이지가 0일때 성공하면
        if (GameManager.IsSuccess && GameManager.StageLevel == 0)
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


}
