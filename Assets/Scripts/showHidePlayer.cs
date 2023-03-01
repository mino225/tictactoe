using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHidePlayer : MonoBehaviour
{
    // definierar objekt
    public Renderer playerRenderer;
    public GameObject player;
    public countTurns _turn;

    // definierar f�rgerna
    Color playerColor = new Color(0.77f, 0.44f, 0.44f, 1f);
    Color computerColor = new Color(0.6f, 1f, 0.6f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerRenderer = player.GetComponent<Renderer>();
        _turn = GameObject.Find("Markers").GetComponent<countTurns>();
    }

    // Update is called once per frame
    void Update()
    {
        // om turn �r 0 visas den f�rsta spelarens f�rg
        if (_turn.turn == 0)
        {
            playerRenderer.material.color = playerColor;
        }


        // om turn �r n�got annat visas den andra spelarens (/datorns) f�rg
        else if (_turn.turn == 1)
        {
            playerRenderer.material.color = computerColor;
        }

        else if (_turn.turn == 2)
        {
            playerRenderer.material.color = Color.clear;
        }
    }
}
