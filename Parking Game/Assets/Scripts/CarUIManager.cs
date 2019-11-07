using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarUIManager : MonoBehaviour
{
    public int maxDamage = 3;               //최대 생명력
    public static int Damage = 3;           //현재 생명력
    public GameObject Canvas; // 캔버스 오브젝트 선언
    public GameObject Gear; // 기어 오브젝트 선언
    public GameObject Stick; // 기어 스틱 오브젝트 선언

    void Start()
    {
        Damage = maxDamage;                 //게임 시작될 때 현재 체력을 최대 체력으로 셋팅
        Stick = GameObject.Find("Stick"); //스틱 오브젝트 찾아서 초기화
        Stick.transform.localPosition = new Vector3(18, 29, 0); // 처음 시작시에는 기어스틱이 P에 위치
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R)) //기어 변경 키 눌렸는지 확인
        {
            if(GearManager.GearStatus == -1) //기어 상태가 R인 경우
            {
                Stick.transform.localPosition = new Vector3(18, 0, 0); //R에 스틱을 위치시킴
            }
            if(GearManager.GearStatus == 1) //기어 상태가 D인 경우
            {
                Stick.transform.localPosition = new Vector3(18, -33, 0); //D에 스틱을 위치시킴
            }
        }
        if (Input.GetKeyDown(KeyCode.P)) //주차 전환 키 눌렸는지 확인
        {
            if(GearManager.GearStatus == 0) //기어 상태가 P인 경우(혹시 모를 오류를 방지하기 위해 넣어둠)
            {
                Stick.transform.localPosition = new Vector3(18, 29, 0); //P에 스틱을 위치시킴
            }
        }
    }

    void OnGUI(){      

    //차량파손 상태 GUI 시작
     GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
     GUILayout.BeginVertical();
     GUILayout.Space(10);
     GUILayout.BeginHorizontal();
     GUILayout.Space(15);

    //빨간색 하트로 파손 상태 표현
     string heart = "";
     for (int i=0; i<Damage;i++){
         heart += "<color=#ff0000>" + "♥ " + "</color>";
     }
     GUILayout.Label(heart);
     
     GUILayout.FlexibleSpace();

     GUILayout.Label(TimeManager.TimeText);
     GUILayout.Space(15);

     GUILayout.EndHorizontal();
     GUILayout.FlexibleSpace();
     GUILayout.EndVertical();
     GUILayout.EndArea();
    //차량파손 상태 GUI 끝


    
    //현재 어느 스테이지에 있는지 알려주기 위한 GUI 시작
    GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      
    GUILayout.BeginHorizontal();        
    GUILayout.FlexibleSpace();
    GUILayout.BeginVertical();        
    GUILayout.FlexibleSpace();

    //스테이지는 총 3개라고 임의 가정
    if (!GameManager.IsEnded && GameManager.StageLevel < 3){
            GUILayout.Label(" Stage " + (GameManager.StageLevel));
    }
    else{
            GUILayout.Label(" Stage End");
    }

    GUILayout.Space(5);
    GUILayout.EndVertical();        
    GUILayout.FlexibleSpace();
    GUILayout.EndHorizontal();
    GUILayout.EndArea();       
    //현재 어느 스테이지에 있는지 알려주기 위한 GUI 끝
    

    
    if (!GameManager.IsStarted ){                                               //게임 시작했다면!
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작
            GUILayout.BeginHorizontal();        
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();        
            GUILayout.FlexibleSpace();

            GUILayout.Label("<color=#000000>" + "준비됐나요? " + "</color>");

            if (GUILayout.Button("<color=#000000>" + "start!"+ "</color>")){
                GameManager.IsStarted = true;       //start버튼이 클릭되면 GUI 지워준다
                GameManager.StartGame();            //이제 움직일수 있도록 해준다.
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();       
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();        
    }
    else if (GameManager.IsEnded){                  //차량이 파손 돼 게임이 종료 됐다면!
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작
            GUILayout.BeginHorizontal();        
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();       
            GUILayout.FlexibleSpace();

            GUILayout.Label("<color=#000000>" + "실패!"+ "</color>");

            //stage 0 로 돌아가기(Home))
            if (GUILayout.Button("<color=#000000>" + "Home"+ "</color>")){
                GameManager.IsEnded = false;        //UI를 없애준다
                GameManager.StageLevel = 0;         //일단 스테이지 0으로 초기화
                SceneManager.LoadScene(GameManager.StageLevel,LoadSceneMode.Single);
                GameManager.IsStarted = false;
            }

            //현재 스테이지 다시 시작하기!
            if (GUILayout.Button("<color=#000000>" + "Restart"+ "</color>")){
                GameManager.IsEnded = false;
                GameManager.StageLevel = 0;         //일단 스테이지 0으로 초기화
                SceneManager.LoadScene(GameManager.StageLevel,LoadSceneMode.Single);
                GameManager.IsStarted = false;
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();        
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();       

    }
    else if (GameManager.IsSuccess){                 //해당 스테이지의 목표 지점에 도착했다면!
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));      //시작
            GUILayout.BeginHorizontal();        
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();        
            GUILayout.FlexibleSpace();

            GUILayout.BeginHorizontal();        
            GUILayout.FlexibleSpace();
            GUILayout.Label("<color=#000000>" + "성공!"+ "</color>");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();        
            GUILayout.FlexibleSpace();

            //노란 별로 랭크 표현
            string Rank = "";
            for (int i=0; i<ScoreManager.getRank();i++){
                Rank += "<color=#ffff00>" + "★ " + "</color>";
            }
            GUILayout.Label(Rank);
            
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            //stage 0 로 돌아가기(Home)
            if (GUILayout.Button("<color=#000000>" + "Home"+ "</color>")){
                GameManager.IsSuccess = false;
                GameManager.StageLevel = 0;         //일단 스테이지 0으로 초기화
                SceneManager.LoadScene(GameManager.StageLevel,LoadSceneMode.Single);
                GameManager.IsStarted = false;
            }

            //현재 스테이지 다시 시작하기!
            if (GUILayout.Button("<color=#000000>" + "Restart"+ "</color>")){
                GameManager.IsSuccess = false;
                GameManager.StageLevel = 0;         //일단 스테이지 0으로 초기화
                SceneManager.LoadScene(GameManager.StageLevel,LoadSceneMode.Single);
                GameManager.IsStarted = false;
            }

            //다음 스테이지 다시 시작하기!
            if (GUILayout.Button("<color=#000000>" + "Next"+ "</color>")){
                GameManager.IsSuccess = false;
                GameManager.StageLevel = 0;         //일단 스테이지 0으로 초기화
                SceneManager.LoadScene(GameManager.StageLevel,LoadSceneMode.Single);
                GameManager.IsStarted = false;
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();        
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();   
            
    }
 }
}
