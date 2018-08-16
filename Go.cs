using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction

{
    public override void ResopondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.roomNavigation.AttemptChangeRooms (seperatedInputWords [1]);

    }
}
