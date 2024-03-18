using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seedsText;
    [SerializeField] private GameObject noSeedsPanel;

    private int seeds = 6;

    private string seedsTextString = "Semillas: ";

    private void Start()
    {
        seedsText.text = seedsTextString + seeds.ToString();
    }

    public void AddSeeds(int toAdd)
    {
        seeds += toAdd;
        seedsText.text = seedsTextString + seeds.ToString();
    }

    public void SeedPlanted(Button pressedButton)
    {
        seeds--;
        seedsText.text = seedsTextString + seeds.ToString();

        pressedButton.interactable = false;

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

    public void LoadAd()
    {
        //TODO
    }

    public void ShowAd()
    {
        //TODO
    }
}
