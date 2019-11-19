using UnityEngine;

public class MouseDevice
   : InputDevice
{
    const float oxDelta = 10.0f; // 4 units per second horizontally
    const float oyDelta = 5f; // 2.5f units per second vertically (fake depth, whynot?)

    public override void Update() {
        HandleMovement();   
    }

    private void HandleMovement() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = Input.mousePosition;
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);

            if (hit.collider != null) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                    interactable.OnAction();
                return;
            }
        }

        if (Input.GetMouseButton(0)) {
            Vector2 pos = Input.mousePosition;
            float normX = pos.x - Screen.width / 2.0f;
            float normY = pos.y - Screen.height / 2.0f;

            float lerpX = normX / (Screen.width / 2.0f);
            float lerpY = normY / (Screen.height / 2.0f);

            float moveX = Mathf.Sign(lerpX) * Mathf.Lerp(0.0f, oxDelta, Mathf.Abs(lerpX));
            float moveY = Mathf.Sign(lerpY) * Mathf.Lerp(0.0f, oyDelta, Mathf.Abs(lerpY));

            move?.Invoke(new Vector2(moveX * Time.deltaTime, moveY * Time.deltaTime));
        }
    }
} // class MouseDevice