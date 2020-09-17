using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IGvrPointerHoverHandler
{
    public UnityEvent clickEvent;

    public void EnableUI ()
    {
    }

    public void DisableUI ()
    {
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        EnableUI();
    }

    public void OnGvrPointerHover (PointerEventData eventData)
    {
        EnableUI();
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        DisableUI();
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        clickEvent.Invoke();
    }
}
