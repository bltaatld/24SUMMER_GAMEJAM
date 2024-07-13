using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActionManager : MonoBehaviour
{
    public bool notNeedPlayer;
    public GameObject startAction;
    public GameObject playerBasic;
    public Transform player;

    public void AcvtiveAction()
    {
        if (!notNeedPlayer)
        {
            playerBasic = GameObject.Find("PlayerBasics");

            if (playerBasic != null)
            {
                // Find 'Player' object in 'Player Basic' object
                player = playerBasic.transform.Find("Player");

                if (player == null)
                {
                    Debug.LogWarning("Child object with the specified name not found.");
                }
            }

            if (player != null)
            {
                player.GetComponent<PlayerMovement>().canMoving = false;
            }
        }
    }

    public void DisActiveAction()
    {
        if (!notNeedPlayer)
        {
            player.GetComponent<PlayerMovement>().canMoving = true;
        }
        startAction.SetActive(false);
    }
}
