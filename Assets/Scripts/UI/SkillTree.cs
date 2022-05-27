using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private Button buySkill;
    private Text textDescription;
    private Text textPriceSkill;

    private int priceSkill = 500;
    private string descriptionSkill;
    private bool[] isSkillBought;

    private void Awake()
    {
        textDescription = GameObject.Find("TextDescriptionSkill").GetComponent<Text>();
        textPriceSkill =  GameObject.Find("TextPriseSkill").GetComponent<Text>();
        EventManager.ButtonNameEvent += CheckNameSkill;
    }
    private void NumberSkill(string name)
    { 
        string result = name.Substring(name.IndexOf('_', 2));
        result = result.Replace("_",null);
        UpdateText();
        CheckPrice(result);
        Debug.Log($"name = {name}, number = {result}");
    }
    private void CheckNameSkill(string nameButton)
    {
        switch (nameButton)
        {
            //��� ����
            case "ButtonSkill_1":
                descriptionSkill = "����������� I: + 10% � �������� � ���������.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_2":
                descriptionSkill = "����������� II: + 20% � �������� � ���������.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_3":
                descriptionSkill = "����������� III: + 30% � �������� � ���������.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_4":
                descriptionSkill = "��������� ����� + 25%";
                NumberSkill(nameButton);
                break;
            //��� �������
            case "ButtonSkill_5":
                descriptionSkill = "��������� I: ���� + 10%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_6":
                descriptionSkill = "��������� II: ���� + 20%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_7":
                descriptionSkill = "��������� III: ���� + 30%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_8":
                descriptionSkill = "��������� IV: ���� + 40%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_9":
                descriptionSkill = "��� ������� II: ������ ������.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_10":
                descriptionSkill = "��������: ���������� ������� �������.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_11":
                descriptionSkill = "���������: ���������� ������ �� 100%.";
                NumberSkill(nameButton);
                break;
            //����� ����
            case "ButtonSkill_12":
                descriptionSkill = "����������: ���� + 20%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_13":
                descriptionSkill = "����������: ���� + 40%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_14":
                descriptionSkill = "����������: ���� + 60%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_15":
                descriptionSkill = "������������ + 50%.";
                NumberSkill(nameButton);
                break;

            default:
                buySkill.interactable = false;
                break;
        }
    }
    private void UpdateText()
    {
        textDescription.text = descriptionSkill;
        textPriceSkill.text = Bank.TotalMoney + " / " +priceSkill;
    }
    private void CheckPrice(string numberSkill)
    {
        byte number = byte.Parse(numberSkill);
        if (Bank.TotalMoney >= priceSkill && isSkillBought[number])
        {
            buySkill.interactable = true;
        }
        else if (Bank.TotalMoney < priceSkill || !isSkillBought[number])
        {
            buySkill.interactable = false;
        }
    }
    private void OnDestroy()
    {
        EventManager.ButtonNameEvent -= CheckNameSkill;
    }
}
