using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogbookButton : MonoBehaviour
{
    [SerializeField] private GameObject[] textEmtry;
    [SerializeField] private GameObject textEmtryMain;

    public void Clickbutton()
    {
        foreach (var item in textEmtry)
        {
            item.SetActive(false);
        }
        textEmtryMain.SetActive(true);
    }
}
