using UnityEngine;

public static class Constants
{
    public const float HORIZONTAL_SPEED = 10.0f;
    public const float DASHING_SPEED = 30.0f;
    public const float VERTICAL_SPEED = 40.0f;
    public const float GRAVITY = -50.0f;

    public const int MAX_BULLET = 5;
    public const int RELOAD_TIME = 5;

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