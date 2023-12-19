using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<TMP_InputField> guessFields;
    private string wordToGuess = "Chris";
    public TMP_Text scoreText;

    public void GuessClicked()
    {
        wordToGuess = wordToGuess.ToUpper();
        var score = 0;
        for(int i = 0; i < guessFields.Count; i++)
        {
            var letterToGuess = guessFields[i].text.ToUpper();
            if (wordToGuess[i].ToString() == letterToGuess)
            {
                score = score + 20;
            }
            else if (wordToGuess.Contains(letterToGuess))
            {
                score = score + 10;
            }
        }
        scoreText.text = "Your Score is:" + score;
    }
}
