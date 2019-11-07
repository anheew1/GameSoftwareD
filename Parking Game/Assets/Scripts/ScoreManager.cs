using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score;

    public int TimeLimit;

    public int DamageLimit;

    public bool IsReverseParking;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //스테이지가 0일때 성공하면
        if (GameManager.IsSuccess && GameManager.StageLevel == 0)
        {
            // 제한 시간 준수 확인
            if(TimeLimit > TimeManager.timer)
            {
                Score += 1;
            }
            // 제한 데미지 준수 확인
            if(DamageLimit < CarUIManager.Damage)
            {
                Score += 1;
            }
            // 후진 주차 확인
            if(IsReverseParking)
            {
                Score += 1;
            }
        }

    }

}
