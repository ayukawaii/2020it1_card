using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] Text atText;
    [SerializeField] Image iconImage;
    [SerializeField] GameObject SelectablePanel;

    public void Show(CardModel cardModel)
    {
        hpText.text = cardModel.hp.ToString();
        atText.text = cardModel.at.ToString();
        iconImage.sprite = cardModel.icon;
    }

    public void Refresh(CardModel cardModel)
    {
        hpText.text = cardModel.hp.ToString();
        atText.text = cardModel.at.ToString();
    }

    public void SetActiveSelectablePanel(bool flag)
    {
        SelectablePanel.SetActive(flag);
    }

}
