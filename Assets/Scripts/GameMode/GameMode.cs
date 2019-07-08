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

    [SerializeField] private int[] gameModeIndexArray;
    [SerializeField] private static int currentGameModeIndex;
    // カード保管用(ポーカーなら5毎,BJならバーストまで) FIFOで処理
    [SerializeField] private static Dictionary<string, int> cardSlotLimitation = new Dictionary<string, int>() {{ "Poker",5},{ "BlackJack",12}}; // <gameModeIndex,cardSlotListのmaxCount>
    [SerializeField] public static List<GameObject> cardSlotList = new List<GameObject>();
    [SerializeField] private static int currentCardSlotIndex = 0;
    [SerializeField] private PokerHand pokerHand;

    public int[] GameModeIndexArray { get => gameModeIndexArray; set => gameModeIndexArray = value; }
    public int CurrentGameModeIndex { get => currentGameModeIndex; set => currentGameModeIndex = value; }
    public List<GameObject> CardSlotList { get => cardSlotList; set => cardSlotList = value; }
    public int CurrentCardSlotIndex { get => currentCardSlotIndex; set => currentCardSlotIndex = value; }
    public Dictionary<string, int> CardSlotLimitation { get => cardSlotLimitation; set => cardSlotLimitation = value; }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    
    // TODO: GameObjectクラスをCardクラスに変更予定
    public static void AddCardToSlot(GameObject card) {
        if(cardSlotList.Count < cardSlotLimitation["Poker"]) {
            cardSlotList.Add(card);
            UIManager.DrawCardSlotImage(cardSlotList.Count,card);
        }
        cardSlotList[currentCardSlotIndex] = card;
        currentCardSlotIndex++;
        if (currentCardSlotIndex >= cardSlotList.Count) {
            currentCardSlotIndex = 0;
        }
        Debug.Log(cardSlotList[0].GetComponent<Card>().name.ToString());
        // TODO: 役のチェック
        // CheckHand();
    }

    public Card GetStrongerCard(Card card1,Card card2) {
        return card1;
    }
}
