using UnityEngine;

public class LoadSavedData : MonoBehaviour
{
    public static float TimeReloadWeapon1 { get; private set; }
    public static float TimeReloadWeapon3 { get; private set; }
    public static int DamageWeapon1 { get; private set; }
    public static int DamageWeapon2 { get; private set; }
    public static int DamageWeapon3 { get; private set; }
    public static float TimeReloadWeapon2_2 { get; private set; }
    public static int DamageWeapon2_2Max { get; private set; }
    public static int MaxHp { get; private set; }
    public static float Speed { get; private set; }
    public static int TotalMoney { get; private set; }

    public static byte ImproveDashRangeWeapon1 { get; private set; }
    public static byte ImproveSpeedWeapon1 { get; private set; }
    public static byte ImproveSctageWeapon2 { get; private set; }
    public static byte ImproveRecliningFromWeapon2_2 { get; private set; }
    public static byte ImproveIimerReloadWeapon2_2 { get; private set; }
    public static byte ImproveDamageWeapon3 { get; private set; }
    public static byte ImproveForceJumpWeapon3 { get; private set; }
    public static bool ImproveIsWeapon2_2 { get; private set; }

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
        data.totalMoney =  TotalMoney;
        data.timeReloadWeapon2_2 = TimeReloadWeapon2_2;
        data.damageWeapon2_2Max = DamageWeapon2_2Max;
        data.improveDashRangeWeapon1 = ImproveDashRangeWeapon1;
        data.improveSpeedWeapon1 = ImproveSpeedWeapon1;
        data.improveSctageWeapon2 = ImproveSctageWeapon2;
        data.improveRecliningFromWeapon2_2 =  ImproveRecliningFromWeapon2_2;
        data.improveIimerReloadWeapon2_2 = ImproveIimerReloadWeapon2_2;
        data.improveDamageWeapon3 = ImproveDamageWeapon3;
        data.improveForceJumpWeapon3 = ImproveForceJumpWeapon3;
        data.improveIsWeapon2_2 = ImproveIsWeapon2_2;

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
        TotalMoney = data.totalMoney;
        TimeReloadWeapon2_2 = data.timeReloadWeapon2_2;
        DamageWeapon2_2Max = data.damageWeapon2_2Max;
        ImproveDashRangeWeapon1 = data.improveDashRangeWeapon1;
        ImproveSpeedWeapon1 = data.improveSpeedWeapon1;
        ImproveSctageWeapon2 = data.improveSctageWeapon2;
        ImproveRecliningFromWeapon2_2 = data.improveRecliningFromWeapon2_2;
        ImproveIimerReloadWeapon2_2 = data.improveIimerReloadWeapon2_2;
        ImproveDamageWeapon3 = data.improveDamageWeapon3;
        ImproveForceJumpWeapon3 = data.improveForceJumpWeapon3;
        ImproveIsWeapon2_2 = data.improveIsWeapon2_2;
    }
    private void OnDestroy()
    {
        EventManager.SaveDataEvent += Save;
    }
}

