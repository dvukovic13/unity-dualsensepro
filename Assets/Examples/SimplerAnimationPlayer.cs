using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.LowLevel;

public class SimplerAnimationPlayer : MonoBehaviour
{

    [SerializeField]
    private DualSenseController dualSenseController;

    [SerializeField]
    private bool Rumble = false;
    [SerializeField] private LightbarAnimationBase CurrentAnimation; //= new LightbarAnimationBase();;//= new List<LightbarAnimationBase>();
    [SerializeField] private string CurrentAnimationName = string.Empty;

    [SerializeField]
    private bool searchForController = true;


    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void OnValidate()
    {
        if (CurrentAnimation != null)
        {
            CurrentAnimation.Initialize();
            CurrentAnimationName = CurrentAnimation.name;
        }
    }
    // Update is called once per frame
    void Update()
    {
       

        if (dualSenseController.GetDualSense != null && CurrentAnimation != null)
        {
            // DualSenseGamepadHID.SetLightBarColor(CurrentAnimation.GetColor(Time.deltaTime));

            (float lowfreq, float highfreq) = (CurrentAnimation.GetRumble(Time.deltaTime).Item1, CurrentAnimation.GetRumble(Time.deltaTime).Item2);
            Color color = CurrentAnimation.GetColor(Time.deltaTime);

            dualSenseController.GetDualSense.SetMotorSpeedsAndLightBarColor(Rumble ? lowfreq : 0f, Rumble ? highfreq : 0f, color);
        }
    }
}
