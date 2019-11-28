using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarUIManager : MonoBehaviour
{
    public static int Damage = 100;           //현재 생명력
    public GameObject Canvas; // 캔버스 오브젝트 선언
    public GameObject Gear; // 기어 오브젝트 선언
    public GameObject Stick; // 기어 스틱 오브젝트 선언
    public GameObject StartLabel;
    public Text CurrentStage;
    public static Text ScoreRank;
    public static GameObject FailUI;
    public static GameObject SuccessUI;
    
    public int curStage;
    public Image DamageImage; // 데미지 그래프
    public Text DamageText; // 데미지 텍스트
    public SceneChanger SceneChanger; // 씬 변경클래스

    private bool isSaved;

    void Start()
    {
        Damage = 100;                 //게임 시작될 때 현재 체력을 최대 체력으로 셋팅
        Stick = GameObject.Find("Stick"); //스틱 오브젝트 찾아서 초기화
        Stick.transform.localPosition = new Vector3(18, 29, 0); // 처음 시작시에는 기어스틱이 P에 위치
        DamageText = GameObject.Find("DamageText").GetComponent<Text>();
        DamageImage = GameObject.Find("DamageImage").GetComponent<Image>();
        StartLabel = GameObject.Find("StartLabel");
        FailUI = GameObject.Find("FailUI");
        SuccessUI = GameObject.Find("SuccessUI");
        CurrentStage = GameObject.Find("CurrentStage").GetComponent<Text>();
        ScoreRank = GameObject.Find("ScoreRank").GetComponent<Text>();
        SceneChanger = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneChanger>(); // Player tag로 SceneChanger를 찾음
        curStage = SceneManager.GetActiveScene().buildIndex - 3;
        isSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.IsStarted){
            Debug.Log(GearManager.GearStatus);
            if(GearManager.GearStatus == -1 || GearManager.GearStatus == 0) //기어 상태가 R인 경우
            {
                Stick.transform.localPosition = new Vector3(18, 0, 0); //R에 스틱을 위치시킴
            }
            if(GearManager.GearStatus == 1) //기어 상태가 D인 경우
            {
                Stick.transform.localPosition = new Vector3(18, -33, 0); //D에 스틱을 위치시킴
            }
            if(GearManager.GearStatus == 0) //기어 상태가 P인 경우(혹시 모를 오류를 방지하기 위해 넣어둠)
            {
                Stick.transform.localPosition = new Vector3(18, 29, 0); //P에 스틱을 위치시킴
            }
        }
        DamageImage.fillAmount = Damage / 100f;
        DamageText.text = string.Format("{0}/100", Damage);
        CurrentStage.text = string.Format("Stage {0}", curStage);
        if(!GameManager.IsShowUI)           //UI 화면을 내려야 할 때
        {
            FailUI.SetActive(false);
            SuccessUI.SetActive(false);
        }
        
                                                       //게임 시작했다면!
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.IsStarted = true;       //start버튼이 클릭되면 GUI 지워준다
            GameManager.StartGame();            //이제 움직일수 있도록 해준다.
            StartLabel.SetActive(false);
        } 
    }
    public static void showFailUI()
    {

        FailUI.SetActive(true);
        
    }
    public static void showSuccessUI()
    {
        string CurrentScore = "";
        int CurrentRank = ScoreManager.getRank();
        for(int i = 0; i < CurrentRank; i++)
        {
            CurrentScore += "★";
        }
        ScoreRank.text = string.Format(CurrentScore);
        SuccessUI.SetActive(true); 

    }
    void OnGUI(){      
    
     GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
     GUILayout.BeginVertical();
     GUILayout.Space(10);
     GUILayout.BeginHorizontal();
     GUILayout.FlexibleSpace();

     GUILayout.Label(TimeManager.TimeText);         //타이머 표시 
     GUILayout.Space(15);

     GUILayout.EndHorizontal();
     GUILayout.FlexibleSpace();
     GUILayout.EndVertical();
     GUILayout.EndArea();

    if (!isSaved)
            {
                SaveLoadManager.Save(curStage.ToString(), ScoreManager.getRank().ToString()); // Time 저장은 GameManager에서 이루어짐
                isSaved = true;
            }
    }
}
