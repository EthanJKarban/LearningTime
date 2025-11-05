using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager main;

    private bool isHoverUI;

    private void Awake()
    {
        
        
            main = this;
        
    }

    public void SetHoverUIState(bool state)
    {
        isHoverUI = state;
    }
    public bool IsHoverUI()
    {
        return isHoverUI;
    }
}
