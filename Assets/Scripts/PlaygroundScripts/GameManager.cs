using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMPro.TMP_Text countdownText;
    public bool gamePlaying { get; private set; }
    public int countdownTime;

    int coinRandomizer;
    int coinAmount;
    int score;

    public TMPro.TMP_Text coinAmountText;
    public TMPro.TMP_Text ScoreText;
    public GameObject GameOverPannel;
    public GameObject CountdownPage;
    public GameObject Player;
    public GameObject JungleT1;
    public GameObject JungleT2;
    public GameObject JungleT3;
    public GameObject YellowBush;
    public GameObject Brick;
    public GameObject Wall;
    public GameObject Spike;
    public GameObject Spike2;
    public GameObject Coin;
    public TMPro.TMP_Text coinCurrentText;
    public TMPro.TMP_Text currentText;
    public TMPro.TMP_Text highScoreText;
    public Button catRestartButton;
    public Button dogRestartButton;

    public Camera mainCam;
    public Image backgroundImage;
    private int randomIndex;
    public Color[] colorToChange;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        //Random colors
        randomIndex = Random.Range(0, colorToChange.Length);
        ChangeColor();

    }

    private void Start()
    {
        //Coin & Score starting number
        coinAmount = 0;
        coinAmountText.text = coinAmount.ToString();
        score = 0;
        ScoreText.text = score.ToString();

        //Sets GameOverPannel OFF when the game starts
        GameOverPannel.SetActive(false);

        gamePlaying = false;
        CountdownPage.SetActive(true);
        Player.SetActive(false);
        Wall.SetActive(false);
        Spike.SetActive(false);
        Spike2.SetActive(false);
        Coin.SetActive(false);

        StartCoroutine(CountDownToStart());

        //Sets Objects ON when the game starts

        //RestartButton Listener
        catRestartButton.onClick.RemoveAllListeners();
        catRestartButton.onClick.AddListener(CatRestartLevel);

        dogRestartButton.onClick.RemoveAllListeners();
        dogRestartButton.onClick.AddListener(DogRestartLevel);

        //GameScore & Coin Highest PlayePrefs
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

    private void BeginGame()
    {
        gamePlaying = true;
        //CountdownPage.SetActive(false);
        Player.SetActive(true);
        JungleT1.SetActive(true);
        JungleT2.SetActive(true);
        JungleT3.SetActive(true);
        YellowBush.SetActive(true);
        Brick.SetActive(true);
        Wall.SetActive(true);
        Spike.SetActive(true);
        Spike2.SetActive(true);
        Coin.SetActive(true);
    }

    public void AddScore()
    {
        //Increase Coin in Random Range
        coinRandomizer = Random.Range(1, 5);

        for (int i = coinRandomizer; i > 0; i = Random.Range(0, 1))
        {
            coinAmount += coinRandomizer;
            coinAmountText.text = coinAmount.ToString();
        }

        //Increase Game Score
        score++;
        ScoreText.text = score.ToString();

        randomIndex = Random.Range(0, colorToChange.Length);
        ApplyColor();

    }

    public void GameOver()
    {
        //Displays Highscore when GameOver
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        //Displays Current Score
        PlayerPrefs.SetInt("Score", score);
        //Display Current Coin Collected
        PlayerPrefs.SetInt("CoinScore", coinAmount);

        coinCurrentText.text = PlayerPrefs.GetInt("CoinScore").ToString();
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();


        //Destroy Object when GameOver
        //JungleT1.SetActive(false);
        //JungleT2.SetActive(false);
        //JungleT3.SetActive(false);
        //YellowBush.SetActive(false);
        //Brick.SetActive(false);
        Wall.SetActive(false);
        Spike.SetActive(false);
        Spike2.SetActive(false);
        Coin.SetActive(false);
        
        //Displays GameOverPannel when GameOver
        GameOverPannel.SetActive(true);
    }

    //Restart Button
    public void CatRestartLevel()
    {
        SceneManager.LoadScene(SceneData.catplayground);
    }

    public void DogRestartLevel()
    {
        SceneManager.LoadScene(SceneData.dogplayground);
    }

    //MainCamera Colors changes when reached scores 2 & 5
    void ApplyColor()
    {
        if(score == 2)
        {
            ChangeColor();
        }
        else if(score == 5)
        {
            ChangeColor();
        }
    }


    //Color Randomizer Element
    public void ChangeColor()
    {
        mainCam.backgroundColor = colorToChange[randomIndex];
        //backgroundImage.color = colorToChange[randomIndex];
    }

    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        BeginGame();
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        CountdownPage.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }

}
