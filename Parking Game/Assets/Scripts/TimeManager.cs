using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timetext;      //시간을 표시할 Text 변수
    public static float timer;         //타이머 변수

    // Start is called before the first frame update
    void Start()
    {
        timetext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //IsStarted가 1이면 시작 화면 사라진 상태
        //IsEnded가 1이면 종료 화면 사라진 상태
        if (GameManager.IsStarted){                             //시작 화면 사라진 상태
            timer += Time.deltaTime;                            //시간 증가
            timetext.text = Mathf.Ceil(timer).ToString ();      //시간 정수로 표현
        }
        if (GameManager.IsEnded || GameManager.IsSuccess){      //게임종료 또는 성공 화면이 사라진다면
            timetext.text="";                                   //text 초기화
            timer = 0.0f;                                       //시간 초기화
        }
            
    }
}
