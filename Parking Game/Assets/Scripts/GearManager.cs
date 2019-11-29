using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int GearStatus = 0;

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.IsStarted){
            if (Input.GetKeyDown(KeyCode.R)) // 기어 변경 키 입력 확인
            {
                Debug.Log(23);
                if (GearStatus == 0) // 기어가 주차 상태일때
                {
                    GearStatus = -1; // 후진으로 변경
                }
                else // 기어가 주차 상태가 아닐때
                    GearStatus *= -1; // 전진, 후진 사이에서 변경

            }

            if (Input.GetKeyDown(KeyCode.P)) // 주차 키 입력 확인
            {
                GameManager.IsShowUI = true;
                GearStatus *= 0;            // 주차 상태로 변경

                if (CarDamage.OnGoalSpot ){       //주차구역 안에 있다면
                    if (FrontCheck.FrontIn == true && BackCheck.BackIn == true){    //차량 전체가 들어갔을 경우
                        ScoreManager.calcScore();
                        int curStage = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 2;
                        SaveLoadManager.Save(curStage.ToString(),ScoreManager.getRank().ToString(),TimeManager.Timer.ToString());
                        GameManager.PassGame();     //주차완료
                        CarUIManager.showSuccessUI();
                    }
                    else{                                      //차량 전체가 안 들어갔을 경우
                        CarUIManager.showFailUI();
                        GameManager.EndGame();     //주차실패


                    }

                }else{                         //주차구역 밖에 있다면
                    CarUIManager.showFailUI();
                    GameManager.EndGame();     //주차실패
                    
                }
                FrontCheck.FrontIn = false;
                BackCheck.BackIn = false;
                ScoreManager.initRank();
                
            }
        }
        
        if (GameManager.IsEnded || GameManager.IsSuccess)   
        {
            GearStatus = 0;
        }
    }



}
