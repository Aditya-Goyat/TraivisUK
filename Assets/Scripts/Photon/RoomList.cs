using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject RoomPrefab;
    public GameObject[] AllRooms;

/*    private void Start()
    {
        PhotonNetwork.GetCustomRoomList(TypedLobby.Default);
    }*/

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log(10);
            for(int i = 0; i < AllRooms.Length; i++)
            {
                if (AllRooms[i] != null)
                    Destroy(AllRooms[i]);
            }

            AllRooms = new GameObject[roomList.Count];

            for(int i = 0; i < roomList.Count; i++)
            {
                Debug.Log(100 + i);
                if (roomList[i].IsOpen && roomList[i].IsVisible && roomList[i].PlayerCount >= 1)
                {
                    Debug.Log(200 + i);
                    GameObject Room = Instantiate(RoomPrefab, GameObject.Find("Content").transform);
                    Room.GetComponent<Room>().Name.text = roomList[i].Name;

                    AllRooms[i] = Room;
                }
            }
        }
}
