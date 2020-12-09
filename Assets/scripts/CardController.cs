using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view;
    CardModel model;

    public void Awake()
    {
        view = GetComponent<CardView>();
    }

    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
}
