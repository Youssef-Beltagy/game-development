using UnityEngine;

public class Data
{

    public static readonly string ENEMY_NAME = ObjectTypes.Enemy.ToString();
    public static readonly string ENEMY_PROJECTILE_NAME = ObjectTypes.EnemyProjectile.ToString();
    public static readonly string PLAYER_PROJECTILE_NAME = ObjectTypes.PlayerProjectile.ToString();
    public static readonly string PLAYER_NAME = ObjectTypes.Player.ToString();
    public static readonly string WAYPOINT_NAME = ObjectTypes.WayPoint.ToString();

    public static Color[] colors = { Color.green, Color.yellow, Color.grey, Color.red };

    public enum ObjectTypes
    {

        Player              =   (1 << 0),

        Egg                 =   (1 << 1),
        Bomb                =   (1 << 2),
        PlayerProjectile    =   Egg | Bomb,

        Enemy1              =   (1 << 3),
        Enemy2              =   (1 << 4),
        Enemy3              =   (1 << 5),
        Enemy               =   Enemy1 | Enemy2 | Enemy3,

        EnemyProjectile     =   (1 << 6),

        WayPoint            =   (1 << 7),

    }

    public enum PlayerMode: byte
    {
        ALLOFF          =   (0),

        Mouse           =   (1 << 1), // Mouse by default
        Keyboard        =   (0 << 1), // Mouse and Keyboard are contradicting states

        FewLives        =   (1 << 2),
        EnableEnemy2    =   (1 << 3),
        EnableEnemy3    =   (1 << 4),

        DamageWayPoints =   (0 << 5), // Hide and damage WayPoints are contradicting states
        HideWaypoints   =   (1 << 5), // H

        WayPointSequence =   (1 << 6), // J

        Default         =   Mouse | EnableEnemy2 | EnableEnemy3 | DamageWayPoints | WayPointSequence,

        ALLON           =   (0xff)
    }

}
