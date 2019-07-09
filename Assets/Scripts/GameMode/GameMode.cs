using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {
    // ポーカーの役一覧
    enum PokerHand : byte {
        StraightFlush = 1,
        FourOfAKind = 2,
        FullHouse = 3,
        Flush = 4,
        Straight = 5,
        ThreeOfAKind = 6,
        TwoPair = 7,
        OnePair = 8,
    }

    [SerializeField] public static int[] gameModeIndexArray;
    [SerializeField] public static int currentGameModeIndex = 1;
    // カード保管用(ポーカーなら5毎,BJならバーストまで) FIFOで処理
    [SerializeField] public static Dictionary<int, int> cardSlotLimitation = new Dictionary<int, int>() { { 1, 5 }, { 2, 12 } }; // <gameModeIndex,cardSlotListのmaxCount>
    [SerializeField] public static GameObject[] cardSlotArray;
    [SerializeField] public static int currentCardSlotIndex = 0;
    [SerializeField] private PokerHand pokerHand;
    
    void Start() {
        cardSlotArray = new GameObject[cardSlotLimitation[currentGameModeIndex]];
    }

    public static void AddCardObject(GameObject card) {
        cardSlotArray[currentCardSlotIndex] = card;
        UIManager.DrawCardList(currentCardSlotIndex,cardSlotArray);
        currentCardSlotIndex++;
        if(currentCardSlotIndex >= cardSlotLimitation[currentGameModeIndex]) {
            currentCardSlotIndex = 0;
        }
        // TODO: 役をチェックする
    }

    public Card GetStrongerCard(Card card1, Card card2) {
        return card1;
    }
}
