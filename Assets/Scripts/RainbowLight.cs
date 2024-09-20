using UnityEngine;

[CreateAssetMenu(fileName = "Rainbow Lightbar Animation", menuName = "DualSenseAnims/Rainbow")]

public class RainbowLightbarAnimation : LightbarAnimationBase
{
    public float cycleSpeed = 1f;  // Speed of the rainbow cycle
    private float timer = 0f;
    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        float hue = Mathf.Repeat(timer * cycleSpeed, 1f);  // Cycles between 0 and 1
        return Color.HSVToRGB(hue, 1f, 1f);  // Full saturation and value for vivid colors
    }

  
}