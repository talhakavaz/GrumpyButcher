using UnityEngine;

public class CuttingStation : MonoBehaviour
{
    public GameObject cuttingPanel;

    public void StartCutting()
    {
        if (cuttingPanel != null)
        {
            cuttingPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ExitCutting()
    {
        cuttingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
