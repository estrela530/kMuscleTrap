using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PunManager : MonoBehaviour
{
    public Text textStatus;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("version1");
    }

    void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        //部屋に参加、存在しないとき作成して参加
        PhotonNetwork.JoinOrCreateRoom("Room1", roomOptions, TypedLobby.Default);

    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            //Photonへの接続状況表示
            Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
            textStatus.text = PhotonNetwork.connectionStateDetailed.ToString();
        }
        else
        {
            textStatus.text = "Connect to the room" + PhotonNetwork.room.Name +
                "Players Online" + PhotonNetwork.room.PlayerCount + "Master : " 
                + PhotonNetwork.isMasterClient;
        }
    }
}
