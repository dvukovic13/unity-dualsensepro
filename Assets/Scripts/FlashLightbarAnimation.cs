using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flash Lightbar Animation", menuName = "DualSenseAnims/Flash")]
public class FlashAnimation : LightbarAnimationBase
{
    private float timer = 0f;
    [SerializeField]
    Color colorOne;
    [SerializeField]
    Color colorTwo;

    [SerializeField]
    private float duration = 0.3f;
   
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
}
