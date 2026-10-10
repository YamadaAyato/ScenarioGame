using UnityEngine;

public class Sample2nd : MonoBehaviour
{
    private void Start()
    {
        A objA = new A(1234);
        objA.MethodA();

        B objB = new B(1234);
        objB.MethodA();
        objB.MethodB();

        // 派生クラスのオブジェクトは基底クラス型に暗黙的変換が可能
        A obj = new B(1234); // アップキャスト
        obj.MethodA(); // OK



        // obj.MethodB(); // エラー: 変数の型 A は MethodB を知らない
        A objAA = Random.value < 0.5F ? new B1() : new B(1234);
        objAA.MethodA(); // OK

        B objB2 = (B)objAA; // 実体がBなら通る 
        objB2.MethodB();

        
    }
}

class A
{
    public A(int value)
    {
        Debug.Log("Constructor of class A");
    }

    public void MethodA()
    {
        Debug.Log("MethodA in class A");
    }
}

class B : A
{
    // baseのコンストラクタをこのように呼び出すことで、
    // AのコンストラクタのvalueをBのコンストラクタから渡すことができる
    public B(int value) : base(value)
    {
        Debug.Log("Constructor of class B");
    }

    public void MethodB()
    {
        Debug.Log("MethodB in class B");
    }
}

class B1 : A
{
    public B1() : base(0)
    {
        Debug.Log("Constructor of class B1");
    }
    public void MA()
    {
        Debug.Log("MA in class B1");
    }
}