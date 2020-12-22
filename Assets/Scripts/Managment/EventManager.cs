using System;

public class EventManager
{
    public static Action<float, int> OnUpdatePlayerHealth;
    public static Action<float> OnUpdatePlayerReload;
}