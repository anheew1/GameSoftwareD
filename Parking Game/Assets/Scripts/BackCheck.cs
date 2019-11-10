using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCheck : MonoBehaviour
{

    public static bool BackIn = false;             //차량의 뒷 부분이 주차구역에 들어가 있는지 여부


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)                         
    {
        
        if (other.gameObject.tag == "GoalSpot" ){       //차량 뒷 부분이 주차 구역에 들어갔다면  
            BackIn = true;
            if (!FrontCheck.FrontIn){                   //후진 주차라면!
                ScoreManager.IsReverseParking = true;  
            }
              
        }

    }

    void OnTriggerExit(Collider other){         //트리거를 벗어난다면!
        BackIn = false;                         //차량 뒷 부분이 주차 구역에서 벗어났다면
        if (!FrontCheck.FrontIn){               
            ScoreManager.IsReverseParking = false;
        }

    }


}
