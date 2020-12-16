using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Random;
// using System.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerHandTransform,
                               playerFieldTransform,
                               enemyHandTransform,
                               enemyFieldTransform;   
    [SerializeField] CardController cardPrefab;

    bool isPlayerTurn;

    List<int> playerDeck = new List<int>() {1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10},
              enemyDeck  = new List<int>() {1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10};
              
     [SerializeField] Text playerHeroHpText;
     [SerializeField] Text enemyHeroHpText;
     int playerHeroHp;
     int enemyHeroHp;

     [SerializeField] Text playerHeroManaText;///
     [SerializeField] Text enemyHeroManaText;///
     int playerHeroMana;///
     int enemyHeroMana; ///

     [SerializeField] Text ResultText;///
     string resultText;///
     public GameObject ResultPanel;///


    //シングルトン化（どこからでもアクセス可能）
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartGame();
        isPlayerTurn = true;
        TurnCalc();
    }

    void StartGame()
    {
        ResultPanel.SetActive (false);
        playerHeroHp = 30;
        enemyHeroHp = 30;
        playerHeroMana = 4; ///
        enemyHeroMana = 4;  ///
        ShowHeroHp();
        ShowHeroMana();///
        SettingInHand();
    }

    void ReStart()
    {
        Start();
        
    }

    void SettingInHand()
    {
        //カードそれぞれを4枚敵と自分に配る
        for(int x = 0; x<4; x++)
        {
        GiveCardToHand(playerDeck, playerHandTransform);
        GiveCardToHand(enemyDeck, enemyHandTransform);
        }
    }

    void GiveCardToHand(List<int> deck, Transform hand)
    {
        if(deck.Count == 0)
        {
            return;
        }
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard(cardID, hand);
    }
    
    void CreateCard(int cardID, Transform hand)
    {
        CardController card = Instantiate(cardPrefab, hand, false);
        card.Init(cardID); 
    }  

    void TurnCalc()
    {
        if(isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        if(isPlayerTurn)
        {
            GiveCardToHand(playerDeck, playerHandTransform);
        }
        else
        {
            GiveCardToHand(enemyDeck, enemyHandTransform);    
        }
        TurnCalc();
    }

    void PlayerTurn()
    {
        Debug.Log("あなたのターン");
        //フィールドのカードを攻撃可能にする
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        foreach (CardController card in playerFieldCardList)
        {
            card.SetCanAttack(true);  // cardを攻撃可能にする
        }

    }

    void EnemyTurn()
    {
        Debug.Log("敵のターン");
        //手札のカードリストを取得
        CardController[] handCardList = enemyHandTransform.GetComponentsInChildren<CardController>();
        //場に出すカードを選択
        CardController enemyCard = handCardList[0];
        //カードを移動
        enemyCard.movement.SetCardTransform(enemyFieldTransform);

        /*攻撃*/
        //敵フィールドのカードリストを取得
        CardController[] enemyFieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        //攻撃可能カードを取得
        CardController[] enemyCanAttackCardList = Array.FindAll(enemyFieldCardList, card => card.model.canAttack);
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();

        if(enemyCanAttackCardList.Length > 0 && playerFieldCardList.Length > 0)
        {
         //attackerカードを選択
         CardController attacker = enemyCanAttackCardList[0];
         //defenderカードを選択
         CardController defender = playerFieldCardList[0];
         //attackerとdefenderを戦わせる
         CardsBattle(attacker, defender);
        }

        ChangeTurn();
    }

    public void CardsBattle(CardController attacker, CardController defender)
    {
        Debug.Log("CardsBattle");

        attacker.Attack(defender);
        attacker.CheckAlive();
        defender.CheckAlive();
        ShowHeroHp();
        //反撃の実装は1部のカードのみ適用
        // defender.model.Attack(attacker);
    }

    void ShowHeroHp()
    {
        playerHeroHpText.text = playerHeroHp.ToString();
        enemyHeroHpText.text = enemyHeroHp.ToString();
    }

    void ShowHeroMana() ///
    {
        playerHeroManaText.text = playerHeroMana.ToString();
        enemyHeroManaText.text = enemyHeroMana.ToString();
    } ///

    void ShowResultText()///
    {
        if(enemyHeroHp <= 0)
        {
            resultText = "WIN";
            ResultText.text = resultText.ToString();
        }
        else
        {
            resultText = "ROSE";
            ResultText.text = resultText.ToString();
        }
    }///

    public void AttackToHero(CardController attacker, bool isPlayerCard)
    {
        if(isPlayerCard)
        {
            enemyHeroHp -= attacker.model.at;     
            if(enemyHeroHp <= 0)　//ここから追加
            {
                enemyHeroHp = 0;　
                ResultPanel.SetActive (true);
                ShowResultText();
            }                     //ここまで追加

        }
        else
        {
            playerHeroHp -= attacker.model.at;
            if(playerHeroHp <= 0) ///ここから追加
            {
                playerHeroHp = 0;
                ResultPanel.SetActive (true);
                ShowResultText();
            }                     ///ここまで追加
        }
        attacker.SetCanAttack(false);
        ShowHeroHp();
    }
}
