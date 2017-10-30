using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = false;
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate(success => { });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ShowLeaderboard()
    {
        Debug.Log("LOADING LEADERBOARD");
        Social.ShowLeaderboardUI();
        Debug.Log("LOADED");
    }

}
