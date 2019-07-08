using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private static List<Image> cardSlotImageList = new List<Image>();
    [SerializeField] public static List<GameObject> cardObjectKeppList = new List<GameObject>();

    private static int score = 0;
    private static int highScore = 0;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "SCORE : "+ score.ToString();
        highScoreText.text = "HIGH SCORE : " + highScore.ToString();
    }

    public static void AddScore(int point) {
        score += point;
        if(score >= highScore) {
            highScore = score;
        }
    }

    public static void DrawCardSlotImage(int slotIndex,GameObject card) {
        cardObjectKeppList[slotIndex] = card;
        cardSlotImageList[slotIndex].sprite = card.transform.GetComponentInChildren<SpriteRenderer>().sprite;
    }
}
