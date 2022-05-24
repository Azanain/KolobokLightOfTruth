using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonRay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Image ImageWeapon2_2;
    private bool isPressed;
    private bool isTimerWork;
    [Range(4,20)]private float forceDiscarding;
    [SerializeField] private float maxTimer;
    public static bool AimingLaser { get; private set; }
    public static int WeaponDamage2_2 { get; private set; }

    private void Awake()
    {
        ImageWeapon2_2 = GameObject.FindGameObjectWithTag("RayOfHope_2").GetComponent<Image>();
        ImageWeapon2_2.fillAmount = 0;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        AimingLaser = true;
        if (!isTimerWork && ButtonSiclkleHit.ButtonLaserCharge)
        {
            int maxDamage = PlayerParametrs.DamageWeapon2_2Max;
            StartCoroutine(Timer());
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ImageWeapon2_2.fillAmount = 0;
        isPressed = false;
        AimingLaser = false;
        isTimerWork = false;
    }
    private IEnumerator Timer()
    {
        float damage = 1;
        float timer = 0;
        //WeaponDamage2_2 = PlayerParametrs.DamageWeapon2_2Min;
        while (isPressed)
        {
            ImageWeapon2_2.fillAmount = timer / maxTimer;
            damage = PlayerParametrs.DamageWeapon2_2Max * ImageWeapon2_2.fillAmount;
            forceDiscarding = 20 * ImageWeapon2_2.fillAmount;
            yield return new WaitForSecondsRealtime(0.1f);
            timer += 0.1f;
        }
        if (timer >= 10)
        {
            WeaponDamage2_2 = (int)damage;
            EventManager.ShootChargedLaser(WeaponDamage2_2);
            EventManager.Discarding(20);
            StopCoroutine(Timer());
        }
        if (!isPressed)
        {
            WeaponDamage2_2 = PlayerParametrs.DamageWeapon2_2Max;
            EventManager.ShootChargedLaser((int)WeaponDamage2_2);
            EventManager.Discarding(forceDiscarding);
            StopCoroutine(Timer());
        }
    }
}
