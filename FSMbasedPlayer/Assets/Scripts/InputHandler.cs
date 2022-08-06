using System;
using UnityEngine;

public static class MyInputHandler
{
    public static bool lInput => Input.GetKey(KeyCode.LeftArrow);
    public static bool rInput => Input.GetKey(KeyCode.RightArrow);
    public static bool xInput => lInput || rInput;
}