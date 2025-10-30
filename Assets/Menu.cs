using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private TextMeshProUGUI currencyTextUI;

    private void OnGUI()
    {
        currencyTextUI.text = LevelManager.main.currency.ToString();
    }
    public void SetSelected()
    {

    }
}
