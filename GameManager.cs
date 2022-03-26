using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Protocol
    /*
     * This is a proposal only
     Message = playerID [space] positionID

     int that represents position of the player's step.
     [0][1][2]
     [3][4][5]
     [6][7][8]
     */
    #endregion
    char[] Gameboard = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_' };
    string Boardstate;
    private void Start()
    {

        DrawBoard();
        //networkManager.StartUDP();
    }

    public NetworkManager networkManager; //don't forget to drag in inspector
    public char Player;
    public void DrawBoard() {
        Boardstate = string.Format("{0} {1} {2}\n{3} {4} {5}\n{6} {7} {8}", Gameboard[0], Gameboard[1], Gameboard[2], Gameboard[3], Gameboard[4], Gameboard[5], Gameboard[6], Gameboard[7], Gameboard[8]);
        Debug.Log(Boardstate);
    }
    public void GotNetworkMessage(string message)
    {
        Debug.Log("got network message: " + message);
       if (Player == 'X')
        {
            Gameboard[int.Parse(message)] = 'O';
        }
       else if (Player == 'O')
        {
            Gameboard[int.Parse(message)] = 'X';
        }
        DrawBoard();
    }

    public void PositionClicked(int position)
    {
        //draw the shape on the UI

        //update the other player about the shape
        networkManager.SendMessage("");// your job to finish it
    }

    //for debug purpouses only
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            // networkManager.SendMessage("A was sent");
            Debug.Log("X selected");
            Player = 'X';
            networkManager.StartUDP();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            // networkManager.SendMessage("B was sent");
            Debug.Log("O selected");
            Player = 'O';
            networkManager.ListeningPort = 40001;
            networkManager.SendingPort = 40000;
            networkManager.StartUDP();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Gameboard[0] = Player;
            networkManager.SendMessage("0");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Gameboard[1] = Player;
            networkManager.SendMessage("1");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Gameboard[2] = Player;
            networkManager.SendMessage("2");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Gameboard[3] = Player;
            networkManager.SendMessage("3");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Gameboard[4] = Player;
            networkManager.SendMessage("4");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Gameboard[5] = Player;
            networkManager.SendMessage("5");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Gameboard[6] = Player;
            networkManager.SendMessage("6");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Gameboard[7] = Player;
            networkManager.SendMessage("7");
            DrawBoard();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Gameboard[8] = Player;
            networkManager.SendMessage("8");
            DrawBoard();
        }

    }
}