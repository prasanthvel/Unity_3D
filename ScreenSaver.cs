/*
I have use DOTween for the motion of the text in canvas
and Lean Touch for support multiple input types
This Script support both single monitor and Dual monitor games
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Lean.Touch;
using DG.Tweening;



public class ScreenSaver : MonoBehaviour
{

    public bool IsScreenSaverOn = false;
    public float screenSaver_timer = 120f; // change from the editor 
    public GameObject screenSaverObj_primary; // screensaver panel for priamry monitor
    //public GameObject screenSaverObj_secondary; // screensaver panel for secondary monitor
    public RawImage screenSaver_img_primary;
    //public RawImage screenSaver_img_seconday;
    public DOTweenPath _anim_primary_Screen; // select the object with the DOTween Path animation enable for primary monitor
   // public DOTweenPath _anim_sec_Screen; // select the object with the DOTween Path animation enable for secondary monitor
   

    private void OnDisable()
    {
        LeanTouch.OnFingerDown -= OnFingerDown;
        LeanTouch.OnFingerUp -= OnFingerUp;
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerDown += OnFingerDown;
        LeanTouch.OnFingerUp += OnFingerUp;
    }



    public void OnFingerDown(LeanFinger finger)
    {
        screenSaver_timer = 120; // to avoid sudden screensaver visable on figer touch / input
    }

    public void OnFingerUp(LeanFinger finger)
    {
        screenSaver_timer = 120; // start the countdown on last finger touch / input 

        if (GlobalData.Instance.currScreen == GlobalData.AppScreen.SCREENSAVER)
        {
            screenSaverObj_primary.SetActive(false); // hide the screensaver
           // screenSaverObj_secondary.SetActive(false); // hide the screensaver
            IsScreenSaverOn = false;
            // LOAD HOME PAGE OF THE GAME    
          

        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // start countDown

        if (!IsScreenSaverOn)
        {
            screenSaver_timer -= Time.deltaTime;
            _anim_primary_Screen.DOPause(); // activate DOTween Path animation
          //_anim_sec_Screen.DOPause(); // activate DOTween Path animation
        }

        if (screenSaver_timer < 0)
        {
            // before showing the screensaver hide the current screen on the exhibit if needed

            screenSaverObj_primary.SetActive(true); // make screensaver visable on timeleft
           // screenSaverObj_secondary.SetActive(true); // make screensaver visable on timeleft
            IsScreenSaverOn = true; // to avoid time decreasing in Update()

            _anim_primary_Screen.DOPlay(); // activate DOTween Path animation
           // _anim_sec_Screen.DOPlay(); // activate DOTween Path animation
        }
    }
}
