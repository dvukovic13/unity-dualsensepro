using UnityEngine;
[CreateAssetMenu(fileName = "BiLerp Lightbar Animation", menuName = "DualSenseAnims/BiLerp")]

public class BiLerpLightbarAnimation : LightbarAnimationBase
{
    private bool lerpDirection = false;

    public Color lerpFromColor;
    public Color lerpToColor;
    public float lerpDuration;


    private Color returnColor;
    public override Color GetColor(float deltaTime)
    {

        if (lerpDirection)
            timer += Time.deltaTime / lerpDuration;
        else
            timer -= Time.deltaTime / lerpDuration;

        timer = Mathf.Clamp01(timer);
        returnColor = Color.Lerp(lerpFromColor, lerpToColor, timer);

        if (timer >= 1f)
            lerpDirection = false;
        else if (timer <= 0f)
            lerpDirection = true;

        return returnColor;

    }


    public override void Initialize()
    {
        base.Initialize();
    }
}
