public class EventManager
{
    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;
    public static event IntEventmanagerDel TakeDamageEvent;
    public static event IntEventmanagerDel TakeHPEvent;
    public static event IntEventmanagerDel ShootChargedLaserEvent;
    public static event IntEventmanagerDel AddCurrentMoneyEvent;
    public static event IntEventmanagerDel AddTotalMoneyEvent;

    public delegate void EventManagerDel();
    public static event EventManagerDel ShootEvent;
    public static event EventManagerDel AuthorModeEvent;
    public static event EventManagerDel CallCapsuleTeleportEvent;

    public delegate void EventManagerByteDel(byte value);
    public static event EventManagerByteDel ButtonEvent;
    public static event EventManagerByteDel JumpEvent;

    public delegate void EventManagerFloatDel(float value);
    public static event EventManagerFloatDel DiscardingEvent;//отбрасывание
    public static event EventManagerFloatDel DashEvent;

    public delegate void EventManagerStringDel(string name);
    public static event EventManagerStringDel ButtonNameEvent;
    public static event EventManagerStringDel NameChosenLevelEvent;

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

    public static void AddCurrentMoney(int money)
    {
        AddCurrentMoneyEvent?.Invoke(money);
    }
    public static void AddTotalMoney(int money)
    {
        AddTotalMoneyEvent?.Invoke(money);
    }
    public static void AuthorMode()
    {
        AuthorModeEvent?.Invoke();
    }
    public static void ButtonName(string name)
    {
        ButtonNameEvent?.Invoke(name);
    }
    public static void CallCapsuleTeleport()
    {
        CallCapsuleTeleportEvent?.Invoke();
    }
    public static void NameChosenLevel(string nameLevel)
    {
        NameChosenLevelEvent?.Invoke(nameLevel);
    }
}

