[System.Serializable]
public class SavedData
{
    //PlayerParametrs
    public float timeReloadWeapon1;
    public float timeReloadWeapon3;
    public int damageWeapon1;
    public int damageWeapon2;
    public int damageWeapon3;
    public float timeReloadWeapon2_2;
    public int damageWeapon2_2Max;
    public int totalMoney;
    public bool[] isSkillBought;
    //уровент улучшения скила
    public byte improveDashRangeWeapon1;
    public byte improveSpeedWeapon1;
    public byte improveSctageWeapon2;
    public byte improveRecliningFromWeapon2_2;
    public byte improveIimerReloadWeapon2_2;
    public byte improveDamageWeapon3;
    public byte improveForceJumpWeapon3;
    public bool improveIsWeapon2_2;
    //options
    public float valueVolumeMusic;
    public float valueVolumeEffects;
    public bool musicVolumeEnabled;
    public bool effectsVolumeEnabled;
    public bool uIVolumeEnabled;
    //public int maxHp;
    //public float speed;
}
