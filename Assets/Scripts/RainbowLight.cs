using UnityEngine;

[CreateAssetMenu(fileName = "Rainbow Lightbar Animation", menuName = "DualSenseAnims/Rainbow")]

public class RainbowLightbarAnimation : LightbarAnimationBase
{
    public float cycleSpeed = 1f;  // Speed of the rainbow cycle
    [SerializeField]
    private float freq = 0f;
    [SerializeField]
    private float highFactor = 1f;
    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        float hue = Mathf.Repeat(timer * cycleSpeed, 1f);  // Cycles between 0 and 1
        freq = hue / highFactor;
        freq = Mathf.Clamp(freq, 0.005f, 1.0f);
        return Color.HSVToRGB(hue, 1f, 1f);  // Full saturation and value for vivid colors
    }

    public override (float, float) GetRumble(float deltaTime)
    {
        // return rumble;
        return (0, freq);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

}