﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
         /*攻撃*/
        //attackerカードを選択
        CardController attacker = eventData.pointerDrag.GetComponent<CardController>();
        //defenderカードを選択
        CardController defender = GetComponent<CardController>();

        if(attacker == null || defender == null)
        {
            return;
        }

        if(attacker.model.canAttack)
        {
         //attackerとdefenderを戦わせる
         GameManager.instance.CardsBattle(attacker, defender);
        }

    }
}
