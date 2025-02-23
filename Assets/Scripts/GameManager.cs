using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _gameStartUI;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private float countDownTime = 3f;

    private float currentTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        currentTime = countDownTime;

        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.unscaledDeltaTime;
            countDownText.text = Mathf.CeilToInt(currentTime).ToString();
        }
        else if(_gameStartUI.activeSelf)
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        if (_gameStartUI != null)
        {
            _gameStartUI.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverUI.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
