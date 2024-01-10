using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public MoveFunction playerMoveFunction;

    private void OnTriggerEnter2D(Collider2D col)
    {
        playerMoveFunction.ResetJumpCount();
        
    }
}
