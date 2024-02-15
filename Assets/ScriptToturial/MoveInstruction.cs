using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * This is the script for the first instruction - moving.
 */

public class MoveInstruction : MonoBehaviour, Instruction
{

    private void Start()
    {
        // Activate the moveInstructionsGUI when this script starts
    }
    // The completed property frot the Instruction interface:
    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }

    // Indicatores for left and right movement:
    private bool movedLeft = false;
    private bool movedRight = false;
    private bool movedUp = false;
    private bool movedDown = false;

    private void Update()
    {
        // Complete when players tried both LEFT and RIGHT arrows:
        if (movedLeft && movedRight && movedUp && movedDown) { 
        completed = true;
        }

        else
        {
            // Update the fields when player completed a move in a direction:
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                movedRight = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movedLeft = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                movedUp = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                movedDown = true;
            }
        
        }
    }
}
