using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LetterTile : MonoBehaviour
{
    [SerializeField] float speed;
    TMP_Text textObject;
    int[] choiceSelection;
    //bool hasLetter = false;
    int letterLottery;
    string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    int letterChoice;
    public string letter="";
    public TMP_Text wordText;
    GameManager gameManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        textObject = GetComponentInChildren<TMP_Text>();

        letterLottery = Random.Range(1, 4);
        if (letterLottery == 1)
        {
            letterChoice = Random.Range(0, letters.Length);
            textObject.text = letters[letterChoice];

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > 10.0)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        letter=textObject.text; 
        gameManagerScript.UpdateWord(letter);   
        textObject.text = " ";
        
    }
}
