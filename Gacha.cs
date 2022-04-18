using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class Gacha : ScriptableObject
{
    public new string name; // レアリティの名称（Normal 、Rareなど）
    public int probability; // 当たる確率
    public List<RingsList> RingList;//リングのリスト
}
[Serializable]
public class RingsList
{
    public RingS ring;
}