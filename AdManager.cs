using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public AudioSource[] music;
    InterstitialAd interstitialAd;
    public bool loadFailed = false;
    void Start()
    {
        interstitialAd = GetComponent<InterstitialAd>();
        interstitialAd.LoadAd();
    }
    public void ShowAd()
    {
        foreach (var VARIABLE in music)
        {
            VARIABLE.Stop();
        }

    }


}