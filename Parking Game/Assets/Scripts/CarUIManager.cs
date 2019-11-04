using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUIManager : MonoBehaviour
{
    public int maxHealth = 3;       //최대 생명력
    public static int health = 3;     //현재 생명력

    
    void OnGUI(){      //생명력 상태 표시 
     GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
     GUILayout.BeginVertical();
     GUILayout.Space(10);
     GUILayout.BeginHorizontal();
     GUILayout.Space(15);

    //빨간색으로 하트 표현
     string heart = "";
     for (int i=0; i<health;i++){
         heart += "<color=#ff0000>" + "♥ " + "</color>";

     }
     GUILayout.Label(heart);

     GUILayout.FlexibleSpace();
     GUILayout.EndHorizontal();
     GUILayout.FlexibleSpace();
     GUILayout.EndVertical();
     GUILayout.EndArea();
 }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;     //게임 시작될 때마다 현재 체력을 최대 체력으로 셋팅
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
