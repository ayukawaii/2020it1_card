using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カードデータそのものとその処理
public class CardModel
{
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;

    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card"+cardID);
        hp = cardEntity.hp;
        at = cardEntity.at;
        cost = cardEntity.cost;
        icon = cardEntity.icon;
    }
}
