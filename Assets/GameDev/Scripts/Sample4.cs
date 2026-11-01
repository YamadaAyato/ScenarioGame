using System.Collections;
using UnityEngine;

public class Sample4 : MonoBehaviour
{
    //[SerializeField]
    //private float _redDuration = 3; // 赤信号の時間

    //[SerializeField]
    //private float _blueDuration = 3; // 青信号の時間

    //[SerializeField]
    //private float _flashDuration = 3; // 点滅の時間

    //[SerializeField]
    //private float _flashInterval = 0.5f; // 点滅の間隔



    //// 状態管理フラグ（数値で今の状態を表現する）
    //private int _state; // 0 = 赤, 1 = 青

    //private float _elapsed = 0f; // 経過時間（秒）
    //private Renderer _renderer;

    private void Start()
    {
        StartCoroutine(RunAsync());
    }

    //private void Update()
    //{
    //    _elapsed += Time.deltaTime;
    //    switch (_state)
    //    {
    //        case 0: // 赤
    //            _renderer.material.color = Color.red;
    //            if (_elapsed > _redDuration)
    //            {
    //                _state = 1; // 青に切り替え
    //                _elapsed = 0; // 経過時間をリセット
    //            }
    //            break;
    //        case 1: // 青
    //            _renderer.material.color = Color.blue;
    //            if (_elapsed > _blueDuration)
    //            {
    //                _state = 2;
    //                _elapsed = 0; // 経過時間をリセット
    //            }
    //            break;
    //        case 2:
    //            if (_elapsed > _flashDuration)
    //            {
    //                _state = 0;
    //                _elapsed = 0;
    //            }
    //            else
    //            {
    //                // 点滅処理
    //                float interval = Mathf.Floor(_elapsed / _flashInterval);
    //                if (interval % 2 == 0)
    //                {
    //                    _renderer.material.color = Color.blue;
    //                }
    //                else
    //                {
    //                    _renderer.material.color = Color.black;
    //                }
    //            }
    //            break;
    //    }
    //}

    private IEnumerator RunAsync()
    {
        var renderer = GetComponent<Renderer>();

        while (true)
        {
            renderer.material.color = Color.red; // 赤に設定
            for (var t = 0f; t < 3; t += Time.deltaTime) // 3秒経過するまで繰り返す
            {
                yield return null; // 1フレーム待つ
            }

            renderer.material.color = Color.blue; // 青に設定
            for (var t = 0f; t < 3; t += Time.deltaTime) // 3秒経過するまで繰り返す
            {
                yield return null; // 1フレーム待つ
            }

            for (var t = 0f; t < 6; t += Time.deltaTime)
            {
                if (t % 1 < 0.5f)
                {
                    renderer.material.color = Color.blue; // 青に設定
                }
                else
                {
                    renderer.material.color = Color.black; // 黒に設定
                }
                yield return null; // 1フレーム待つ
            }
        }
    }
}
