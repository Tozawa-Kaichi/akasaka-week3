using UnityEngine;

public class NijigenHairetu : MonoBehaviour
{
    private void Start()
    {
        // 2次元配列とは
        // 1次元配列は要素を直列に並べたもの
        // □□□□□ <- 5要素の配列

        // 2次元配列は、さらに1軸加えた配列
        // □□□□□
        // □□□□□ <- 3行*5列、15要素の配列
        // □□□□□

        // 2次元配列型変数の宣言
        // 要素型[,] 変数名;
        //int[,] iAry; // int 型の2次元配列の変数

        // 2次元配列の生成
        // new 要素型[1次元目要素数, 2次元目要素数];
        //iAry = new int[3, 5];

        // 2次元配列の要素アクセス
        // 変数[要素番号1, 要素番号2]
        //iAry[0, 0] = 0;
        //iAry[0, 1] = 1;
        //iAry[0, 2] = 2;
        //iAry[0, 3] = 3;
        //iAry[0, 4] = 4;
        //iAry[1, 0] = 10;
        //iAry[1, 1] = 11;
        //iAry[1, 2] = 12;
        //iAry[1, 3] = 13;
        //iAry[1, 4] = 14;
        //iAry[2, 0] = 20;
        //iAry[2, 1] = 21;
        //iAry[2, 2] = 22;
        //iAry[2, 3] = 23;
        //iAry[2, 4] = 24;

        // 2次元配列の初期化
        // new 要素型[,] { { 要素, 要素, ... }, { 要素, 要素, ... }, ... }
        var iAry = new[,] // 初期化子から型とサイズを推論できる
        {
            { 0, 1, 2, 3, 4 },
            { 10, 11, 12, 13, 14 },
            { 20, 21, 22, 23, 24 }
        };

        // 2次元配列の要素数（総数）
        Debug.Log($"要素数={iAry.Length}");

        // 次元数の取得
        Debug.Log($"次元数={iAry.Rank}");

        // 各次元ごとの要素数を取る
        Debug.Log($"1次元目の要素数={iAry.GetLength(0)}");
        Debug.Log($"2次元目の要素数={iAry.GetLength(1)}");


        // 繰り返し文を使った2次元配列の処理
        for (var i = 0; i < iAry.GetLength(0); i++) // 1次元目の処理
        {
            for (var k = 0; k < iAry.GetLength(1); k++) // 2次元目の処理
            {
                Debug.Log($"{i},{k} = {iAry[i, k]}");
            }
        }
        // 2次元配列でも foreach での処理は可能
        foreach (var i in iAry)
        {
            Debug.Log(i);
        }
    }
}