using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : Interactable
{
    protected override void OnAction() {
        if (!lit && playerNearby) {
            lit = true;
            animator.Play("LightUp");
        }
    }
    
    protected void OnShowDone() {
        callback?.Invoke();
    }
} // class Objective
