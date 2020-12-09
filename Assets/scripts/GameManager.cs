using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //手札にカードを生成

    [SerializeField] Transform playerHandTransform;
    [SerializeField] CardController cardPrefab;
    void Start()
    {
        CreateCard(playerHandTransform);
    }

    void CreateCard(Transform hand)
    {
        CardController card = Instantiate(cardPrefab, hand, false);
        card.Init(2);
        // CardController card = Instantiate(cardPrefab, hand, false);
        // for(int x = 1;x <= 4; x++)
        // {
        // CardController card = Instantiate(cardPrefab, hand, false);
        // card.Init(x);
        // }
    }  
}
