using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource shoot;

    public void ShootWeapon2()
    {
        shoot.Play();
    }
}
