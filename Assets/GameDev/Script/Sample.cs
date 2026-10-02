using UnityEngine;

public class Sample : MonoBehaviour
{
    void Start()
    {
        Player player;
        player = new Player();
        Debug.Log("Player created" + player);
    }
}

public class Player
{
}
