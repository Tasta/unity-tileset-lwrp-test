using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    // UI Components
    public Text hintLabel;
    public CanvasGroup hintGroup;
    public Animator animator;

    // Mark as lit
    private bool lit = false;
    private bool playerNearby = false;

    // Hint to use
    [Header("Tooltip displayed when player is nearby")]
    public string hintMessage;

    // Link to the world these are in
    private World world;

    private void Awake() {
        hintLabel.text = hintMessage;
    }

    private void Initialize(World world) {
        this.world = world;

        // ToDo: Bind to input and listen for "Use" events
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (!lit && playerNearby) {
                lit = true;
                animator.Play("LightUp");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player")
            return;

        playerNearby = true;

        if (!lit) {
            SetTip(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name != "Player")
            return;

        playerNearby = false;

        SetTip(false);
    }

    private void SetTip(bool visible) {
        LeanTween.cancel(gameObject);
        const float duration = 0.66f;

        float startAlpha = hintGroup.alpha;
        float endAlpha = visible ? 1.0f : 0.0f;
        LeanTween.value(gameObject, startAlpha, endAlpha, duration)
                 .setEaseInQuad()
                 .setOnUpdate((float lerpF) =>
                 {
                     hintGroup.alpha = lerpF;
                 });
    }
} // class Interactable;
