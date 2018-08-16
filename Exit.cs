using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] // This display the exit inside the inspector 
public class Exit
{
    public string keyString; // this is the keyword
    public string exitDescription; // displays the room in the text field
    public Room valueRoom; 

}
