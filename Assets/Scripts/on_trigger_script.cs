using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_trigger_script : MonoBehaviour
{
    public GameObject plane;
    public TextMesh t;
    public GameManagerScript game;
    private bool isTriggered = false;
    private bool isactive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isactive)
        {

            print("enter");
            plane.SetActive(true);
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isactive)
        {

            plane.SetActive(false);
            print("exit");
            isTriggered = false;
        }
    }
    public int[] loc = { 0, 0 };

    private void Update()
    {
        if (isTriggered && isactive)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

                game.gameboard[loc[0], loc[1]]=game.turn;
                game.isplaced = true;
                print("Placed");
                //game.print_board();
                if (game.turn == 1)
                {
                    t.text = "O";
                }
                else
                {
                    t.text = "X";
                }
                
                isactive = false;
                if (game.ifWon(loc[0], loc[1], game.turn))
                {
                    game.won(game.turn);
                }
            }
        }
    }


}
