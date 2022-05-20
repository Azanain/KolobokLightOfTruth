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
            StartCoroutine(Timer(maxDamage));
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ImageWeapon2_2.fillAmount = 0;
        isPressed = false;
        AimingLaser = false;
        isTimerWork = false;
    }
    private IEnumerator Timer(int maxDamage)
    {
        float timer = 0;
        float damage = PlayerParametrs.DamageWeapon2_2Min;
        while (isPressed)
        {
            ImageWeapon2_2.fillAmount = timer / maxTimer;
            damage = maxDamage * ImageWeapon2_2.fillAmount;
            forceDiscarding = 20 * ImageWeapon2_2.fillAmount;
            yield return new WaitForSecondsRealtime(0.1f);
            timer += 0.1f;
        }
        if (timer >= 10)
        {
            EventManager.ShootChargedLaser(maxDamage);
            EventManager.Discarding(20);
            StopCoroutine(Timer(maxDamage));
        }
        if (!isPressed)
        {
            EventManager.ShootChargedLaser((int)damage);
            EventManager.Discarding(forceDiscarding);
            StopCoroutine(Timer(maxDamage));
        }
    }
}
