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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GearStatus == 0)
            {
                GearStatus = 1;
            }
			else
                GearStatus *= -1;

		}
        if (Input.GetKeyDown(KeyCode.P))
        {
            GearStatus *= 0;
        }
    }



}
