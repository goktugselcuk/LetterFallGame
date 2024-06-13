using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject tilePrefab;
    [SerializeField] TextMeshProUGUI wordText;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] TextMeshProUGUI countDownText;

    public GameObject titleScreen;
    public GameObject playScreen;

   

    static float leftBound = -8.16f;
    //static float timeToStart = 1.0f;
    float spawnRate = 1.0f;
    private LetterTile tileScript;
    string word="";

    Vector2 fixedPos1 = new Vector2(leftBound, 1.0f);
    Vector2 fixedPos2 = new Vector2(leftBound, 0.0f);
    Vector2 fixedPos3 = new Vector2(leftBound, -1.0f);

    float roundTime = 60;
    public Slider timerBar1;
    public Slider timerBar2;
    public Image gameOverScreen;
    public bool gameOver=false;
    Color redColor = Color.red;

    public int score;
    

  
    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
        timerBar1.maxValue = roundTime;
        timerBar1.value = roundTime;
        timerBar2.maxValue = roundTime;
        timerBar2.value = roundTime;
        
        
        //InvokeRepeating("Spawner", timeToStart, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void StartTimer()
    {
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {

        while (gameOver == false)
        {
            roundTime -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (roundTime < 4)
            {

                timerBar1.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = redColor;
                timerBar2.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = redColor;
            }

            if (roundTime <= 0)
            {
                gameOver = true;
                GameOver();
            }

            if (gameOver == false)
            {
                timerBar1.value = roundTime;
                timerBar2.value = roundTime;
            }
        }
        
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("NAZ YENDI");
        gameOverScreen.gameObject.SetActive(true);
    }
 
    public void AddLetter(string letter)
    {
        word += letter;
        wordText.text = word;
    }

    public void EraseLetter()
    {
        Debug.Log("In EraseLetter()");
        Debug.Log("word before remove: "+word);
        //word.Remove(word.Length - 1, 1);
        word = word.Substring(0, word.Length - 1);
        Debug.Log("word after remove: "+word);
        wordText.text = word;
    }

    public void StartGame()
    {
        gameOver = false;
        AddLetter("");
        titleScreen.gameObject.SetActive(false);
        playScreen.gameObject.SetActive(true);
        score = 0;

        StartCoroutine("spawnTiles");
        StartTimer();
        scoreText.text = "" + score;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    IEnumerator spawnTiles()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            Instantiate(tilePrefab, fixedPos1, tilePrefab.transform.rotation);
            Instantiate(tilePrefab, fixedPos2, tilePrefab.transform.rotation);
            Instantiate(tilePrefab, fixedPos3, tilePrefab.transform.rotation);

        }

    }

    public void SubmitWord()
    {
        
        if (WordCheck(word))
        {
            Debug.Log("Word " +word+" exists.");
            int wordLength = word.Length;
            score += wordLength * 100;
            scoreText.text = ""+score;
        }
        else 
        {
            Debug.Log("Word " + word + " does not exists.");
        }
        DeleteWord();
    }

    public void DeleteWord()
    {
        word = "";
        wordText.text = word;
    }

    bool WordCheck(string word)
    {
        Debug.Log("----------------------------------------------");
        Debug.Log("WordCheck starts..");
        using (var sr = new StreamReader("C:\\Users\\goktu\\LetterFallGame\\Assets\\Databases\\words_alpha.txt", true))
            for (string line; (line = sr.ReadLine()) != null;) //read line by line
                if (line.Equals(word.ToLower()))
                {
                    Debug.Log("checked line is: " + line + " for the target word: " + word.ToLower());
                    Debug.Log("wordcheck success.. returning true");
                    return true;
                }
        Debug.Log("wordcheck failure.. returning false");
        Debug.Log("----------------------------------------------");
        return false;
    }

    

    
   
    
}
