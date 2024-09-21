using UnityEngine;

[CreateAssetMenu(fileName = "Breathing Lightbar Animation", menuName = "DualSenseAnims/Breathing")]

public class BreathingLightbarAnimation : LightbarAnimationBase
{
    public Color baseColor = Color.white;
    public float breathSpeed = 0.55f;  
    public float outbreathSpeed = 0.25f;  

    private bool breathDirection = true;

    private float rumble = 0f;
    public override Color GetColor(float deltaTime)
    {

        if (breathDirection)
        {
            timer += deltaTime * outbreathSpeed;
            rumble = 0f;
        }
        else
        {
            timer -= deltaTime * breathSpeed;
            rumble += deltaTime * breathSpeed;
        }


        if (timer >= 1.0)
        {
            breathDirection = false;
        }
        else if (timer <= 0f)
        {
            breathDirection = true;

        }

        return Color.Lerp(baseColor, Color.black, timer);

       // float alpha = Mathf.PingPong(timer * breathSpeed, 1f) * (1f - minAlpha) + minAlpha;
       // return new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
    }

    public override (float, float) GetRumble(float deltaTime)
    {
        return (0, rumble);
    }

    public override void Initialize()
    {
        base.Initialize();
    }


}