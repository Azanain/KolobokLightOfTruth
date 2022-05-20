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
                descriptionSkill = "����������� I: + 10% � �������� � ���������.";
                name = name.Substring(name.Length - 2, 2);
                //string numberSkill = numberSkill.Substring(numberSkill.Length - 2, 2);
                Debug.Log($"name = {name}, number = {name}");
                //UpdateText(name);
                break;
            case "ButtonSkill_2":
                descriptionSkill = "����������� II: + 20% � �������� � ���������.";
                //UpdateText(name);
                break;
            case "ButtonSkill_3":
                descriptionSkill = "����������� III: + 30% � �������� � ���������.";
                //UpdateText(name);
                break;
            case "ButtonSkill_4":
                descriptionSkill = "����������� IV: + 50% � �������� � ���������.";
                //UpdateText(name);
                break;
            case "ButtonSkill_5":
                descriptionSkill = "��� ���� II: �����.";
                //UpdateText(name);
                break;
            case "ButtonSkill_6":
                descriptionSkill = "��������� �����.";
                //UpdateText(name);
                break;
            case "ButtonSkill_7":
                descriptionSkill = "�������� �����.";
                //UpdateText(name);
                break;

            case "ButtonSkill_8":
                descriptionSkill = "����������: + 20% ����.";
                //UpdateText(name);
                break;
            case "ButtonSkill_9":
                descriptionSkill = "����������: + 40% ����.";
                //UpdateText(name);
                break;
            case "ButtonSkill_10":
                descriptionSkill = "����� ����: ������� �����";
                //UpdateText(name);
                break;
            case "ButtonSkill_11":
                descriptionSkill = "����������: + 60% ����.";
                //UpdateText(name);
                break;
            case "ButtonSkill_12":
                descriptionSkill = "������������: + 50% ������������.";
                //UpdateText(name);
                break;

            case "ButtonSkill_13":
                descriptionSkill = "���������: ���� + 10%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_14":
                descriptionSkill = "���������: ���� + 20%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_15":
                descriptionSkill = "��� ������� II: ������ ������.";
                //UpdateText(name);
                break;
            case "ButtonSkill_16":
                descriptionSkill = "���������: ���� + 30%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_17":
                descriptionSkill = "���������: ���� + 40%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_18":
                descriptionSkill = "��������: ���������� ������� ������� �� 25%.";
                //UpdateText(name);
                break;
            case "ButtonSkill_19":
                descriptionSkill = "���������: ���������� ������ �� 100%.";
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
