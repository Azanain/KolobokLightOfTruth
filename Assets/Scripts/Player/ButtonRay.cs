using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonRay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Image ImageWeapon2_2;
    private bool isPressed;
    private bool isTimerWork;
   // [Range(4,20)]private float forceDiscarding;
    [SerializeField] private float maxTimer;
    public static int DamageWeapon2_2 { get; private set; }

    private void Awake()
    {
        ImageWeapon2_2 = GameObject.FindGameObjectWithTag("RayOfHope_2").GetComponent<Image>();
        ImageWeapon2_2.fillAmount = 0;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        EventManager.CanMove();
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
        EventManager.CanMove();
        isTimerWork = false;
    }
    private IEnumerator Timer()
    {
        float damage = 1;
        float timer = 0;
        while (isPressed)
        {
            ImageWeapon2_2.fillAmount = timer / maxTimer;
            damage = PlayerParametrs.DamageWeapon2_2Max * ImageWeapon2_2.fillAmount;
            //forceDiscarding = 20 * ImageWeapon2_2.fillAmount;
            yield return new WaitForSecondsRealtime(0.1f);
            timer += 0.1f;
        }
        if (!isPressed && timer < 10)
        {
            EventManager.ShootChargedLaser((int)damage);
            DamageWeapon2_2 = (int)damage;
            EventManager.Discarding(PlayerParametrs.RecliningFromWeapon2_2);
            StopCoroutine(Timer());
        
        }
        else if (!isPressed && timer >= 10)
        {
            EventManager.ShootChargedLaser(PlayerParametrs.DamageWeapon2_2Max);
            EventManager.Discarding(PlayerParametrs.RecliningFromWeapon2_2);
            StopCoroutine(Timer());
        }
    }
}
