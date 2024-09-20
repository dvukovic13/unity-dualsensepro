using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightbarAnimationBase : ScriptableObject
{
    public abstract Color GetColor(float deltaTime);
}
