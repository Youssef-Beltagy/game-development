
public class Data
{

    public static readonly string ENEMY_NAME = "Enemy";
    public static readonly string EGG_NAME = "Egg";
    public static readonly string PLAYER_NAME = "Player";


    public enum PlayerMode: byte
    {
        Mouse       =   (0 << 0), // Mouse by default
        Keyboard    =   (1 << 1),
        FewLives    =   (1 << 2),
        Rotation    =   (1 << 3),


        ALLON       =   (0xff)
    }

}
