public class EventManager
{
    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;
    public static event IntEventmanagerDel TakeDamageEvent;
    public static event IntEventmanagerDel TakeHPEvent;

    public delegate void EventManagerDel();
    public static event EventManagerDel PauseEvent;
    public static event EventManagerDel ShootEvent;
    public static event EventManagerDel JumpEvent;

    public delegate void EventManagerIntDel(byte value);
    public static event EventManagerIntDel ButtonEvent;

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
    public static void Shoot()
    {
        ShootEvent?.Invoke();
    }
    public static void Jump()
    {
        JumpEvent?.Invoke();
    }
    public static void ButtonPressed(byte numberButton)
    {
        ButtonEvent?.Invoke(numberButton);
    }
}

