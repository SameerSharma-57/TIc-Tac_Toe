using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    // getting reference of unity gameobjects
    public GameObject blue_instantiate_model;
    public GameObject red_instantiate_model;
    public GameObject blue_trans;
    public GameObject red_trans;
    public Text t;
    public GameObject game_win_panel;
    public GameObject Resume_Panel;
    public GameObject turn_red;
    public GameObject turn_blue;
    public GameObject turn_text;
    public GameObject start_panel;

    //public variables
    public int turn;
    public int[,] gameboard = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public bool isplaced;
    public int occupied;
    

    //private variables
    GameObject clone = null;
    bool isPaused = false;
    bool gameEnded = false;

    public void print_board()
    {
        string temp = "";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                temp += gameboard[i, j].ToString()+" ";
            }
            temp += "\n";
        }
        print(temp);
    }
    int sum_diagonal(int x)
    {
        if (x == 1)
        {
            return gameboard[0, 0] + gameboard[1, 1] + gameboard[2, 2];
        }
        return gameboard[2, 0] + gameboard[1, 1] + gameboard[0, 2];
    }

    int sum_horizontal(int x)
    {
        return gameboard[x, 0] + gameboard[x, 1] + gameboard[x, 2];
    }
    int sum_vertical(int x)
    {
        return gameboard[0, x] + gameboard[1, x] + gameboard[2, x];
    }

    public void won(int x)
    {
        if (x == -1)
        {
            t.text = "Blue Won";

        }
        else
        {
            t.text = "Red Won";
        }
        game_win_panel.SetActive(true);
        gameEnded = true;
        Time.timeScale = 0;
        turn_text.SetActive(false);
        turn_blue.SetActive(false);
        turn_red.SetActive(false);

    }

    public void draw()
    {
        t.text = "OOPS! It's a Draw";
        game_win_panel.SetActive(true);
        Time.timeScale = 0;
        turn_text.SetActive(false);
        turn_blue.SetActive(false);
        turn_red.SetActive(false);
    }
    public bool ifWon(int x, int y, int p)
    {
        occupied += 1;

        if (p == -1)
        {
            if (sum_horizontal(x) == -3)
            {
                return true;
            }
            if (sum_vertical(y) == -3)
            {
                return true;
            }
            if (x == y && sum_diagonal(1) == -3)
            {
                return true;
            }
            if ((x + y) == 2 && sum_diagonal(-1) == -3)
            {
                return true;

            }
            
        }
        else
        {
            if (sum_horizontal(x) == 3)
            {
                return true;
            }
            if (sum_vertical(y) == 3)
            {
                return true;
            }
            if (x == y && sum_diagonal(1) == 3)
            {
                return true;
            }
            if (x + y == 2 && sum_diagonal(-1) == 3)
            {
                return true;

            }
        }
        instantiate_new();
        if (occupied == 9)
        {
            draw();

        }
        return false;




    }

    private void Start()
    {
        clone = Instantiate(blue_instantiate_model, blue_trans.transform.position, blue_trans.transform.rotation);
        turn = -1;
        isplaced = false;
        occupied = 0;
        gameEnded = false;
        isPaused = false;
        
        Time.timeScale = 0;
        start_panel.SetActive(true);
        
        
    }

    void Change_turn()
    {
        if (turn == -1)
        {
            turn_blue.SetActive(false);
            turn_red.SetActive(true);
            turn = 1;
        }
        else
        {
            turn_blue.SetActive(true);
            turn_red.SetActive(false);
            turn = -1;
        }
    }
    private void instantiate_new()
    {
        if (isplaced)
        {
            if (clone != null)
            {
                clone.GetComponent<PlayerController>().ismovable = false;
            }
            if (turn==1) {
            
            clone = Instantiate(blue_instantiate_model, blue_trans.transform.position, blue_trans.transform.rotation);
                
            }
            else
            {
                clone = Instantiate(red_instantiate_model, red_trans.transform.position, red_trans. transform.rotation);
                

            }
            Change_turn();
            isplaced = false;
            
        }

            
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    void pause()
    {
        if (!gameEnded)
        {
            Resume_Panel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
            turn_text.SetActive(false);
            turn_red.SetActive(false);
            turn_blue.SetActive(false);
        }
    
    }
    public void resume()
    {
        if (isPaused)
        {

        Resume_Panel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            turn_text.SetActive(true);
            if (turn == -1)
            {
                turn_blue.SetActive(true);
            }
            else
            {
                turn_red.SetActive(true);
            }
        }

    }

    public void next()
    {
        start_panel.SetActive(false);
        Time.timeScale = 1f;
        turn_blue.SetActive(true);
        turn_red.SetActive(false);
        turn_text.SetActive(true);
    }
}

