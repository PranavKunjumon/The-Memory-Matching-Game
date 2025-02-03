using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public GameObject cardPrefab;
    public List<Sprite> cardImages; // Assign in the Inspector
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI winText; // ✅ UI Text to show "You Win!"
    public Button restartButton;

    private List<Card> cards = new List<Card>();
    private Card firstCard, secondCard;
    private int score = 0;
    private int attempts = 0;
    private bool gameWon = false; // ✅ Track if the game is won

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // Hide restart button at start
        winText.gameObject.SetActive(false); // Hide win text at start
        SetupGame();
    }

    private void SetupGame()
    {
        List<Sprite> shuffledSprites = new List<Sprite>(cardImages);
        shuffledSprites.AddRange(cardImages); // Duplicate for pairs
        shuffledSprites = ShuffleList(shuffledSprites);

        for (int i = 0; i < shuffledSprites.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, gridLayout.transform);
            Card cardScript = newCard.GetComponent<Card>();
            cardScript.SetCard(shuffledSprites[i]);
            cards.Add(cardScript);
        }
    }

    public void CardClicked(Card clickedCard)
    {
        if (gameWon) return; // ✅ Prevent clicking after winning

        if (firstCard == null)
        {
            firstCard = clickedCard;
            firstCard.FlipCard(true);
        }
        else if (secondCard == null && clickedCard != firstCard)
        {
            secondCard = clickedCard;
            secondCard.FlipCard(true);
            attempts++;
            attemptsText.text = "Attempts: " + attempts;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard.frontSprite == secondCard.frontSprite) // ✅ Compare sprites directly
        {
            score += 10;
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);

            if (score >= 80) // ✅ Win Condition
            {
                gameWon = true;
                WinGame();
            }
        }
        else
        {
            firstCard.FlipCard(false);
            secondCard.FlipCard(false);
        }

        firstCard = null;
        secondCard = null;
        scoreText.text = "Score: " + score;
    }

    private void WinGame()
    {
        winText.text = "You Win! 🎉";
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    private List<Sprite> ShuffleList(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    private void RestartGame()
    {
        foreach (Card card in cards)
        {
            Destroy(card.gameObject);
        }
        cards.Clear();
        score = 0;
        attempts = 0;
        gameWon = false;
        scoreText.text = "Score: 0";
        attemptsText.text = "Attempts: 0";
        winText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        SetupGame();
    }
}
