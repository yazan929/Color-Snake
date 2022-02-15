using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDiffChange : MonoBehaviour
{
    public int value = 1;


    public void onTrue(){
        SnakeMovement.difOption=value;
    }
}
