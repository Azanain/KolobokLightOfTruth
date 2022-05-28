using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource shootWeapon2_1;
    [SerializeField] private AudioSource shootWeapon2_2;
    [SerializeField] private AudioSource wepon1;
    [SerializeField] private AudioSource wepon3;
    [SerializeField] private AudioSource move;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource landing;
    [SerializeField] private AudioSource charging;
    [SerializeField] private AudioSource hitWall;

    private void Awake()
    {
        EventManager.AudioWeapon1Event += ActivationWeapon1;
        EventManager.AudioWeapon3Event += ActivationWeapon3;
        EventManager.IsChargingLaserEvent += ChargingLaser;
    }
    public void ShootWeapon2_1()
    {
        shootWeapon2_1.Play();
    }
    public void ChargingLaser(bool isCarging)
    {
        if (isCarging)
        { 
            charging.Play();
        }
        else
        {
            charging.Stop();
            shootWeapon2_2.Play();
        }
            
    }
    public void ActivationWeapon1()
    {
        wepon1.Play();
    }
    public void ActivationWeapon3()
    {
        wepon3.Play();
    }
    public void Move()
    {
        move.Play();
    }
    public void Jump()
    {
        jump.Play();
    }
    public void Landing()
    {
        landing.Play();
    }
    public void ChargingLaser()
    {
        charging.Play();
    }
    public void HitWall()
    {
        hitWall.Play();
    }

    private void OnDestroy()
    {
        EventManager.AudioWeapon1Event -= ActivationWeapon1;
        EventManager.AudioWeapon3Event -= ActivationWeapon3;
        EventManager.IsChargingLaserEvent -= ChargingLaser;
    }
}
