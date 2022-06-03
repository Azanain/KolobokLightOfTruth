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
        EventManager.TransferMoneyEvent += TransferMoney;
    }
    private void Start()
    {
        TotalMoney = LoadSavedData.TotalMoney;
        UpdateText();
    }
    /// <summary>
    /// ���������� ������
    /// </summary>
    private void UpdateText()
    {
        textCurrentMoney.text = currentMoney.ToString();
        textTotalMoney.text = TotalMoney.ToString();
    }
    /// <summary>
    /// ������� ����� ������������ �� ������ � ����� ����
    /// </summary>
    private void TransferMoney()
    {
        TotalMoney += currentMoney;
        currentMoney = 0;
    }
    /// <summary>
    /// + � ������� �������
    /// </summary>
    /// <param name="money"></param>
    private void AddCurrentMoney(int money)
    {
        currentMoney += money;
        UpdateText();
    }
    /// <summary>
    /// + � ����� �������
    /// </summary>
    /// <param name="money"></param>
    private void AddTotalMoney(int money)
    {
        TotalMoney += money;
        UpdateText();
    }
    /// <summary>
    /// ����� ������
    /// </summary>
    private void AuthorMode()
    {
        TotalMoney = int.MaxValue;
        EventManager.SaveData();
        UpdateText();
    }
    private void OnDestroy()
    {
        EventManager.AddCurrentMoneyEvent -= AddCurrentMoney;
        EventManager.AddTotalMoneyEvent -= AddTotalMoney;
        EventManager.AuthorModeEvent -= AuthorMode;
        EventManager.TransferMoneyEvent -= TransferMoney;
    }
}
