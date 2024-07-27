using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class TouchManager : Singleton<TouchManager>
{
    public delegate void StartTouchD(Vector2 pos, float time);
    public event StartTouchD OnStartTouch;
    public delegate void EndTouchD(Vector2 pos, float time);
    public event EndTouchD OnEndTouch;

    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Position: " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Pos: " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
