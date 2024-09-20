using UnityEngine;

[CreateAssetMenu(fileName = "Color Shift Lightbar Animation", menuName = "DualSenseAnims/Color Shift")]
public class ColorShiftLightbarAnimation : LightbarAnimationBase
{
    public Color[] colors;
    public float shiftSpeed = 1f;
    private float timer = 0f;
    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        int currentColorIndex = (int)(timer * shiftSpeed) % colors.Length;
        return colors[currentColorIndex];


    }

}