using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_InputField guessField;
    private List<string> wordsToGuess = new List<string>() { "chris", "trust" , "prize" , "eagle" , "extra" , "jazzy", "dizzy" , "quick" , "jerky" , "trick" , "jelly" , "about" , "brain" , "brand" , "bread" , "break" , "alert" , "carry" , "catch" , "cause" , "chain" , "beach" , "cream" , "crime" , "cross" , "crowd" , "award" , "civil" , "brief" , "broke" , "debut" , "doubt" , "dozen" , "equal" , "error" , "every" , "extra" , "faith" , "guest" , "dealt" , "guide" , "heavy" , "night" , "funny" , "fifth" , "eager" , "earth" , "eight" , "first" , "input" , "metal" , "noted" , "month" , "ocean" , "learn" , "magic" , "mayor" , "paper" , "party" , "route" , "royal" , "scale" , "scene" , "refer" , "plain" , "proud" , "share" , "shelf" , "table" , "split" , "tower" , "trade" , "treat" , "truck" , "solve" , "upset" , "whole" , "valid" , "wrong" , "wheel" , "vital" , "voice" , "story" , "south" , "third" , "smart"};
    private string wordToGuess="";
    public TMP_Text scoreText;
    public TMP_Text guessCountText;
    public GameObject instructionWindow;
    private int guessCount = 0;
    private int score = 0;
    public GameObject guessRecordPrefab;
    public GameObject content;
    public void GuessClicked()
    {
        if (wordToGuess == "") {
            wordToGuess = wordsToGuess[Random.Range(0, wordsToGuess.Count)];
        }
        guessField.text = guessField.text.ToLower();
        if (score == 100)
        {
            guessCount = 0;
        }
        score = 0;
        guessCount++;
        for(int i = 0; i < 5; i++)
        {
            if (guessField.text.Length > i)
            {
                if (wordToGuess[i] == guessField.text[i])
                {
                    score = score + 20;
                }
                else if (wordToGuess.Contains(guessField.text[i]))
                {
                    score = score + 10;
                }
            }
        }
        scoreText.text = "Similarity: " + score;
        guessCountText.text = "Guess Count: " + guessCount;
        if (score == 100)
        {
            wordToGuess = wordsToGuess[Random.Range(0, wordsToGuess.Count)];
        }
        var guessRecord = Instantiate(guessRecordPrefab, content.transform);
        guessRecord.transform.Find("Guess").GetComponent<TextMeshProUGUI>().text = guessField.text;
        guessRecord.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
    public void InstructionCloser(bool close) {
        instructionWindow.SetActive(close);
    }
}
