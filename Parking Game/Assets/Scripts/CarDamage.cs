using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDamage : MonoBehaviour
{

    /*
    Vector3 movement;      
    SpriteRenderer spriteRenderer;      //차 파손 시 깜빡임을 위한 SpriteRenderer 선언
    bool isUnBeatTime = false;          //무적 상태
    */

    Rigidbody rigid;                                        //리지드 선언
    
    public static bool OnGoalSpot = false;                  //주차 지역 위에 있는지 
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();     //리지드 컴포넌트를 가져온다.

        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();     //SpriteRenderer 컴포넌트를 가져온다.
         
    }

    // Update is called once per frame
    void Update()
    {
    }

void OnTriggerEnter(Collider other)                         //트리거 안으로 들어갈 때
    {
        if (other.gameObject.tag == "ObstacleFix" )         //장애물을 만나게 되면
        {
            CarUIManager.Damage -= 5;                          //차량 파손

            if(CarUIManager.Damage <=0){                    //다 파손 되면 게임종료
                GameManager.EndGame();
            } 
        }
        
        if (other.gameObject.tag == "GoalSpot"){       //도착지점이라면  
            OnGoalSpot = true;    
        }
    }

void OnTriggerExit(Collider other){         //트리거를 벗어난다면!
            OnGoalSpot = false;
}

/*
//무적상태 표현
 IEnumerator UnBeatTime(){

     int countTime = 0;
     //일정시간동안 차 깜빡임
     while (countTime < 3){

         if (countTime%2 == 0){
             spriteRenderer.color = new Color32(255,255,255,90);
         }else{
             spriteRenderer.color = new Color32(255,255,255,180);
         }

         yield return new WaitForSeconds(0.2f);
         countTime++;
     }
     spriteRenderer.color = new Color32(255,255,255,255);
     isUnBeatTime = false;
     yield return null;
 }
 */
}
