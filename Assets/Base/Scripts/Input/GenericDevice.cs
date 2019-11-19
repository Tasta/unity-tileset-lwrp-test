using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GenericDevice
    : InputDevice
{
    const float oxDelta = 4.0f; // 4 units per second horizontally
    const float oyDelta = 2.5f; // 2.5f units per second vertically (fake depth, whynot?)

    public override void Update() {
        HandleMovement();
        HandleActions();
    }

    private void HandleMovement() {
        float xValue = Input.GetAxis("Horizontal");
        float yValue = Input.GetAxis("Vertical");

        move?.Invoke(new Vector2(xValue * oxDelta * Time.deltaTime, yValue * oyDelta * Time.deltaTime));
    }

    private void HandleActions() {
        float isOn = Input.GetAxis("LightUp");
        if (isOn != 0)
            action?.Invoke();
    }
} // class GenericDevice
