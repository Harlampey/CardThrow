using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    #region Singlton
    public static Level Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Level.cs is singlton!");
        }
    }

    #endregion

    [SerializeField] private VictoryEffect _victoryEffect;

    public static bool IsPlaying;
    private int _bananasInLevel;

    private void Start()
    {
        IsPlaying = true;
    }
    public static void AssignBanana()
    {
        Instance._bananasInLevel++;
    }
    public static void AddBananaToScore()
    {
        Instance._bananasInLevel--;
        if (Instance._bananasInLevel <= 0)
        {
            Instance.Win();
        }
    }

    private void Win()
    {
        IsPlaying = false;
        _victoryEffect.Play();
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
