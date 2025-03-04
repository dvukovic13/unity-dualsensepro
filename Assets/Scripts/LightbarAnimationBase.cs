using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightbarAnimationBase : ScriptableObject
{
    protected float timer = 0f;

    protected float motorTimer = 0f;
    public abstract Color GetColor(float deltaTime);

    public virtual (float, float) GetRumble(float deltaTime)
    {
        return (0f, 0f);
    }

    public virtual void Initialize()
    {
        ResetTimers();
        //Debug.Log("initialized!");
        return;
    }


    private void Awake()
    {
        Initialize();
    }

    public virtual void ResetTimers()
    {
        timer = 0f;
        motorTimer = 0f;
    }
}
