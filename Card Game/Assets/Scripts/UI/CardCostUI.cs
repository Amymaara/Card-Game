using TMPro;
using UnityEngine;

public class CardCostUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardCost;

    public void UpdateCardCostText(int currentCardCost)
    {
        cardCost.text = currentCardCost.ToString();
    }
}
