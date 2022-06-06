public class EventManager
{
    public delegate void IntEventmanagerIntDel(int value);
    public static event IntEventmanagerIntDel LoadGameSceneEvent;
    public static event IntEventmanagerIntDel TakeDamageEvent;
    public static event IntEventmanagerIntDel TakeHPEvent;
    public static event IntEventmanagerIntDel ShootChargedLaserEvent;
    public static event IntEventmanagerIntDel AddCurrentMoneyEvent;
    public static event IntEventmanagerIntDel AddTotalMoneyEvent;
    public static event IntEventmanagerIntDel ChangeNumberEnemyEvent;

    public delegate void EventManagerDel();
    public static event EventManagerDel ShootEvent;
    public static event EventManagerDel AuthorModeEvent;
    public static event EventManagerDel CallCapsuleTeleportEvent;
    public static event EventManagerDel CanMoveEvent;
    public static event EventManagerDel SaveDataEvent;
    public static event EventManagerDel AudioWeapon1Event;
    public static event EventManagerDel AudioWeapon3Event;
    public static event EventManagerDel PauseEvent;
    public static event EventManagerDel SaveDataOptionsEvent;
    public static event EventManagerDel TransferMoneyEvent;

    public delegate void EventManagerByteDel(byte value);
    public static event EventManagerByteDel ButtonEvent;
    public static event EventManagerByteDel JumpEvent;
    public static event EventManagerByteDel UpgradeSkillEvent;

    public delegate void EventManagerFloatDel(float value);
    public static event EventManagerFloatDel DiscardingEvent;//отбрасывание
    public static event EventManagerFloatDel DashEvent;

    public delegate void EventManagerStringDel(string name);
    public static event EventManagerStringDel ButtonNameEvent;

    public delegate void EventManagerBoolDel(bool isIt);
    public static event EventManagerBoolDel IsChargingLaserEvent;
    public static event EventManagerBoolDel WinEvent;

    public delegate void EventManagerStringByteDel(string name, byte number);
    public static event EventManagerStringByteDel ChangeSceneEvent;

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
    public static void ChangeScene(string nameLevel, byte numberScene)
    {
        ChangeSceneEvent?.Invoke(nameLevel, numberScene);
    }
    public static void CanMove()
    {
        CanMoveEvent?.Invoke();
    }
    public static void SaveData()
    {
        SaveDataEvent?.Invoke();
    }
    public static void AudioWeapon1()
    {
        AudioWeapon1Event?.Invoke();
    }
    public static void AudioWeapon3()
    {
        AudioWeapon3Event.Invoke();
    }
    public static void IsChargingLaser(bool isCharging)
    {
        IsChargingLaserEvent?.Invoke(isCharging);
    }
    public static void ChangeNumberEnemy(int number)
    {
        ChangeNumberEnemyEvent.Invoke(number);
    }
    public static void Win(bool isWin)
    {
        WinEvent?.Invoke(isWin);
    }
    public static void Pause()
    {
        PauseEvent?.Invoke();
    }
    public static void SaveDataOptions()
    {
        SaveDataOptionsEvent?.Invoke();
    }
    public static void TransferMoney()
    {
        TransferMoneyEvent?.Invoke();
    }
    public static void UpgradeSkill(byte numberSkill)
    {
        UpgradeSkillEvent?.Invoke(numberSkill);
    }
}

