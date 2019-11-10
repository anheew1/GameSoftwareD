using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsStarted = false;         //시작지점인지!
    public static bool IsEnded = false;         //종료지점인지!
    public static bool IsSuccess = false;       //목표 지점에 도착했는지!
    public static int StageLevel = 0;           //Scene index 를 저장할 변수


    /*
    Vector3 StartingPos;            //시작위치
    Quaternion StartingRotate;      //시작로테이트
    */

    void Awake(){
        Time.timeScale = 0f;               //씬 로드 후 정지 시킨다.
    }
    
    public static void StartGame(){       //게임시작하면!
        Time.timeScale = 1f;               //게임진행
    }

    public static void EndGame(){           //체력이 다 달아서 게임이 종료되면!
        
        Time.timeScale = 0f;
        IsEnded = true;                 //ui 불러내기
        
    }
    public static void PassGame(){          //목표 지점에 도착해서 게임이 종료 됐다면
    
        Time.timeScale = 0f;
        IsSuccess = true;                   //ui 불러내기

    }

}
