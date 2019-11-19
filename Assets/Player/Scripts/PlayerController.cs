using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach this to the player object for movement.
 */
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        const float oxDelta = 4.0f; // 1 unit per second
        const float oyDelta = 2.5f; // 0.5f units per second

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

        Vector3 pos = transform.localPosition;
        pos.x += xDelta;
        pos.y += yDelta;
        transform.localPosition = pos;
    }
} // class PlayerController
