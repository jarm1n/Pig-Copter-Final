using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Console : MonoBehaviour {

    public GameObject[] skins;
    public GameObject[] playerSkins;
    public GameObject currentSkin, menuGold, storeGold, highscoreText;
    public GameObject[] Views;
    public GameObject player, distanceText;
    public int distance, distanceIncSpeed, gold, highscore;
    public float boostTimer;
    public bool show, hide;
    public bool inGame, boostGame, volume;

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate(success => { });

        volume = true;
        LoadGame();
    }
	
	// Update is called once per frame
	void Update () {

        if (CrossPlatformInputManager.GetButtonDown("Play"))
        {
            //BEGIN THE GAME
            SaveGame();
            NewGame();
            inGame = true;
            ChangeView(1);
        }
        if (CrossPlatformInputManager.GetButtonDown("Leaderboard"))
        {
            Social.ShowLeaderboardUI();
        }
        if (CrossPlatformInputManager.GetButtonDown("login"))
        {
            Social.localUser.Authenticate(success => { });
        }
        if (CrossPlatformInputManager.GetButtonUp("Store"))
        {
            ChangeView(2);
        }
        if (CrossPlatformInputManager.GetButtonUp("Information"))
        {
            ChangeView(3);
        }
        if (CrossPlatformInputManager.GetButtonUp("InfoBack"))
        {
            ChangeView(0);
        }
        if (CrossPlatformInputManager.GetButtonUp("Setting"))
        {
            if (volume)
            {
                AudioListener.volume = 0;
                volume = false;
            }
            else
            {
                AudioListener.volume = 1;
                volume = true;
            }
        }

        if (inGame)
        {
            IncrementScore(distanceIncSpeed);

            if (boostGame)
            {
                Time.timeScale = 2;
                boostTimer -= Time.deltaTime;
                if (boostTimer<=Time.deltaTime)
                {
                    boostGame = false;
                    Time.timeScale = 1;
                }
            }
        }
        else
        {
            Time.timeScale = 1;
        }

        if (show)
        {
            ShowView(Views[0]);
            show = false;
        }
	}

    public void boost_game()
    {
        boostTimer = 10;
        boostGame = true;
    }

    public void UpdateGold (int amount)
    {
        gold += amount;
        menuGold.GetComponent<Text>().text = "$" + gold.ToString();
        storeGold.GetComponent<Text>().text = "$" + gold.ToString();
        PlayerPrefs.SetInt("Gold", gold);
    }

    public void ChangePlayerSkin(GameObject skin)
    {
        currentSkin.GetComponent<ItemScript>().SetToOwned();
        currentSkin = skin;
        player.GetComponentInChildren<SpriteRenderer>().sprite = currentSkin.GetComponent<ItemScript>().sprite;
        SaveGame();

    }

    public void ChangeView(int view)
    {
        for (int i = 0; i < Views.Length; i++)
        {
            Views[i].active = false;
        }
        Views[view].active = true;
    }

    public void NewGame()
    {
        player.GetComponentInChildren<PlayerScript>().Reset();
        distance = 0;
        inGame = true;
    }

    public void IncrementScore(int speed)
    {
        distance += speed;
        distanceText.GetComponent<TextMesh>().text = distance.ToString();
    }

    public void GameOver()
    {
        //KILL ALL ENEMIES
        UpdateHighScore(distance);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
            Destroy(enemies[i].gameObject);
        
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        for (int i = 0; i < collectibles.Length; i++)
            Destroy(collectibles[i].gameObject);

        distance = 0;
        inGame = false;
        ChangeView(0);

        SaveGame();
    }

    public void ShowView(GameObject canvas)
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.GetComponent<Image>())
                child.GetComponent<UIFadeScript>().FadeIn();
            if (child.GetComponentInChildren<Text>())
                child.GetComponentsInChildren<UIFadeScript>()[1].FadeIn(); //First Child
        }
    }

    public void HideView(GameObject canvas)
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.GetComponent<Image>())
                child.GetComponent<UIFadeScript>().FadeOut();
            if (child.GetComponentInChildren<Text>())
                child.GetComponentsInChildren<UIFadeScript>()[1].FadeOut(); //First Child
        }
    }

    public void UpdateHighScore(int distance)
    {
        if (highscore < distance)
        {
            highscore = distance;
            highscoreText.GetComponent<Text>().text = "Highscore\n"+distance.ToString();
        }
    }

    #region SaveManager

    public void LoadGame()
    {
        gold = PlayerPrefs.GetInt("Gold");
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.GetComponent<Text>().text = "Highscore\n" + highscore.ToString();
        UpdateGold(0);
        int prevSkin = PlayerPrefs.GetInt("CurrentSkin");

        for (int i = 0; i < skins.Length; i++)
        {
            string skin = "Skin " + i.ToString();
            if (PlayerPrefs.GetInt(skin)==1)
            {
                skins[i].GetComponent<ItemScript>().SetToOwned();
            }
            else
            {
                skins[i].GetComponent<ItemScript>().owned = false;
            }
        }

        skins[prevSkin].GetComponent<ItemScript>().SetToEquipped();
        ChangePlayerSkin(skins[prevSkin]);
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("CurrentSkin", currentSkin.GetComponent<ItemScript>().skinID);
        PlayerPrefs.SetInt("Highscore", highscore);

        for (int i = 0; i < skins.Length; i++)
        {
            string skin = "Skin " + i.ToString();
            if (skins[i].GetComponent<ItemScript>().owned)
            {
                PlayerPrefs.SetInt(skin, 1);
            }
            else
            {
                PlayerPrefs.SetInt(skin, 0);
            }
        }
    }
    #endregion SaveManager
}
