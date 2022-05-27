using UnityEngine;
public class PlayerParametrs : MonoBehaviour
{
    //основной режим
    public static float TimeReloadWeapon1 { get; private set; } = 3;
    public static float TimeReloadWeapon3 { get; private set; } = 5;

    //public static int DamageWeapon1Min { get; private set; } = 1;
    public static int DamageWeapon1 { get; private set; } = 10;
    public static int DamageWeapon2 { get; private set; } = 2;
    public static int DamageWeapon3 { get; private set; } = 5;
    public static float DashRangeWeapon1 { get; private set; }
    public static float SpeedWeapon1 { get; private set; }

    //заряженный режим
    //public static float TimeReloadWeapon1_2 { get; private set; } = 3;
    public static float TimeReloadWeapon2_2 { get; private set; } = 20;
    //public static float TimeReloadWeapon3_2 { get; private set; } = 15;

    //public static int DamageWeapon2_2Min { get; private set; } = 6;
    public static int DamageWeapon2_2Max { get; private set; } = 30;
    //public static int DamageWeapon3_2 { get; private set; } = 10;

    //персонаж
    public static int MaxHp { get; private set; } = 100;
    public static float Speed { get; private set; } = 5;

    //  ///////////////////
    private float[] dashRangeWeapon1 = new float[2] {1, 1.25f };
    private float[] speedWeapon1 = new float[3] {1.1f, 1.2f, 1.3f };
    //private int[] damageWeapon2_1 = new int [2] 2;
    private const int damageWeapon2_2 = 30;
    //private int 

    private void Start()
    {
        UpdateParametrs();
    }
    private void UpdateParametrs()
    { 
        DashRangeWeapon1 = dashRangeWeapon1[LoadSavedData.DashRangeWeapon1];
        SpeedWeapon1 = speedWeapon1[LoadSavedData.SpeedWeapon1];
        //DamageWeapon2 = damageWeapon2_1 +
    }
}
