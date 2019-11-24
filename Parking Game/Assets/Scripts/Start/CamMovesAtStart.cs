using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovesAtStart : MonoBehaviour
{

    private int MAX_MODE = 2;
    private float FADETIME = 1.0f;
    private Transform tr;
    private Vector3 PlayerPos;
    private Vector3[] CamStartPoses;
    private int mode = 0;
    private bool isFade = false;
    private bool isChgMode = false;
    private float time = 0;
    private float ftime = 0;
    private CamFadeInOut CamFadeInOut;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 CamStartPos = tr.transform.position;
        CamFadeInOut = GameObject.Find("GameManager").GetComponent<CamFadeInOut>();
        CamStartPoses = new Vector3[MAX_MODE];

        CamStartPoses[0] = CamStartPos;
        CamStartPoses[1] = new Vector3(0, 0.5f, 14);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mode == 0)
        {
            transform.LookAt(PlayerPos);
            transform.Translate(Vector3.right * Time.deltaTime*2);
            time += Time.deltaTime;
            if (time > 5)
            {
                isFade = true;
            }
        }
        if (mode == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            transform.Translate(Vector3.left * Time.deltaTime * 2);
            time += Time.deltaTime;
            if (time > 6)
            {
                isFade = true;
            }
        }
        if (mode == 2)
        {

        }
        if (isFade)
        {

            // FADETIME = 2
            if(ftime < FADETIME)
            {
                CamFadeInOut.FadeIn(0.2f);
            }
            if(ftime >= FADETIME && ftime < FADETIME*2)
            {
                ChangeMode();
                isChgMode = true;
                CamFadeInOut.FadeOut(0.2f);
            }

            ftime += Time.deltaTime;


            if (ftime >= FADETIME * 2)
            {
                isFade = false;
                isChgMode = false;
                ftime = 0;
                time = 0;
            }
            
        }

        
    }

    private void ChangeMode()
    {
        if (!isChgMode)
        {
            mode += 1;
            if (mode > MAX_MODE -1)
            {
                mode = 0;
            }
            Debug.Log(mode);
            tr.transform.position = CamStartPoses[mode];
            isChgMode = true;
        }
    }

}
