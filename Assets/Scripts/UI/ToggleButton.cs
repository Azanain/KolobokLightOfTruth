using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite activeSprite;
    public Sprite inactiveSprite;
    public GameObject panel;
    public bool state;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setToggleButton()
    {
        if (state)
        {
            GetComponent<Image>().sprite = activeSprite;
        }
        else
        {
            GetComponent<Image>().sprite = inactiveSprite;
        }

        panel.SetActive(!state);
        state = !state;
    }
}
