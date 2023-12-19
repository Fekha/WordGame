using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLimit : MonoBehaviour
{
    private TMP_InputField inputField;
    private int characterLimit = 1;

    void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        // Attach the OnValueChanged event to the function that enforces the character limit
        inputField.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    void OnValueChanged()
    {
        // Ensure the text length does not exceed the character limit
        if (inputField.text.Length > characterLimit)
        {
            // Truncate the text to the character limit
            inputField.text = inputField.text.Substring(0, characterLimit);
        }
    }
}
