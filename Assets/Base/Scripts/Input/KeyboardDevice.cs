using UnityEngine;


public class KeyboardDevice
    : InputDevice
{
    const float oxDelta = 4.0f; // 4 units per second horizontally
    const float oyDelta = 2.5f; // 2.5f units per second vertically (fake depth, whynot?)

    public override void Update() {
        HandleMovement();
        HandleActions();
    }

    private void HandleMovement() {
        float xDelta = 0.0f, yDelta = 0.0f;
        if (Input.GetKey(KeyCode.W)) {
            yDelta = oyDelta * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            xDelta = -oxDelta * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            yDelta = -oyDelta * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            xDelta = oxDelta * Time.deltaTime;
        }

        move?.Invoke(new Vector2(xDelta, yDelta));
    }

    private void HandleActions() {
        if (Input.GetKeyDown(KeyCode.E)) {
            action?.Invoke();
        }
    }
} // class KeyboardDevice
