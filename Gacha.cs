using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class Gacha : ScriptableObject
{
    public new string name; // ���A���e�B�̖��́iNormal �ARare�Ȃǁj
    public int probability; // ������m��
    public List<RingsList> RingList;//�����O�̃��X�g
}
[Serializable]
public class RingsList
{
    public RingS ring;
}