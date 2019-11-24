using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveAtStart : MonoBehaviour
{
    private Transform tr;
    private Vector3 PlayerPos;
    private Vector3[] CamStartPoses;
    private int mode = 0;
    private int MAX_MODE = 3;
    private bool isFade = false;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 CamStartPos = tr.transform.position;
        CamStartPoses = new Vector3[5];
        CamStartPoses[0] = CamStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0 && !isFade)
        {
            transform.LookAt(PlayerPos);
            transform.Translate(Vector3.right * Time.deltaTime);
            time += Time.deltaTime;
            if(time > 10)
            {
                Debug.Log("Count over 10");
                time = 0;
            }
        }
    }

    private void ChangeMode()
    {
        mode += 1;
        if(mode > MAX_MODE)
        {
            mode = 0;
        }


    }

    private void FadeIn()
    {

    }

    void FadeOut()
    {

    }

}
