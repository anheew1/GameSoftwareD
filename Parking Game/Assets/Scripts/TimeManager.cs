using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float Timer;         //타이머 변수

    public static string TimeText; //시간을 표시할 Text 변수
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //IsStarted가 1이면 시작 화면 사라진 상태
        //IsEnded가 1이면 종료 화면 사라진 상태

        if (GameManager.IsStarted){                             //시작 화면 사라진 상태(게임 진행 상태)
            Timer += Time.deltaTime;                            //타이머 증가
            TimeText = Mathf.Ceil(Timer).ToString ();
        }
        if (GameManager.IsEnded || GameManager.IsSuccess){      //게임종료 또는 성공 화면이 사라진다면(게임 준비 상태)
            TimeText="";                                        //TimeText 초기화
            Timer = 0.0f;                                       //타이머 초기화
        }
            
    }
}
