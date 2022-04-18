using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaTest : MonoBehaviour
{

    private Gacha[] gachatable = new Gacha[3];//ガチャの要素数
    private System.Random random;

    const int maxIndex = 3; // レアリティの個数（Normal、Rare、SuperRareで３つ）

    void Start()
    {
        // 抽選リストをロード
        for (int i = 0; i < maxIndex; i++)
        {
            gachatable[i] = Resources.Load<Gacha>("Gacha/" + (i + 1).ToString());
        }
        random = new System.Random((int)DateTime.Now.Ticks);
    }

    public void Update()
    {
        int totalProbability = 0;//数値初期化


        for (int i = 0; i < maxIndex; i++)
        {
            // レアリティの確率を足し合わせる
            totalProbability += gachatable[i].probability;
        }


        // 抽選を行う
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RingsList rings = getCard(totalProbability);
            switch (rings.ring.rarelity)
            {
                case "N":
                    Debug.Log("<color=#ff0000ff>レアリティ: " + rings.ring.rarelity + " パワー: " + rings.ring.power + "吹っ飛ばし:" + rings.ring.blow + " スピード:" + rings.ring.speed + "</color>");
                    break;
                case "R":
                    Debug.Log("<color=#00ff00ff>レアリティ: " + rings.ring.rarelity + " パワー: " + rings.ring.power + "吹っ飛ばし:" + rings.ring.blow + " スピード:" + rings.ring.speed + "</color>");
                    break;
                case "SR":
                    Debug.Log("<color=#ffff00ff>レアリティ: " + rings.ring.rarelity + " パワー: " + rings.ring.power + "吹っ飛ばし:" + rings.ring.blow + " スピード:" + rings.ring.speed + "</color>");
                    break;
            }
        }

    }

    //Ringの抽選
    private RingsList getCard(int _allProbability)
    {
        // ガチャ全体の確率を足し合わせた数値から乱数を作成 (レアリティの抽選)
        int randomValue = getRamdom(_allProbability);
        int totalProbability = 0;

        for (int i = 0; i < maxIndex; i++)
        {
            totalProbability += gachatable[i].probability;
            if (totalProbability >= randomValue)
            {
                // そのレアに含まれるキャラ数から乱数を作成 (キャラの抽選)
                RingsList ring = getRamdom(gachatable[i].RingList);
                return ring;
            }
        }
        return null;
    }

    private int getRamdom(int _max)
    {
        return random.Next(0, _max);
    }

    private RingsList getRamdom(List<RingsList> _list)
    {
        return _list[random.Next(0, _list.Count)];
    }
}