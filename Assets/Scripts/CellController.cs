using UnityEngine;

public class CellController : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PlantSeed()
    {
        gameManager.SeedPlanted(GetComponent<UnityEngine.UI.Button>());
    }
}
