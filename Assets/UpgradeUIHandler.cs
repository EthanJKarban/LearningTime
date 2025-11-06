using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public bool mouse_over = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        UIManager.main.SetHoverUIState(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        UIManager.main.SetHoverUIState(false);
        gameObject.SetActive(false);
    }
}
