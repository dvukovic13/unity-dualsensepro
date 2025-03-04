using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
using UnityEngine;

public class DualSenseController : MonoBehaviour
{
    [SerializeField]
    private DualSenseGamepadHID dualSenseGamepadHID = null;

    public DualSenseGamepadHID GetDualSense {  get { return dualSenseGamepadHID; } }

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
        if(dualSenseGamepadHID != null)
        {
            dualSenseGamepadHID.ResetHaptics();
            dualSenseGamepadHID.SetMotorSpeedsAndLightBarColor(0f, 0f, Color.black);
        }

    }

    private void Start()
    {
        dualSenseGamepadHID = Gamepad.current as DualSenseGamepadHID;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
      

        if (device is DualSenseGamepadHID)
        {
            if (change == InputDeviceChange.Disconnected || change == InputDeviceChange.Removed || change == InputDeviceChange.Disabled)
            {
                dualSenseGamepadHID = null as DualSenseGamepadHID;
            }
            else if (change == InputDeviceChange.Reconnected || change == InputDeviceChange.Added || change == InputDeviceChange.Enabled)
            {
                dualSenseGamepadHID = Gamepad.current as DualSenseGamepadHID;
            }
        }
    }
}