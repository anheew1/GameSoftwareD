using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDamage : MonoBehaviour
{

    /*
    Vector3 movement;      
    SpriteRenderer spriteRenderer;      //차 파손 시 깜빡임을 위한 SpriteRenderer 선언
    bool isUnBeatTime = false;  //무적 상태
    */

    Rigidbody rigid;          //리지드 선언
    
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();     //리지드 컴포넌트를 가져온다.

        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();     //SpriteRenderer 컴포넌트를 가져온다.
         
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    void Die(){     //종료함수 
        
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);     //캐릭터 위치를 초기화!
        CarUIManager.Damage = 3;

    }
     
  

void OnTriggerEnter(Collider other)
    {
        
        //장애물을 만나게 되면
        if (other.gameObject.tag == "ObstacleFix" )
        {

            CarUIManager.Damage--;       //차량 파손

            if(CarUIManager.Damage <=0){     //다 파손 되면 게임종료
                Die();
            }

/*
            //무적타임이라는 bool 변수 선언 후 파손 될 때 마다 활성화 
            if(CarUIManager.Damage >0){
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
 */
        }
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
