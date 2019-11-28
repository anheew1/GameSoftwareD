using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HomeButtonClicked()
    {
        //버튼을 눌렀을 때 게임을 시작 대기상태로 만들어줌
        GameManager.IsEnded = false;           
        GameManager.IsStarted = false;
        GameManager.IsSuccess = false;    
        
        GameManager.StageLevel = 0;         //스테이지 0으로 초기화

        GameManager.IsShowUI = false;       //UI를 없애준다
    }
    public void RestartButtonClicked()
    {
        //버튼을 눌렀을 때 게임을 시작 대기상태로 만들어줌
        GameManager.IsEnded = false;        
        GameManager.IsStarted = false;
        GameManager.IsSuccess = false;      
        GameManager.IsShowUI = false;       //UI를 없애준다
    }
    public void NextButtonClicked()
    {
        //버튼을 눌렀을 때 게임을 대기상태로 만들어줌
        GameManager.IsSuccess = false;      
        GameManager.IsStarted = false;

        GameManager.IsShowUI = false;       //UI를 없애준다
    }
}
