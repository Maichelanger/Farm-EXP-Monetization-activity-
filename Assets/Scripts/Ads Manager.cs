using TMPro;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI pointsText;

    private UnityAdsManager unityAdsManager;
    private bool isInitialized = false;
    private bool isNonRewardedAdLoaded = false;
    private bool isRewardedAdLoaded = false;
    private int points = 0;

    private void Start()
    {
        unityAdsManager = gameObject.AddComponent<UnityAdsManager>();
        GameObject bannerButton = GameObject.Find("Banner Button");

        bannerButton.SetActive(false);

#if UNITY_EDITOR
        bannerButton.SetActive(true);
#endif
    }

    #region "Setters and Getters"
    public bool IsInitialized
    {
        get { return isInitialized; }
        set { isInitialized = value; }
    }

    public bool IsNonRewardedAdLoaded
    {
        get { return isNonRewardedAdLoaded; }
        set { isNonRewardedAdLoaded = value; }
    }

    public bool IsRewardedAdLoaded
    {
        get { return isRewardedAdLoaded; }
        set { isRewardedAdLoaded = value; }
    }
    #endregion


    public void InitializeAds()
    {
        if (isInitialized)
        {
            infoText.text = "Anuncios ya inicializados";
            return;
        }

        infoText.text = "Inicializando...";
        unityAdsManager.Initialize();
    }

    public void LoadNonRewardedAd()
    {
        if (!isInitialized)
        {
            infoText.text = "Anuncios sin inicializar. Pulse primero en \"Inicializar\"";
            return;
        }

        infoText.text = "Cargando anuncio...";
        unityAdsManager.LoadNonRewardedAd();
        isNonRewardedAdLoaded = true;
    }

    public void LoadRewardedAd()
    {
        if (!isInitialized)
        {
            infoText.text = "Anuncios sin inicializar. Pulse primero en \"Inicializar\"";
            return;
        }

        infoText.text = "Cargando anuncio...";
        unityAdsManager.LoadRewardedAd();
        isRewardedAdLoaded = true;
    }

    public void ShowNonRewardedAd()
    {
        if (!isInitialized)
        {
            infoText.text = "Anuncios sin inicializar. Pulse primero en \"Inicializar\"";
            return;
        }
        else if (!isNonRewardedAdLoaded)
        {
            infoText.text = "Anuncio no cargado. Pulse primero en \"Cargar\"";
            return;
        }

        unityAdsManager.ShowNonRewardedAd();
    }

    public void ShowRewardedAd()
    {
        if (!isInitialized)
        {
            infoText.text = "Anuncios sin inicializar. Pulse primero en \"Inicializar\"";
            return;
        }
        else if (!isRewardedAdLoaded)
        {
            infoText.text = "Anuncio no cargado. Pulse primero en \"Cargar\"";
            return;
        }

        unityAdsManager.ShowRewardedAd();
    }

    public void SetTextToInitialized()
    {
        infoText.text = "Anuncios inicializados";
    }

    public void SetTextToLoaded()
    {
        infoText.text = "Anuncio cargado";
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.text = $"Puntos: {points}";

        infoText.text = "Puntos añadidos";

        isNonRewardedAdLoaded = false;
        isRewardedAdLoaded = false;
    }
}
