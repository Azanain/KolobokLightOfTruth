public class EventManager
{
    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;
    public static event IntEventmanagerDel TakeDamageEvent;
    public static event IntEventmanagerDel TakeHPEvent;
    public static event IntEventmanagerDel ChargedLaserEvent;

    public delegate void EventManagerDel();
    public static event EventManagerDel PauseEvent;
    public static event EventManagerDel ShootEvent;
    public static event EventManagerDel ShootChargeLazerEvent;

    public delegate void EventManagerFloatDel(float timer);
    public static event EventManagerFloatDel ChargingLazerEvent;

    public delegate void EventManagerIntDel(byte value);
    public static event EventManagerIntDel ButtonEvent;
    public static event EventManagerIntDel JumpEvent;

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

    public static void ChargedLazer(int value)//?
    {
        ChargedLaserEvent?.Invoke(value);
    }
    public static void ShchaootChargeLazer()//?
    {
        ShootChargeLazerEvent?.Invoke();
    }
    public static void ChargingLazer(float timer)
    {
        ChargingLazerEvent?.Invoke(timer);
    }
}

