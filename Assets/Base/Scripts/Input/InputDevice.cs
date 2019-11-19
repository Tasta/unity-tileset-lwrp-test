using UnityEngine;

public abstract class InputDevice
{
    public delegate void Move(Vector2 dir);
    public Move move;

    public delegate void Action();
    public Action action;

    public abstract void Update();
} // class InputDevice

