using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    // UI Components
    public Text hintLabel;
    public CanvasGroup hintGroup;
    public Animator animator;

    // Mark as lit
    protected bool lit = false;
    protected bool playerNearby = false;

    // Hint to use
    [Header("Tooltip displayed when player is nearby")]
    public string hintMessage;

    // Links
    protected World world;
    protected InputDevice input;

    // Callback to execute when object had interaction
    protected Action callback;

    private void Awake() {
        hintLabel.text = hintMessage;
    }

    public void Initialize(World world, InputDevice input, Action callback) {
        this.world = world;
        this.callback = callback;

        // Bind to input and listen for "Use" events
        if (this.input != null)
            this.input.action -= OnAction;

        this.input = input;
        this.input.action += OnAction;
    }

    protected abstract void OnAction();

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

    private void OnDestroy() {
        if (input != null)
            input.action -= OnAction;
    }
} // class Interactable;
