using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


[CreateAssetMenu(fileName = "Heartbeat Lightbar Animation", menuName = "DualSenseAnims/Heartbeat")]

public class HeartbeatLightbarAnimation : LightbarAnimationBase
{
    public Color pulseColor;
    public float beatSpeed = 1f;  // Speed of the heartbeat
   // public float beatPause = 0.5f;  // Pause between beats
    private float timer = 0f;

    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        float pulse = Mathf.PingPong(timer * beatSpeed, 1f);
        if (pulse < 0.7f)  // Stronger pulse effect
        {
            return pulseColor;
        }
        return Color.black;  // Brief pause
    }

}