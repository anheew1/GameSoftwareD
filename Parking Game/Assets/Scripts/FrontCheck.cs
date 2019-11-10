using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCheck : MonoBehaviour
{
    public static bool FrontIn = false;         //차량의 앞 부분이 주차구역에 들어가 있는지 여부

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)                         //트리거 안으로 들어갈 때
    {
        
        if (other.gameObject.tag == "GoalSpot"){       //차량 앞 부분이 주차 구역에 들어갔다면  
            FrontIn = true;    
        }

    }

    void OnTriggerExit(Collider other){         //차량 앞 부분이 주차 구역에 벗어났다면
        
        FrontIn = false;

    }
}
