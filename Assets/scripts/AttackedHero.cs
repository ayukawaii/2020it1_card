using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedHero : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
         /*攻撃*/
        //attackerカードを選択
        CardController attacker = eventData.pointerDrag.GetComponent<CardController>();

        if(attacker == null)
        {
            return;
        }

        if(attacker.model.canAttack)
        {
         //attackerとHeroを戦わせる
         GameManager.instance.AttackToHero(attacker, true);
        }
    }
}
