using UnityEngine;
public class PlayerParametrs : MonoBehaviour
{
    //основной режим
    public static float TimeReloadWeapon1 { get; private set; } = 2;
    public static float TimeReloadWeapon3 { get; private set; } = 3;

    public static int DamageWeapon1 { get; private set; }
    public static int DamageWeapon2 { get; private set; }
    public static int DamageWeapon3 { get; private set; }
    public static float DashRangeWeapon1 { get; private set; }
    public static float SpeedWeapon1 { get; private set; }

    public static float TimeReloadWeapon2_2 { get; private set; }
    public static int DamageWeapon2_2Max { get; private set; }
    public static float RecliningFromWeapon2_2 { get; private set; }
    public static float ForceJumpWeapon3 { get; private set; }

    //персонаж
    public static int MaxHp { get; private set; } = 100;
    public static float Speed { get; private set; } = 5;

    //  ///////////////////
    private float[] dashRangeWeapon1 = new float[2] {1f, 1.25f };
    private float[] speedWeapon1 = new float[4] { 1f, 1.1f, 1.2f, 1.3f };
    private const int damageWeapon2_1 = 5;
    private float[] improveDamageWeapon2 = new float[5] {1f, 1.1f, 1.2f, 1.3f,1.4f};
    private const int damageWeapon2_2 = 30;
    private float[] recliningFromWeapon2_2 = new float[2] {5f, 0};
    private float[] timeReloadWeapon2_2 = new float[2] { 20f, 15f };
    private const int damageWeapon3 = 5;
    private float[] improveDamageWeapon3 = new float[4] { 1f, 1.2f, 1.4f, 1.6f };
    private float[] forceJumpWeapon3 = new float[2] { 3f, 4.5f };

    private void Start()
    {
        UpdateParametrs();      
    }
    private void UpdateParametrs()
    { 
        DashRangeWeapon1 = dashRangeWeapon1[LoadSavedData.ImproveDashRangeWeapon1];
        SpeedWeapon1 = speedWeapon1[LoadSavedData.ImproveSpeedWeapon1];
        DamageWeapon2 = (int)(damageWeapon2_1 + damageWeapon2_1 * improveDamageWeapon2[LoadSavedData.ImproveSctageWeapon2]);
        DamageWeapon2_2Max = (int)(damageWeapon2_2 + damageWeapon2_2 * improveDamageWeapon2[LoadSavedData.ImproveSctageWeapon2]);
        RecliningFromWeapon2_2 = recliningFromWeapon2_2[LoadSavedData.ImproveRecliningFromWeapon2_2];
        TimeReloadWeapon2_2 = timeReloadWeapon2_2[LoadSavedData.ImproveIimerReloadWeapon2_2];
        DamageWeapon3 = (int)(damageWeapon3 + damageWeapon3 * improveDamageWeapon3[LoadSavedData.ImproveDamageWeapon3]);
        ForceJumpWeapon3 = forceJumpWeapon3[LoadSavedData.ImproveForceJumpWeapon3];
    }
}
