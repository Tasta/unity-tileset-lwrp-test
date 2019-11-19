using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : Interactable
{
    public override void OnAction() {
        if (!lit && playerNearby) {
            lit = true;
            animator.Play("LightUp");
        }
    }
    
    protected void OnShowDone() {
        callback?.Invoke();
    }
} // class Objective
