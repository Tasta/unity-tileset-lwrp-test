using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach this to the player object for movement.
 */
public class PlayerController 
    : MonoBehaviour
{
    const float oxDelta = 4.0f; // 4 units per second horizontally
    const float oyDelta = 2.5f; // 2.5f units per second vertically (fake depth, whynot?)

    // Bound control scheme
    private InputDevice input;

    public void Bind(InputDevice newDevice) {
        if (input != null) {
            input.move -= Move;
        }

        input = newDevice;
        input.move += Move;
    }

    public void Move(Vector2 dir) {
        if (dir.magnitude == 0)
            return;

        Vector3 pos = transform.localPosition;
        pos.x += dir.x;
        pos.y += dir.y;
        transform.localPosition = pos;
    }

    private void OnDestroy() {
        if (input != null) {
            input.move -= Move;
        }
    }
} // class PlayerController
