using UnityEngine;

[CreateAssetMenu(fileName = "Color Shift Lightbar Animation", menuName = "DualSenseAnims/Color Shift")]
public class ColorShiftLightbarAnimation : LightbarAnimationBase
{
    public Color[] colors;
    public float shiftSpeed = 1f;
  
    [SerializeField]
    private float motorLength = 0.1f;

    [SerializeField]
    private float lowIntensity = 0.1f;

    [SerializeField]
    private float hiIntensity = 0.1f;


    private (float, float ) rumble = (0f, 0f);

    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;
        motorTimer += deltaTime;

        if (motorTimer >= (1 / shiftSpeed))
        {
            rumble = (0, 0f);
            motorTimer = 0f;
        }
        else if (motorTimer >= ((1 / shiftSpeed) - motorLength))
            rumble = (lowIntensity, hiIntensity);
        else
            rumble = (0, 0f);

        int currentColorIndex = (int)(timer * shiftSpeed) % colors.Length;

        return colors[currentColorIndex];

    }


    public override (float, float) GetRumble(float deltaTime)
    {
        return rumble;
    }

    public override void Initialize()
    {
        base.Initialize();
    }

}