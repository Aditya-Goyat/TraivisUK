using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room : MonoBehaviour
{
    public TMP_Text Name;

    public void JoinRoom()
    {
        GameObject.Find("RoomSelection").GetComponent<RoomSelection>().JoinRoomInList(Name.text);
    }
}
