using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.LowLevel;

public class DualSenseController : MonoBehaviour
{


    [SerializeField]
    public DualSenseGamepadHID _DualSenseGamepadHID = null;

    [SerializeField]
    private bool hasController = false;

    [SerializeField] private bool autofind = true;


    [SerializeField] private float autoFindTimer = 1f;
    [SerializeField] private float logTimer = 1f;

    private float _logTimer = 0f;
    private float findTimer = 0f;
    private Color lastColor;
    [SerializeField] private bool logging = true;

    [SerializeField] private float lowFreq = 0f;
    [SerializeField] private float hiFreq = 0f;


    #region Lightbar

    public enum LightBarMode
    {
        STATIC,
        LERP,
        FLASH,
        ANIMATION
    }

    private enum LightBarAnimation
    {
        POLICE,
        LOW_HEALTH
    }
    [SerializeField]
    private LightBarMode m_LightBarMode = LightBarMode.STATIC;

    [SerializeField]
    private LightBarAnimation lightBarAnimation = LightBarAnimation.POLICE;

    [SerializeField] private Color staticColor = Color.cyan;


    [SerializeField]
    private float lerpDuration = 1.5f;
    private Color currentLerpColor;
    private Color animationColor;
    [SerializeField]
    private Color lerpFromColor;
    [SerializeField]
    private Color lerpToColor;
    private float lerpTimer = 0f;
    
    private bool lerpDirection = true;



    [SerializeField]
    private float flashTime = 0.25f;
    private float flashTimer = 0f;
    [SerializeField]
    private Color flashColorOne;
    [SerializeField]
    private Color flashColorTwo;



    [SerializeField]
    private float policeTime = 0.35f;
    [SerializeField]
    private float lowHealthTime = 0.3f;

    private float animationTimer = 0f;
    private Color flashColor;


    #endregion

    private void DSLog(string msg)
    {
        if (logging)
        {
            Debug.Log(msg);
        }
    }

    public bool IsControllerPresent { get { return hasController; } }

    public void SetLightColor(Color color)
    {
        if(color != lastColor)
        {
           // DSLog("changed!");
            lastColor = color;
            _DualSenseGamepadHID.SetLightBarColor(color);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
      
       tryFindController();


    }

   
    // Update is called once per frame
    void Update()
    {
        hasController = checkControllerThere();

        if (!hasController)
        {
            findTimer += Time.deltaTime;

            if (!autofind) return;

            if (findTimer >= autoFindTimer)
            {
                DSLog("Searching for Dualsense!");

                hasController = tryFindController();
                findTimer = 0;
                
            }
        }
        else
        {
           refresh();
        }

    }

    private bool tryFindController()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Gamepad current = Gamepad.all[i];
            Debug.Log(current);
            try
            {
                _DualSenseGamepadHID = (DualSenseGamepadHID)current;
                _DualSenseGamepadHID.MakeCurrent();

                DSLog("FOUND!");
                DSLog("<color=cyan> Controller Connected! </color>");
                SetLightColor(staticColor);
                return true;
                break;
            }
            catch
            {
                DSLog("Not a DS!");
            }
        }

        DSLog("<color=orange>Couldnt find DS! </color>");
        return false;

    }

    private bool checkControllerThere()
    {
        if (_DualSenseGamepadHID == null) { DSLog("<color=orange>DS wasn't initialized! </color>"); lastColor = Color.black; return false; };

        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            //  DSLog(Gamepad.all[i].deviceId);
            if (Gamepad.all[i].deviceId == _DualSenseGamepadHID.deviceId) {
               // refresh();
                return true;
            }
        }
        // DSLog("<color=orange>DS not present! </color>");
        lastColor = Color.black;
        return false;
    }



    private void refresh()
    {
       _refreshLightBar();
        // _DualSenseGamepadHID.SetMotorSpeeds(lowFreq, hiFreq);
        _logTimer += Time.deltaTime;

        if (_logTimer >= logTimer)
        {
            DSLog("<color=red>R2: " + _DualSenseGamepadHID.R2.value + "</color>");
            _logTimer = 0;
        }
    }


    private void _refreshLightBar()
    {
        switch (m_LightBarMode) {
            case LightBarMode.STATIC:
                SetLightColor(staticColor);
                break;
            case LightBarMode.LERP:
                lerpColors();
                SetLightColor(currentLerpColor);
                break;

            case LightBarMode.FLASH:
                flashColors();
                SetLightColor(flashColor);
                break;
            case LightBarMode.ANIMATION:
                controlAnimation();
                SetLightColor(animationColor);
                break;


        }
    }


    private void lerpColors()
    {
        if (lerpDirection)
            lerpTimer += Time.deltaTime / lerpDuration;
        else
            lerpTimer -= Time.deltaTime / lerpDuration;

        lerpTimer = Mathf.Clamp01(lerpTimer);
        currentLerpColor = Color.Lerp(lerpFromColor, lerpToColor, lerpTimer);

        if (lerpTimer >= 1f)
            lerpDirection = false;
        else if (lerpTimer <= 0f)
            lerpDirection = true;
    }

    private void flashColors()
    {
        flashTimer += Time.deltaTime;
        Debug.Log(flashTimer);
        if(flashTimer < flashTime)
        {
            flashColor = flashColorOne;
        }
        else if (flashTimer > (flashTime * 2))
        {
            flashTimer = 0f;
        }
        else
        {
            flashColor = flashColorTwo;
        }

    }


        private void controlAnimation()
    {
        animationTimer += Time.deltaTime;

        switch (lightBarAnimation) {
            case LightBarAnimation.POLICE:
                if (animationTimer < policeTime)
                    animationColor = Color.red;
                else if (animationTimer > policeTime * 2)
                {
                    animationTimer = 0f;
                }
                else animationColor = Color.blue;
                break;

            case LightBarAnimation.LOW_HEALTH:

                if(animationTimer < lowHealthTime)
                {
                    animationColor = Color.Lerp(Color.red, Color.black, animationTimer * 1 / lowHealthTime);
                }
                else animationTimer = 0f;

                break;
        }



    }
}
