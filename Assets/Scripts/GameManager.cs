using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seedsText;
    [SerializeField] private GameObject noSeedsPanel;

    private int seeds = 6;
    private int seedsPlantedOnRound = 0;

    private string seedsTextString = "Semillas: ";

    private void Start()
    {
        seedsText.text = seedsTextString + seeds.ToString();

        InitAds();
    }

    public void AddSeeds(int toAdd)
    {
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
            ShowInsterticial();
        }

        if (seeds <= 0)
        {
            noSeedsPanel.SetActive(true);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    //TODO: Add access to adverts

    private void InitAds()
    {
        //TODO
        LoadInsterticial();
        LoadRewarded();
    }

    private void LoadInsterticial()
    {
        //TODO
    }

    private void LoadRewarded()
    {
        //TODO
    }

    private void ShowInsterticial()
    {
        //TODO
    }

    public void ShowRewarded()
    {
        //TODO
    }
}
