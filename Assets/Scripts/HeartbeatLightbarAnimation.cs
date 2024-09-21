using UnityEngine;


[CreateAssetMenu(fileName = "Heartbeat Lightbar Animation", menuName = "DualSenseAnims/Heartbeat")]

public class HeartbeatLightbarAnimation : LightbarAnimationBase
{
    public Color pulseColor;
    public float beatSpeed = 1f;  // Speed of the heartbeat
                                  // public float beatPause = 0.5f;  // Pause between beats

    private float lowRumble = 0f;

    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        float pulse = Mathf.PingPong(timer * beatSpeed, 1f);
        if (pulse < 0.7f)  // Stronger pulse effect
        {
            lowRumble = 0.1f;
            return pulseColor;
        }
        lowRumble = 0f;
        return Color.black;  // Brief pause
    }

    public override (float, float) GetRumble(float deltaTime)
    {
        return (lowRumble, 0f);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

}