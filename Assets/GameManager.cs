using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public TMP_InputField guessField;
    public TMP_Text errorText;
    private List<string> wordsToGuess = new List<string>();
    private string wordToGuess="";
    private int score = 0;
    public GameObject guessRecordPrefab;
    public GameObject content;
    private List<GameObject> guessRecords = new List<GameObject>();
    void Start()
    {
        TextAsset wordList = Resources.Load<TextAsset>("5LetterWords");
        wordsToGuess = FilterWordsWithoutDuplicates(wordList.text.Split('\n'));
    }

    private void GuessClicked()
    {
        errorText.text = "";
        if (wordToGuess == "") {
            wordToGuess = wordsToGuess[Random.Range(0, wordsToGuess.Count)];
        }
        guessField.text = guessField.text.ToLower();
        if (score == 100)
        {
            foreach (var record in guessRecords)
            {
                Destroy(record);
            }
            guessRecords.Clear();
        }
        score = 0;
        for(int i = 0; i < 5; i++)
        {
            if (guessField.text.Length > i)
            {
                if (wordToGuess[i] == guessField.text[i])
                {
                    score = score + 20;
                }
                else if (guessField.text.Contains(wordToGuess[i]))
                {
                    score = score + 10;
                }
            }
        }
        if (score == 100)
        {
            wordToGuess = wordsToGuess[Random.Range(0, wordsToGuess.Count)];
        }
        var guessRecord = Instantiate(guessRecordPrefab, content.transform);
        guessRecord.transform.Find("Guess").GetComponent<TextMeshProUGUI>().text = guessField.text;
        guessRecord.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
        guessRecords.Add(guessRecord);
        guessField.text = "";
    }

    internal void Type(string letter)
    {
        if (letter == "backspace")
        {
            if (guessField.text.Length > 0)
            {
                guessField.text = guessField.text.Substring(0, guessField.text.Length - 1);
            }
        }
        else if (letter == "enter")
        {
            if (HasDuplicateLetters(guessField.text))
            {
                errorText.text = "Your guess may not contain duplicate letters";
            }
            else if (guessField.text.Length != 5)
            {
                errorText.text = "Your guess must contain 5 letters";
            }
            else if (!wordsToGuess.Contains(guessField.text))
            {
                errorText.text = "Your guess must be a real word";
            }
            else
            {
                GuessClicked();
            }
        }
        else
        {
            if (guessField.text.Length < 5)
                guessField.text += letter;
        }
    }
    private List<string> FilterWordsWithoutDuplicates(string[] words)
    {
        List<string> filteredWords = new List<string>();

        foreach (string word in words)
        {
            if (!HasDuplicateLetters(word))
            {
                filteredWords.Add(word);
            }
        }

        return filteredWords;
    }
    static bool HasDuplicateLetters(string word)
    {
        HashSet<char> encounteredCharacters = new HashSet<char>();

        foreach (char letter in word)
        {
            if (!encounteredCharacters.Add(letter))
            {
                return true;
            }
        }

        return false;
    }
}
