using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescription = new List<string>();

    List<string> actionLog = new List<string>();


    // Use this for initialization
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string LogAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = LogAsText;
    }


    public void DisplayRoomText()
    {
        UnpackRoom();

        ClearNewRoom();

        string JoinInterDiscriptons = string.Join("\n", interactionDescription.ToArray());

        string combinedText = roomNavigation.currentRoom.discription + "\n" + JoinInterDiscriptons;

        LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpacksExitRoom();
    }

    void ClearNewRoom()
    {
        interactionDescription.Clear();
        roomNavigation.ClearExits();
    }


    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
