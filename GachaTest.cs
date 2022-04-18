using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaTest : MonoBehaviour
{

    private Gacha[] gachatable = new Gacha[3];//�K�`���̗v�f��
    private System.Random random;

    const int maxIndex = 3; // ���A���e�B�̌��iNormal�ARare�ASuperRare�łR�j

    void Start()
    {
        // ���I���X�g�����[�h
        for (int i = 0; i < maxIndex; i++)
        {
            gachatable[i] = Resources.Load<Gacha>("Gacha/" + (i + 1).ToString());
        }
        random = new System.Random((int)DateTime.Now.Ticks);
    }

    public void Update()
    {
        int totalProbability = 0;//���l������


        for (int i = 0; i < maxIndex; i++)
        {
            // ���A���e�B�̊m���𑫂����킹��
            totalProbability += gachatable[i].probability;
        }


        // ���I���s��
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RingsList rings = getCard(totalProbability);
            switch (rings.ring.rarelity)
            {
                case "N":
                    Debug.Log("<color=#ff0000ff>���A���e�B: " + rings.ring.rarelity + " �p���[: " + rings.ring.power + "������΂�:" + rings.ring.blow + " �X�s�[�h:" + rings.ring.speed + "</color>");
                    break;
                case "R":
                    Debug.Log("<color=#00ff00ff>���A���e�B: " + rings.ring.rarelity + " �p���[: " + rings.ring.power + "������΂�:" + rings.ring.blow + " �X�s�[�h:" + rings.ring.speed + "</color>");
                    break;
                case "SR":
                    Debug.Log("<color=#ffff00ff>���A���e�B: " + rings.ring.rarelity + " �p���[: " + rings.ring.power + "������΂�:" + rings.ring.blow + " �X�s�[�h:" + rings.ring.speed + "</color>");
                    break;
            }
        }

    }

    //Ring�̒��I
    private RingsList getCard(int _allProbability)
    {
        // �K�`���S�̂̊m���𑫂����킹�����l���痐�����쐬 (���A���e�B�̒��I)
        int randomValue = getRamdom(_allProbability);
        int totalProbability = 0;

        for (int i = 0; i < maxIndex; i++)
        {
            totalProbability += gachatable[i].probability;
            if (totalProbability >= randomValue)
            {
                // ���̃��A�Ɋ܂܂��L���������痐�����쐬 (�L�����̒��I)
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