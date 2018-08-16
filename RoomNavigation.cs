using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpacksExitRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
                
        {
            exitDictionary.Add(currentRoom.exits [i].keyString, currentRoom.exits [i].valueRoom);
            controller.interactionDescription.Add (currentRoom.exits [i].exitDescription);
        }
    }

        public void AttemptChangeRooms(string directionoun)
    { 
        if (exitDictionary.ContainsKey(directionoun))
        { 
            currentRoom = exitDictionary [directionoun];
            controller.LogStringWithReturn("You Head to " + directionoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("There is no path to " + directionoun);
        }
    }
    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
