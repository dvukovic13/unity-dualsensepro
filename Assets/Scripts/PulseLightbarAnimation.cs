using UnityEngine;

[CreateAssetMenu(fileName = "Pulse Lightbar Animation", menuName = "DualSenseAnims/Pulse")]
public class PulseLightbarAnimation : LightbarAnimationBase
{
    public Color baseColor = Color.white;
    public float pulseSpeed = 1f;
    private float time = 0f;
    public override Color GetColor(float deltaTime)
    {
        time += deltaTime;
        float pulse = Mathf.Sin(time * pulseSpeed) * 0.5f + 0.5f;
        return baseColor * pulse;
    }

}