using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seedsText;
    [SerializeField] private GameObject noSeedsPanel;

    internal bool showingRewarded = false;

    private UnityAdsManager unityAdsManager;
    private int seeds = 6;
    private int seedsPlantedOnRound = 0;
    private string seedsTextString = "Semillas: ";

    private void Start()
    {
        seedsText.text = seedsTextString + seeds.ToString();

        StartAdsService();
    }

    public void AddSeeds(int toAdd)
    {
        showingRewarded = false;
        noSeedsPanel.SetActive(false);
        seeds += toAdd;
        seedsText.text = seedsTextString + seeds.ToString();
    }

    public void SeedPlanted(Button pressedButton)
    {
        seeds--;
        seedsPlantedOnRound++;
        seedsText.text = seedsTextString + seeds.ToString();

        pressedButton.interactable = false;

        if (seedsPlantedOnRound >= 6)
        {
            seedsPlantedOnRound = 0;
            unityAdsManager.ShowNonRewardedAd();
            unityAdsManager.LoadNonRewardedAd();
        }

        if (seeds <= 0)
        {
            seedsPlantedOnRound = 0;
            noSeedsPanel.SetActive(true);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    //TODO: Add access to adverts

    private void StartAdsService()
    {
        unityAdsManager = gameObject.AddComponent<UnityAdsManager>();
        unityAdsManager.Initialize();
        InitAds();
    }

    private void InitAds()
    {
        //TODO
        unityAdsManager.LoadNonRewardedAd();
        unityAdsManager.LoadRewardedAd();
    }

    private void ShowInsterticial()
    {
        //TODO
    }

    public void ShowRewarded()
    {
        unityAdsManager.ShowRewardedAd();
    }
}
