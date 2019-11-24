using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{

    public float handleangle = 0.0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0){
         handleangle += 200f * Time.deltaTime;
      }
      if (Input.GetAxis("Horizontal") < 0){
         handleangle -= 200f * Time.deltaTime;
      }
      if (handleangle >= 540f){
         handleangle = 540f;
      }
      if (handleangle <= -540f){
         handleangle = -540f;
      }
        if (handleangle < 540.0f && handleangle > -540.0f){
            this.transform.rotation = Quaternion.Euler(0.0f,0.0f,-handleangle );
        }

        
        
    }
}