using UnityEngine;

[CreateAssetMenu(fileName = "Breathing Lightbar Animation", menuName = "DualSenseAnims/Breathing")]

public class BreathingLightbarAnimation : LightbarAnimationBase
{
    public Color baseColor = Color.white;
    public float breathSpeed = 1f;  // Speed of the breathing effect
    public float outbreathFactor = 2f;  // Speed of the breathing effect
    public float minAlpha = 0.2f;   // Minimum transparency for the breathing effect
    private float timer = 0f;

    private bool breathDirection = true;
    public override Color GetColor(float deltaTime)
    {


        if (breathDirection)
            timer += deltaTime * breathSpeed * outbreathFactor;
        else
            timer -= deltaTime * breathSpeed ;

        Debug.Log(timer);

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

   
}