using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject tilePrefab;
    [SerializeField] TextMeshProUGUI wordText;
    float leftBound = -8.16f;
    float timeToStart = 1.0f;
    float repeatRate = 1.0f;
    private LetterTile tileScript;
    string word="";
    

    //float roundTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        
        UpdateWord("");
        InvokeRepeating("Spawner", timeToStart, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawner()
    {
        Vector2 fixedPos1 = new Vector2(leftBound, 1.0f);
        Vector2 fixedPos2 = new Vector2(leftBound, 0.0f);
        Vector2 fixedPos3 = new Vector2(leftBound, -1.0f);
        Instantiate(tilePrefab, fixedPos1, tilePrefab.transform.rotation);
        Instantiate(tilePrefab, fixedPos2, tilePrefab.transform.rotation);
        Instantiate(tilePrefab, fixedPos3, tilePrefab.transform.rotation);
        
    }

    public void UpdateWord(string letter)
    {
        word += letter;
        wordText.text = word;
    }

    

    /*
    void Countdown()
    {
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;
        }
        //countDownText.text=""
    }
    */
}
