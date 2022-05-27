using UnityEngine;

public class LoadSavedData : MonoBehaviour
{
    public static float TimeReloadWeapon1 { get; private set; } = 3;
    public static float TimeReloadWeapon3 { get; private set; } = 5;
    public static int DamageWeapon1 { get; private set; } = 10;
    public static int DamageWeapon2 { get; private set; } = 2;
    public static int DamageWeapon3 { get; private set; } = 5;
    public static float TimeReloadWeapon2_2 { get; private set; } = 20;
    public static int DamageWeapon2_2Max { get; private set; } = 30;
    public static int MaxHp { get; private set; } = 100;
    public static float Speed { get; private set; } = 5;

    public static byte DashRangeWeapon1 { get; private set; }
    public static byte SpeedWeapon1 { get; private set; }

    private SavedData data;
    private Storage storage;

    private void Awake()
    {
        storage = new Storage();
        data = new SavedData();
        EventManager.SaveDataEvent += Save;
        Load();
    }
    private void Save()
    {
        data.timeReloadWeapon1 = TimeReloadWeapon1;
        data.timeReloadWeapon3 = TimeReloadWeapon3;
        data.damageWeapon1 = DamageWeapon1;
        data.damageWeapon2 = DamageWeapon2;
        data.damageWeapon3 = DamageWeapon3;
        data.timeReloadWeapon2_2 = TimeReloadWeapon2_2;
        data.damageWeapon2_2Max = DamageWeapon2_2Max;
        data.dashRangeWeapon1 = DashRangeWeapon1;
        data.speedWeapon1 = SpeedWeapon1;

        storage.Save(data);
    }
    private void Load()
    {
        data = (SavedData)storage.Load(new SavedData());

        TimeReloadWeapon1 = data.timeReloadWeapon1;
        TimeReloadWeapon3 = data.timeReloadWeapon3;
        DamageWeapon1 = data.damageWeapon1;
        DamageWeapon2 = data.damageWeapon2;
        DamageWeapon3 = data.damageWeapon3;
        TimeReloadWeapon2_2 = data.timeReloadWeapon2_2;
        DamageWeapon2_2Max = data.damageWeapon2_2Max;
        DashRangeWeapon1 = data.dashRangeWeapon1;
        SpeedWeapon1 = data.speedWeapon1;
    }
    private void OnDestroy()
    {
        EventManager.SaveDataEvent += Save;
    }
}

