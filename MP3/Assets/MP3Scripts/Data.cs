using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{

    public static readonly string ENEMY_NAME = "Enemy";
    public static readonly string EGG_NAME = "Egg";
    public static readonly string PLAYER_NAME = "Player";

    public static Color[] colors = {Color.grey, Color.red};
    public enum PlayerMode: byte
    {
        ALLOFF          =   (0),
        Mouse           =   (1 << 1), // Mouse by default
        Keyboard        =   (0 << 1),
        FewLives        =   (1 << 2),
        EnableEnemy2    =   (1 << 3),
        EnableEnemy3    =   (1 << 4),

        ALLON           =   (0xff)
    }

}
