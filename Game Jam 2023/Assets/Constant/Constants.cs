using UnityEngine;

public static class Constants
{
    public const float horixontalSpeed = 10.0f;
    public const float dashingSpeed = 30.0f;
    public const float verticalSpeed = 40.0f;
    public const float gravity = -50.0f;

}

public enum PlayerNumber
{
    one = 1, 
    two = 2,
}

public enum  Movement
{
    up, 
    down, 
    left, 
    right,
    dash,
    stop,
}