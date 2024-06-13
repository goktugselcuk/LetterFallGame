using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class LetterTile : MonoBehaviour
{
    [SerializeField] float speed;
    TMP_Text textObject;
    //GameObject imageObject;
    //SpriteRenderer imageSR;
    //public Sprite eraserIcon;
    int[] choiceSelection;
    //bool hasLetter = false;
    int letterLottery;
    int powerUpLottery;
    string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    string[] powerups = { "Eraser" };
    int letterChoice;
    int powerUpChoice;
    public string letter = "";
    public TMP_Text wordText;
    GameManager gameManagerScript;
    public int mghee;
    Transform eraserIcon;

    // Start is called before the first frame update
    void Start()
    {
        eraserIcon=transform.Find("Eraser");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        textObject = GetComponentInChildren<TMP_Text>();
        //imageObject = GameObject.Find("/Image/EraserSprite");
         
        
        
       

        letterLottery = Random.Range(1, 3);
        powerUpLottery = Random.Range(1, 3);
        
        if (letterLottery == 1)
        {
            letterChoice = Random.Range(0, letters.Length);
            textObject.text = letters[letterChoice];

        }
        else
        {
            
            eraserIcon.gameObject.SetActive(true);
            
            //powerUpChoice = Random.Range(0, powerups.Length);
            //imageSR.sprite = eraserIcon;

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

        if (letterLottery == 1)
        {
            letter = textObject.text;
            gameManagerScript.AddLetter(letter);
            textObject.text = " ";
        }

        else
        {
            Debug.Log("Eraser clicked!");
            gameManagerScript.EraseLetter();
        }

    }
    
}
