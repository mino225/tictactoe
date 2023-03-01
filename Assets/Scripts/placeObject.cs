using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeObject : MonoBehaviour
{
    // definierar spelaren och brickorna
    public GameObject playerMarker;
    public Renderer playerMarkerColor;
    public Collider2D playerMarkerCollider;

    // definierar texterna
    public CanvasRenderer redPlayerWinsText;
    public CanvasRenderer yellowPlayerWinsText;
    public CanvasRenderer tieText;

    // bestämmer färgerna på markörerna
    Color playerColor = new Color(0.77f, 0.44f, 0.44f, 1f);
    Color computerColor = new Color(0.6f, 1f, 0.6f, 1f);

    // hittar variablen som håller ordning på vems tur det är
    public countTurns _turn;

    // variabler som håller ordning på vem som vunnit
    private int winPlayer;
    private int winComputer;

    // definierar rutorna
    private Renderer one;
    private Renderer two;
    private Renderer three;
    private Renderer four;
    private Renderer five;
    private Renderer six;
    private Renderer seven;
    private Renderer eight;
    private Renderer nine;

    // kontrollerar om det är vinst
    public void checkWin()
    {
        // tar reda på rutornas färg
        one = GameObject.Find("playerTopLeft").GetComponent<Renderer>();
        two = GameObject.Find("playerTopMiddle").GetComponent<Renderer>();
        three = GameObject.Find("playerTopRight").GetComponent<Renderer>();
        four = GameObject.Find("playerMiddleLeft").GetComponent<Renderer>();
        five = GameObject.Find("playerMiddle").GetComponent<Renderer>();
        six = GameObject.Find("playerMiddleRight").GetComponent<Renderer>();
        seven = GameObject.Find("playerBottomLeft").GetComponent<Renderer>();
        eight = GameObject.Find("playerBottomMiddle").GetComponent<Renderer>();
        nine = GameObject.Find("playerBottomRight").GetComponent<Renderer>();

        // tittar på möjliga vinstscenarion
        // tittar enbart om en av rutorna inte har ingen färg
        if (one.material.color != Color.clear)
        {
            // rad 1
            if ((one.material.color == two.material.color) && (two.material.color == three.material.color))
            {
                if (one.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (one.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }

            // kolumn 1
            if ((one.material.color == four.material.color) && (four.material.color == seven.material.color))
            {
                if (one.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (one.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }

            // diagonal upp-ner
            if ((one.material.color == five.material.color) && (five.material.color == nine.material.color))
            {
                if (one.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (one.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }
        }

        if (four.material.color != Color.clear)
        {
            // rad 2
            if ((four.material.color == five.material.color) && (five.material.color == six.material.color))
            {
                if (four.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (four.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }
        }

        if (two.material.color != Color.clear)
        {
            // kolumn 2
            if ((two.material.color == five.material.color) && (five.material.color == eight.material.color))
            {
                if (two.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (two.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }
        }

        if (seven.material.color != Color.clear)
        {
            // rad 3
            if ((seven.material.color == eight.material.color) && (eight.material.color == nine.material.color))
            {
                if (seven.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (seven.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }

            // diagonal ner-upp
            if ((seven.material.color == five.material.color) && (five.material.color == three.material.color))
            {
                if (seven.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (seven.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }
        }

        if (three.material.color != Color.clear)
        {
            // kolumn 3
            if ((three.material.color == six.material.color) && (six.material.color == nine.material.color))
            {
                if (three.material.color == playerColor)
                {
                    winPlayer = 1;
                }

                else if (three.material.color == computerColor)
                {
                    winComputer = 1;
                }
            }
        }

        // om det blir oavgjort
        // kontrollerar om ingen har vunnit och att alla rutor är fyllda
        if ((winPlayer != 1) && (winComputer != 1) && (one.material.color != Color.clear) && (two.material.color != Color.clear) && (three.material.color != Color.clear) && (four.material.color != Color.clear) && (five.material.color != Color.clear) && (six.material.color != Color.clear) && (seven.material.color != Color.clear) && (eight.material.color != Color.clear) && (nine.material.color != Color.clear))
        {
            tieText.SetColor(Color.white);
            _turn.turn = 2;
        }       
    }

    public void win()
    {
        if (winPlayer == 1)
        {
            redPlayerWinsText.SetColor(Color.white);
            _turn.turn = 2;
        }

        if (winComputer == 1)
        {
            yellowPlayerWinsText.SetColor(Color.white);
            _turn.turn = 2;
        }
    }

    // döljer brickorna
    public void deactivate()
    {
        playerMarkerColor.material.color = Color.clear;
    }

    // visar brickorna
    public void activate()
    {
        // beroende på vems tur det är får brickorna olika färger
        if (_turn.turn == 0)
        {
            playerMarkerColor.material.color = playerColor;
            _turn.turn = 1;
        }
        
        else
        {
            playerMarkerColor.material.color = computerColor;
            _turn.turn = 0;
        }

        // stänger av collidern på markören
        // gör att man inte kan klicka på samma två gånger
        playerMarkerCollider.enabled = false;

        // tittar efter vinst
        checkWin();
        win();
    }

    // Start is called before the first frame update
    void Start()
    {
        // definierar värden på gameobjects och variabler
        playerMarker = GameObject.FindWithTag("player");
        playerMarkerColor = GetComponent<Renderer>();
        playerMarkerCollider = GetComponent<Collider2D>();
        _turn = GameObject.Find("Markers").GetComponent<countTurns>();
        winPlayer = 0;
        winComputer = 0;


        redPlayerWinsText = GameObject.Find("redPlayerWin").GetComponent<CanvasRenderer>();
        yellowPlayerWinsText = GameObject.Find("yellowPlayerWin").GetComponent<CanvasRenderer>();
        tieText = GameObject.Find("tie").GetComponent<CanvasRenderer>();

        redPlayerWinsText.SetColor(Color.clear);
        yellowPlayerWinsText.SetColor(Color.clear);
        tieText.SetColor(Color.clear);

        // döljer brickorna
        deactivate();
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        // om brickan kolliderar med spelaren
        if (collision.CompareTag("player") && (_turn.turn != 2))
        {

            // om vänster musknapp trycks ner
            if (Input.GetKey("space"))
            {
                activate();
            }
        }  
    }
}