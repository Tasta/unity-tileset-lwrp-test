using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{
    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Show() {
        gameObject.SetActive(true);
        animator.Play("LightUp");
    }

    public override void OnAction() {
        // A hack. Kept |lit| as a flag for "Already Used"
        if (playerNearby && !lit) {
            callback.Invoke();
            lit = true;
        }
    }
} // class Teleport
