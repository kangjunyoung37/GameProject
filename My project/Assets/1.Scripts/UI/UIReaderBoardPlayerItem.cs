using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIReaderBoardPlayerItem : MonoBehaviourPunCallbacks
{
    #region Serialize Field
    
    [Title(label:"TMP_Text")]
    [SerializeField]
    TMP_Text playerName;

    [SerializeField]
    TMP_Text killCount;

    [SerializeField]
    TMP_Text deathCount;

    #endregion
    public Player player;

    public void SetUp(Player player)
    {
        this.player = player;
        playerName.text = player.NickName;
        killCount.text = player.CustomProperties["Kill"].ToString();
        deathCount.text = player.CustomProperties["Death"].ToString();

    }

    public void ChangePlayerKillDeath()
    {
        killCount.text = player.CustomProperties["Kill"].ToString();
        deathCount.text = player.CustomProperties["Death"].ToString();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}