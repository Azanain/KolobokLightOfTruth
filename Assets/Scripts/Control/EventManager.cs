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

    public delegate void EventManagerIntDel(byte value);
    public static event EventManagerIntDel ButtonEvent;
    public static event EventManagerIntDel JumpEvent;
    public static event EventManagerIntDel ChangeJoystickEvent;

    //public delegate void EventManagerDel

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
    public static void ChangeJoystick(byte numerJoystick)
    {
        ChangeJoystickEvent?.Invoke(numerJoystick);
    }
}

