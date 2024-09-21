using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flash Lightbar Animation", menuName = "DualSenseAnims/Flash")]
public class FlashAnimation : LightbarAnimationBase
{
    [SerializeField]
    Color colorOne;
    [SerializeField]
    Color colorTwo;

    [SerializeField]
    private float duration = 0.3f;

    [SerializeField]
    private float motorTime = 0.2f;

    [SerializeField]
    private float lowIntensity = 0.15f;

    [SerializeField]
    private float highIntensity = 0.15f;

    public override Color GetColor(float deltaTime)
    {
        timer += deltaTime;

        if (timer < duration)
        {
            return colorOne;
        }
        else if (timer > duration * 2)
        {
            timer = 0f;
            return Color.black;
        }
        else return colorTwo;
    }
    public override (float, float) GetRumble(float deltaTime)
    {
        motorTimer += deltaTime;

        if (motorTimer >= (motorTime * 2))
            motorTimer = 0f;
        else if (motorTimer >= motorTime)
            return (lowIntensity, highIntensity);
        else return (0f, 0f);

        return (0f, 0f);

    }

    public override void Initialize()
    {
        base.Initialize();
    }
}
