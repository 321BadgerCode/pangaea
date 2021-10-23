using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using player;

public class ad_manager_1 : MonoBehaviour, IUnityAdsListener
{
    string gameID = "3740087";
    string placementId = "rewardedVideo";
    bool testMode = true;
    private GameObject Player;
    private player_1 player;

    IEnumerator Start()
    {
        Advertisement.AddListener(this);

        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<player_1>();

        Advertisement.Initialize(gameID, testMode);

        while (!Advertisement.IsReady(placementId))
            yield return null;

        Advertisement.Show(placementId);
    }

    void Update()
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetFloat("Currency", player.currency += 1000);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
  
    }

    public void OnUnityAdsReady(string placementId)
    {
   
    }
}
