using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private Button buySkill;
    private Text textDescription;

    private int priceSkill = 500;
    private string descriptionSkill;
    private bool[] isSkillBought;

    private void Awake()
    {
        //isSkillBought = new bool[19];
        EventManager.ButtonNameEvent += CheckNameSkill;
    }
    private void CheckNameSkill(string name)
    {
        switch (name)
        {
            case "ButtonSkill_1":
                descriptionSkill = "Подвижность I: + 10% к скорости и уклонению.";
                name = name.Substring(name.Length - 2, 2);
                //string numberSkill = numberSkill.Substring(numberSkill.Length - 2, 2);
                Debug.Log($"name = {name}, number = {name}");
                //UpdateText(name);
                break;
            case "ButtonSkill_2":
                descriptionSkill = "Подвижность II: + 20% к скорости и уклонению.";
                //UpdateText(name);
                break;
            case "ButtonSkill_3":
                descriptionSkill = "Подвижность III: + 30% к скорости и уклонению.";
                //UpdateText(name);
                break;
            case "ButtonSkill_4":
                descriptionSkill = "Подвижность IV: + 50% к скорости и уклонению.";
                //UpdateText(name);
                break;
            case "ButtonSkill_5":
                descriptionSkill = "Щит веры II: рывок.";
                //UpdateText(name);
                break;
            case "ButtonSkill_6":
                descriptionSkill = "Дальность рывка.";
                //UpdateText(name);
                break;
            case "ButtonSkill_7":
                descriptionSkill = "Скорость рывка.";
                //UpdateText(name);
                break;

            case "ButtonSkill_8":
                descriptionSkill = "Разрушение: + 20% урон.";
                //UpdateText(name);
                break;
            case "ButtonSkill_9":
                descriptionSkill = "Разрушение: + 40% урон.";
                //UpdateText(name);
                break;
            case "ButtonSkill_10":
                descriptionSkill = "Слово силы: ударная волна";
                //UpdateText(name);
                break;
            case "ButtonSkill_11":
                descriptionSkill = "Разрушение: + 60% урон.";
                //UpdateText(name);
                break;
            case "ButtonSkill_12":
                descriptionSkill = "Отбрасывание: + 50% отбрасывание.";
                //UpdateText(name);
                break;

            case "ButtonSkill_13":
                descriptionSkill = "Обжигание: урон + 10%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_14":
                descriptionSkill = "Обжигание: урон + 20%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_15":
                descriptionSkill = "Луч надежды II: ярость солнца.";
                //UpdateText(name);
                break;
            case "ButtonSkill_16":
                descriptionSkill = "Обжигание: урон + 30%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_17":
                descriptionSkill = "Обжигание: урон + 40%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_18":
                descriptionSkill = "Разогрев: уменьшение времени зарядки на 25%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_19":
                descriptionSkill = "Стойкость: уменьшение отдачи на 100%.";
                //UpdateText(name);
                break;

            default:
                buySkill.interactable = false;
                break;
        }
    }
    //private void UpdateText(string numberSkill)
    //{
    //    textDescription.text = descriptionSkill;
    //    CheckPrice(descriptionSkill);
    //}
    //private void CheckPrice(string numberSkill)
    //{
    //    byte number = byte.Parse(numberSkill);
    //    if (Bank.TotalMoney >= priceSkill && isSkillBought[number])
    //    {
    //        buySkill.interactable = true;
    //    }
    //    else if (Bank.TotalMoney < priceSkill || !isSkillBought[number])
    //    {
    //        buySkill.interactable = false;
    //    }
    //}
    private void OnDestroy()
    {
        EventManager.ButtonNameEvent -= CheckNameSkill;
    }
}
