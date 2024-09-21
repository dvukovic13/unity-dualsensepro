using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class SimplerAnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private DualSenseGamepadHID DualSenseGamepadHID = null;

    [SerializeField]
    private bool Rumble = false;
    [SerializeField] private LightbarAnimationBase CurrentAnimation; //= new LightbarAnimationBase();;//= new List<LightbarAnimationBase>();
    // Start is called before the first frame update
    void Start()
    {
        DualSenseGamepadHID = Gamepad.current as DualSenseGamepadHID;
        Debug.Log(DualSenseGamepadHID);
    }

    // Update is called once per frame
    void Update()
    {
        if (DualSenseGamepadHID != null && CurrentAnimation != null)
        {
            // DualSenseGamepadHID.SetLightBarColor(CurrentAnimation.GetColor(Time.deltaTime));

            (float lowfreq, float highfreq) = (CurrentAnimation.GetRumble(Time.deltaTime).Item1, CurrentAnimation.GetRumble(Time.deltaTime).Item2);
            Color color = CurrentAnimation.GetColor(Time.deltaTime);

            DualSenseGamepadHID.SetMotorSpeedsAndLightBarColor(Rumble ? lowfreq : 0f, Rumble ? highfreq : 0f, color);
        }
    }
}
