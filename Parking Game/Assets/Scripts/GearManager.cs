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
        if (Input.GetKeyDown(KeyCode.R)) // 기어 변경 키 입력 확인
        {
            if (GearStatus == 0) // 기어가 주차 상태일때
            {
                GearStatus = -1; // 전진으로 변경
            }
			else // 기어가 주차 상태가 아닐때
                GearStatus *= -1; // 전진, 후진 사이에서 변경

		}
        if (Input.GetKeyDown(KeyCode.P)) // 주차 키 입력 확인
        {
            GearStatus *= 0; // 주차 상태로 변경
        }
        if (GameManager.IsEnded || GameManager.IsSuccess)
        {
            GearStatus = 0;
        }
    }



}
