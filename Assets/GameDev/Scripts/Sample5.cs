using System.Collections;
using UnityEngine;

public class Sample5 : MonoBehaviour
{
    private void Start()
    {
        //// A, B は無関係なので共通の型を持たない
        //// 唯一の逃げ道として object 型がある
        //object[] items = new object[] { new A(), 1234, new B(), "hogehoge" };
        //foreach (var item in items)
        //{
        //    // 型はなんでもよくて M() という機能を持つやつだけを呼びたい
        //    var type = item.GetType(); // 型情報を取り出す
        //    if (type.GetMethod("M") is { } m)
        //    {
        //        // パラメータを持たない M があるなら呼び出せるはず
        //        m.Invoke(item, new object[] { });
        //    }
        //}

        FibonacciNumbers items = new FibonacciNumbers(10);
        foreach (var i in items)
        {
            Debug.Log(i);
        }
    }

    // 継承関係のない A と B クラス。
    class A { public void M() { Debug.Log("A.M"); } }
    class B { public void M() { Debug.Log("B.M"); } }
}

class FibonacciNumbers : IEnumerable
{
    /// <summary>
    /// フィボナッチ数の長さ（先頭からの個数）
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="count">フィボナッチ数の長さ（先頭からの個数）</param>
    public FibonacciNumbers(int count) => Count = count;

    public IEnumerator GetEnumerator()
    {
        // ここを実装する
        return new FibonacciEnumerator(Count);
    }
}

class FibonacciEnumerator : IEnumerator
{
    public FibonacciEnumerator(int count)
    {
        _count = count;
        _index = 0;
        _current = 0;
    }

    public object Current => _current;

    private int _count;
    private int _index;
    private int _current;

    public void Reset()
    {
        _index = 0;
        _current = 0;
    }

    public bool MoveNext()
    {
        if (_index >= _count)
        {
            return false;
        }
        if (_index == 0)
        {
            _current = 0;
        }
        else if (_index == 1)
        {
            _current = 1;
        }
        else
        {
            _current = ((FibonacciEnumerator)this).GetFibonacci(_index);
        }

        _index++;
        return true;
    }

    private int GetFibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int a = 0, b = 1, c = 0;

        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}
