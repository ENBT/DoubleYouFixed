using UnityEngine;
using System.Collections;

public enum game
{
    mainmenu,
    pause,
    game,
    credits
}

public class GameManager {

    private static GameManager instance = new GameManager();

    private GameManager()
    {
        state = game.mainmenu;

    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }


    public game state { get; set; }



}
