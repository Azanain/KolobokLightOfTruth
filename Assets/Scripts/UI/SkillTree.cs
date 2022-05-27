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
            //щит веры
            case "ButtonSkill_1":
                descriptionSkill = "Подвижность I: + 10% к скорости и уклонению.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_2":
                descriptionSkill = "Подвижность II: + 20% к скорости и уклонению.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_3":
                descriptionSkill = "Подвижность III: + 30% к скорости и уклонению.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_4":
                descriptionSkill = "Дальность рывка + 25%";
                NumberSkill(nameButton);
                break;
            //луч надежды
            case "ButtonSkill_5":
                descriptionSkill = "Обжигание I: урон + 10%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_6":
                descriptionSkill = "Обжигание II: урон + 20%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_7":
                descriptionSkill = "Обжигание III: урон + 30%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_8":
                descriptionSkill = "Обжигание IV: урон + 40%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_9":
                descriptionSkill = "Луч надежды II: ярость солнца.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_10":
                descriptionSkill = "Разогрев: уменьшение времени зарядки.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_11":
                descriptionSkill = "Стойкость: уменьшение отдачи на 100%.";
                NumberSkill(nameButton);
                break;
            //слово силы
            case "ButtonSkill_12":
                descriptionSkill = "Разрушение: урон + 20%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_13":
                descriptionSkill = "Разрушение: урон + 40%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_14":
                descriptionSkill = "Разрушение: урон + 60%.";
                NumberSkill(nameButton);
                break;
            case "ButtonSkill_15":
                descriptionSkill = "Отбрасывание + 50%.";
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
