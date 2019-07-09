using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private static GameObject cardSlotListUI;

    private static int score = 0;
    private static int highScore = 0;

    public static GameObject CardSlotListUI { get => cardSlotListUI; set => cardSlotListUI = value; }

    void Start() {
        CardSlotListUI = GameObject.FindWithTag("CardSlotList");
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "SCORE : " + score.ToString();
        highScoreText.text = "HIGH SCORE : " + highScore.ToString();
    }

    public static void AddScore(int point) {
        score += point;
        if (score >= highScore) {
            highScore = score;
        }
    }

    public static void DrawCardList(int index, GameObject[] cardSlotArray) {
        CardSlotListUI.transform.GetChild(index).GetComponent<Image>().sprite = cardSlotArray[index].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        CardSlotListUI.transform.GetChild(index).GetComponent<Image>().color = new Color(255,255, 255, 0.5f);
    }
}
