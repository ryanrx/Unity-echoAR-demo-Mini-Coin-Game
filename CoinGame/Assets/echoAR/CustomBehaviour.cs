/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    private Boolean _initiated = false;


    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Query additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // attach controller scripts to player models
        if (this.gameObject.name.Equals("Unicorn.glb"))
        {
            if (gameObject.GetComponent<P1Controller>() == null)
            {
                gameObject.AddComponent<P1Controller>();
            }
        }
        else if (this.gameObject.name.Equals("Eagle.glb"))
        {
            if (gameObject.GetComponent<P2Controller>() == null)
            {
                gameObject.AddComponent<P2Controller>();
            }
        }


        if (GameObject.Find("Coin.glb") != null && !this.gameObject.name.Equals("Coin.glb"))
        {
            // calculate distance between player and coin
            GameObject coin = GameObject.Find("Coin.glb");
            float coinX = coin.transform.position.x;
            float coinZ = coin.transform.position.z;
            float curX = this.gameObject.transform.position.x;
            float curZ = this.gameObject.transform.position.z;
            double distance = Math.Sqrt((curX - coinX) * (curX - coinX) + (curZ - coinZ) * (curZ - coinZ));

            // player won if got the coin
            if (distance < 50)
            {
                if (!_initiated)
                {
                    _initiated = true;
                }
                else
                {
                    if (this.gameObject.name.Equals("Unicorn.glb"))
                    {
                        winning("1");
                    }
                    else if (this.gameObject.name.Equals("Eagle.glb"))
                    {
                        winning("2");
                    }
                }                
            }
        }

    }

    // change scores and winning text
    void winning(String player)
    {
        Text gText = GameObject.Find("GameText").GetComponent<Text>();
        Text score = GameObject.Find("P" + player + "Score").GetComponent<Text>();
        int curScore = int.Parse(score.text) + 1;
        score.text = curScore.ToString();
        if (curScore == 1)
        {
            Destroy(GameObject.Find("Coin.glb"));
            gText.color = Color.red;
            gText.text = "Player " + player + " Wins!";
            Debug.Log("Player " + player + " Wins!");
        }
    }
}