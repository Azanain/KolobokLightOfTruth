using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    private int currentHp;
    private int MaxHp = 100;
    [SerializeField] private Image hpBar;
    private Text textHP;
    private void Awake()
    {
        EventManager.TakeDamageEvent += TakeDamage;
        EventManager.TakeHPEvent += TakeHP;

        textHP = GetComponentInChildren<Text>();
        currentHp = MaxHp;
    }
    private void TakeDamage(int damage)
    {
        currentHp -= damage;
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
