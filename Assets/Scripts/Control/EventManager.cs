public class EventManager
{
    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;
    public static event IntEventmanagerDel TakeDamageEvent;
    public static event IntEventmanagerDel TakeHPEvent;
    public static event IntEventmanagerDel ShootChargedLaserEvent;

    public delegate void EventManagerDel();
    public static event EventManagerDel PauseEvent;
    public static event EventManagerDel ShootEvent;

    public delegate void EventManagerByteDel(byte value);
    public static event EventManagerByteDel ButtonEvent;
    public static event EventManagerByteDel JumpEvent;

    public delegate void EventManagerFloatDel(float value);
    public static event EventManagerFloatDel DiscardingEvent;//отбрасывание
    public static event EventManagerFloatDel DashEvent;

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
    public static void Pause()//?
    {
        PauseEvent?.Invoke();
    }
    public static void Shoot()
    {
        ShootEvent?.Invoke();
    }
    public static void Jump(byte modeAction)
    {
        JumpEvent?.Invoke(modeAction);
    }
    public static void ButtonPressed(byte numberButton)
    {
        ButtonEvent?.Invoke(numberButton);
    }
    public static void ShootChargedLaser(int damage)
    {
        ShootChargedLaserEvent?.Invoke(damage);
    }
    public static void Discarding(float force)
    {
        DiscardingEvent?.Invoke(force);
    }
    public static void Dash(float force)
    {
        DashEvent?.Invoke(force);
    }
}

