using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonRay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Image ImageWeapon2_2;
    private bool isPressed;
    private bool isTimerWork;
    [SerializeField] private float maxTimer;
    private void Awake()
    {
        ImageWeapon2_2 = GameObject.FindGameObjectWithTag("RayOfHope_2").GetComponent<Image>();
        ImageWeapon2_2.fillAmount = 0;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
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
            yield return new WaitForSecondsRealtime(0.1f);
            timer += 0.1f;
        }
        if (timer >= 10)
        {
            EventManager.ShootChargedLaser(maxDamage);
            EventManager.ChangeJoystick(1);
            StopCoroutine(Timer(maxDamage));
        }
        if (!isPressed)
        {
            EventManager.ShootChargedLaser((int)damage);
            EventManager.ChangeJoystick(1);
            StopCoroutine(Timer(maxDamage));
        }
    }
}
