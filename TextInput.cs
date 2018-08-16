using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController> ();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower(); // this makes it so it doesnt matter if you use caps or lower case when inputting text.
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);
        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.KeyWord == seperatedInputWords[0])
            {
                inputAction.ResopondToInput(controller, seperatedInputWords);
            }
        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}
