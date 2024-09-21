using UnityEngine;

[CreateAssetMenu(fileName = "Pulse Lightbar Animation", menuName = "DualSenseAnims/Pulse")]
public class PulseLightbarAnimation : LightbarAnimationBase
{
    public Color baseColor = Color.white;
    public float pulseSpeed = 1f;

    private float rumble = 0f;
    [SerializeField]
    private float rumbleFactor = 1f;
    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        float pulse = Mathf.Sin(timer * pulseSpeed) * 0.5f + 0.5f;
        rumble = pulse / rumbleFactor;
        return baseColor * pulse;
    }

    public override (float, float) GetRumble(float deltaTime)
    {
        return (0f, rumble);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

}