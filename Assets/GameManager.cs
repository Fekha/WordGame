using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<TMP_InputField> guessFields;
    private List<string> wordsToGuess = new List<string>() { "chris", "trust" , "prize" };
    private string wordToGuess="";
    public TMP_Text scoreText;
    public TMP_Text guessCountText;
    public GameObject instructionWindow;
    private int guessCount = 0;
    private int score = 0;
    public void GuessClicked()
    {
        if (wordToGuess == "") {
            wordToGuess = wordsToGuess[Random.Range(0, wordsToGuess.Count)];
        }
        if (score == 100)
        {
            guessCount = 0;
        }
        score = 0;
        guessCount++;
        for(int i = 0; i < guessFields.Count; i++)
        {
            var letterToGuess = guessFields[i].text.ToLower();
            if (wordToGuess[i].ToString() == letterToGuess)
            {
                score = score + 20;
            }
            else if (wordToGuess.Contains(letterToGuess))
            {
                score = score + 10;
            }
        }
        scoreText.text = "Similarity: " + score;
        guessCountText.text = "Guess Count: " + guessCount;
        if (score == 100)
        {
            wordToGuess = wordsToGuess[Random.Range(0, wordsToGuess.Count)];
        }
    }
    public void InstructionCloser(bool close) {
        instructionWindow.SetActive(close);
    }
}
