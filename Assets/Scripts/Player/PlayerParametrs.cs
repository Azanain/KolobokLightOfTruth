public class PlayerParametrs
{
    //основной режим
    public static float TimeReloadWeapon1 { get; private set; } = 3;
    public static float TimeReloadWeapon3 { get; private set; } = 5;

    public static int DamageWeapon1Min { get; private set; } = 1;
    public static int DamageWeapon1Max { get; private set; } = 30;
    public static int DamageWeapon2 { get; private set; } = 2;
    public static int DamageWeapon3 { get; private set; } = 5;
    //заряженный режим
    public static float TimeReloadWeapon1_2 { get; private set; } = 3;
    public static float TimeReloadWeapon2_2 { get; private set; } = 10;
    public static float TimeReloadWeapon3_2 { get; private set; } = 15;

    public static int DamageWeapon2_2Min { get; private set; } = 6;
    public static int DamageWeapon2_2Max { get; private set; } = 30;
    public static int DamageWeapon3_2 { get; private set; } = 10;
    //персонаж
    public static int MaxHp { get; private set; } = 100;
    public static float Speed { get; private set; } = 5;
}
