/*
 * Program Header: Moving Platform Direction
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 13, 2021
 * Version 1.0
 * 
 * Enum of possible directions for moving platform
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MovingPlatformDirection
{
    HORIZONTAL,
    VERTICAL,
    DIAGONAL_UP,
    DIAGONAL_DOWN,
    NUM_OF_DIRECTIONS
}
