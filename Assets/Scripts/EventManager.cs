public class EventManager
{
    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;
    public static event IntEventmanagerDel TakeDamageEvent;
    public static event IntEventmanagerDel TakeHPEvent;

    public delegate void EventManagerDel();
    public static event EventManagerDel PauseEvent;

    public static void LoadGameScene(int idFloor)
    {
        LoadGameSceneEvent?.Invoke(idFloor);
    }
    public static void TakeDamage(int damage)
    {
        TakeDamageEvent?.Invoke(damage);
    }
    public static void TakeHP(int damage)
    {
        TakeHPEvent?.Invoke(damage);
    }
    public static void Pause()
    {
        PauseEvent?.Invoke();
    }
}

