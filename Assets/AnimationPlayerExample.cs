using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private DualSenseGamepadHID DualSenseGamepadHID = null;

    [SerializeField] private List<LightbarAnimationBase> lightbarAnimations = new List<LightbarAnimationBase>();


    [SerializeField]
    [Range(0, 6)]
    private int animIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DualSenseGamepadHID = Gamepad.current as DualSenseGamepadHID;
        Debug.Log(DualSenseGamepadHID);
    }

    // Update is called once per frame
    void Update()
    {
        if (DualSenseGamepadHID != null) {
            DualSenseGamepadHID.SetLightBarColor(lightbarAnimations[animIndex].GetColor(Time.deltaTime));
        }
    }
}
