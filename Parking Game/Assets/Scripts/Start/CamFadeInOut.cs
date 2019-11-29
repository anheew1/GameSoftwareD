using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFadeInOut : MonoBehaviour
{
    public UnityEngine.UI.Image fadeImage;
    public float alpha = 0.1f;
    public bool isActivte = false;
    public bool isFadeIn = true;
   

    private float time = 0;
    private float fade = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (isActivte)
        {
            time += Time.deltaTime;
            if (isFadeIn)
            {
                OperateFadeIn();
            }
            else
            {
                OperateFadeOut();
            }
        }

    }
    public void FadeIn(float alpha = 0.1f)
    {
        isActivte = true;
        isFadeIn = true;
        this.alpha = alpha;
    }
    public void FadeOut(float alpha = 0.1f)
    {
        isActivte = true;
        isFadeIn = false;
        this.alpha = alpha;
    }
    void OperateFadeIn()
    {
        if (fade < 1.0f && time >= 0.1f)
        {
            fade += alpha;
            fadeImage.color = new Color(0, 0, 0, fade);
            time = 0;
        }
    }
    void OperateFadeOut()
    {
        if (fade > 0.0f && time >= 0.1f)
        {
            fade -= alpha;
            fadeImage.color = new Color(0, 0, 0, fade);
            time = 0;
        }
    }
}
