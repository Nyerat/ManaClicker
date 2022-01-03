using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float mana;
    public Text manaText;

    private float manaPerClick;
    private float manaPerSec;

    private float nextUpdate;

    public Purchaseables purchases;
    // Start is called before the first frame update
    void Start()
    {
        mana = 0;
        manaPerClick = 1;
        nextUpdate = .1f;
        purchases = new Purchaseables();
    }

    void Update()
    {
        manaText.text =  (Math.Floor(mana)).ToString();

        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEveryTenthSecond();
        }
    }

    void UpdateEveryTenthSecond()
    {

        mana += manaPerSec;

    }


    public void ManaClick()
    {
        mana += manaPerClick;
    }

    public void Purchase(int itemID)
    {
        switch (itemID)
        {
            case 1:
                SummonMage();
                break;
            default:
                break;
        }
    }

    public void SummonMage()
    {
        int num = (purchases.MageSummonCost * (purchases.MageSummonCount * 2)) + (purchases.MageSummonCount * 5);
        if (mana >= num)
        {
            manaPerSec += 0.1f;
            mana -= num;
        }
        else
        {

        }

    }
}


