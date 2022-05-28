using UnityEngine;
using UnityEngine.UI;
public class Bank : MonoBehaviour
{
    private int currentMoney;
    public static int TotalMoney { get; private set; }
    [SerializeField] private Text textCurrentMoney;
    [SerializeField] private Text textTotalMoney;
    private void Awake()
    {
        EventManager.AddCurrentMoneyEvent += AddCurrentMoney;
        EventManager.AddTotalMoneyEvent += AddTotalMoney;
        EventManager.AuthorModeEvent += AuthorMode;
    }
    private void Start()
    {
        TotalMoney = LoadSavedData.TotalMoney;
        UpdateText();
    }
    private void UpdateText()
    {
        textCurrentMoney.text = currentMoney.ToString();
        textTotalMoney.text = TotalMoney.ToString();
    }
    private void AddCurrentMoney(int money)
    {
        currentMoney += money;
        UpdateText();
    }
    private void AddTotalMoney(int money)
    {
        TotalMoney += money;
        UpdateText();
    }
    private void AuthorMode()
    {
        TotalMoney = int.MaxValue;
        UpdateText();
    }
    private void OnDestroy()
    {
        EventManager.AddCurrentMoneyEvent -= AddCurrentMoney;
        EventManager.AddTotalMoneyEvent -= AddTotalMoney;
        EventManager.AuthorModeEvent -= AuthorMode;
    }
}
