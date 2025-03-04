using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private DualSenseController dualSenseController = null;

    [SerializeField]
    private bool Rumble = false;

    [SerializeField]
    [Range(0, 6)]
    private int animIndex = 0;

    [SerializeField] private List<LightbarAnimationBase> lightbarAnimations = new List<LightbarAnimationBase>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lightbarAnimations.Count; i++)
            lightbarAnimations[i].Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (dualSenseController.GetDualSense != null) {
            (float lowfreq, float hifreq) = (lightbarAnimations[animIndex].GetRumble(Time.deltaTime).Item1, lightbarAnimations[animIndex].GetRumble(Time.deltaTime).Item2);
            Color color = lightbarAnimations[animIndex].GetColor(Time.deltaTime);
            dualSenseController.GetDualSense.SetMotorSpeedsAndLightBarColor(Rumble ? lowfreq : 0f, Rumble ? hifreq : 0f, color);
        }
    }
}
