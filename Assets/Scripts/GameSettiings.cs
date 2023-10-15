using System.Collections.Generic;
using UnityEngine;

public class GameSettiings : MonoBehaviour
{
    public Movement PlayerMovement;
    public List<GameObject> Obstacles;
    int _playCount;


    [Header("Playable Ad Player Settings")]
    [SerializeField]
    [LunaPlaygroundField("Increase Speed value", 1, "Player Controls")]
    private float _increaseSpeed = 0.01f;
    [SerializeField]
    [LunaPlaygroundField("Player Color", 1, "Player Controls")]
    private Color _PlayerColor = Color.red;



    [Header("Playable Ad Obastacle Settings")]
    [SerializeField]
    [LunaPlaygroundField("Obstacle Color", 1, "Obstacle Controls")]
    private Color _obstacleColor = Color.red;


    private void Awake()
    {
        if (PlayerMovement != null)
        {
            PlayerMovement.SetIncreaseSpeed(_increaseSpeed);
            PlayerMovement.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial.color = _PlayerColor;
        }
        for (int i = 0; i < Obstacles.Count; i++)
        {
            Obstacles[i].GetComponent<Renderer>().sharedMaterial.color = _obstacleColor;
        }
    }
    private void OnEnable()
    {
        Luna.Unity.LifeCycle.OnPause += PauseGameplay;
        Luna.Unity.LifeCycle.OnResume += ResumeGameplay;
    }
    public void DownloadTheGame()
    {
       // Application.OpenURL("https://play.google.com/store/apps/details?id=com.KocStudio.HotDogHot");
        Luna.Unity.Playable.InstallFullGame("IOS URL", "PlayStore URL");
        Luna.Unity.Analytics.LogEvent("InstallGame", _playCount);
    }

    public void StartGameLog()
    {
        _playCount++;
        Luna.Unity.Analytics.LogEvent("Play", _playCount);
    }
    private void PauseGameplay()
    {
        PlayerMovement.StopMove();
    }

    private void ResumeGameplay()
    {
        PlayerMovement.StartMove();
    }
  
}
