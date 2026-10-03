using UnityEngine;

public class Sample1st : MonoBehaviour
{
    void Start()
    {
        Player player1 = new();
        Player player2 = new Player();

        player1.Name = "Hero";
        player1.Health = 100;

        player2.Name = "Devil";
        player2.Health = 500;

        Debug.Log($"Player Name: {player1.Name}, Health: {player1.Health}");
        Debug.Log($"Player Name: {player2.Name}, Health: {player2.Health}");

        // オブジェクト初期化子を使ったインスタンス生成
        // 俺はコンストラクタを使う派閥だから、あんま使わなそう
        Player player3 = new Player { Name = "Wizard", Health = 300 };
        player3.ShowStatus();

        // この場合、引数なしのM()が呼ばれる
        // だが、この場合のデフォルト引数は意図しない挙動を引き起こす可能性があるので、併用には注意が必要
        player3.M();

        player3.M(10);
    }
}

public class Player
{
    public Player()
    {
        Debug.Log("Player constructor called");
    }

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
        Debug.Log("Player constructor with parameters called");
    }
    // readonlyをつけると、コンストラクタでしか値を設定できなくなる

    public string Name;

    public int Health;

    public void ShowStatus()
    {
        Debug.Log($"Player Name: {Name}, Health: {Health}");
    }

    public void M()
    {
        Debug.Log("M");
    }

    public void M (int a = 0)
    {
        Debug.Log($"M {a}");
    }
}
