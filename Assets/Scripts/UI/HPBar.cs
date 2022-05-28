using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    private float currentHp;
    private float MaxHp;
    [SerializeField] private Image hpBar;
    private Text textHP;
    private void Awake()
    {
        EventManager.TakeDamageEvent += TakeDamage;
        EventManager.TakeHPEvent += TakeHP;

        textHP = GetComponentInChildren<Text>();
        MaxHp = PlayerParametrs.MaxHp;
        currentHp = MaxHp;
        UpdateUI();
    }
    private void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            EventManager.Win(false);
        UpdateUI();
    }
    private void TakeHP(int damage)
    {
        currentHp += damage;
        UpdateUI();
    }
    private void UpdateUI()
    {
        textHP.text = $"{currentHp} / {MaxHp}";
        hpBar.fillAmount = currentHp / MaxHp;
    }
    private void OnDestroy()
    {
        EventManager.TakeDamageEvent -= TakeDamage;
        EventManager.TakeHPEvent -= TakeHP;
    }
}
