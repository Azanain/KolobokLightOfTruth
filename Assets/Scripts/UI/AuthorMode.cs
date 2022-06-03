using UnityEngine;
using UnityEngine.EventSystems;

public class AuthorMode : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.AddTotalMoney(100000);
    }
}
