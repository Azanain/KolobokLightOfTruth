using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileContr : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystick;
    private Image joystickBG;
  
    private Vector2 inputVector; //получение координаты джостика

    private void Start()
    {
        joystick = GetComponentInChildren<Image>();
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero; //возврат джостика в центр
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x); //получение координат позиции касания на джостик
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1); //установка точных координат из касания
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return -inputVector.y;
        else
        { 
            return Input.GetAxis("Horizontal") ;
        }
    }

    public float Vertical()
    {
        if (inputVector.x != 0) return inputVector.x;
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
