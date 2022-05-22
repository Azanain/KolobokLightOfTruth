using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSkill : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.ButtonName(this.gameObject.name);
    }
}
