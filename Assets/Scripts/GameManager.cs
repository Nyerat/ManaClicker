using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float mana;
    

    private float manaPerClick;
    private float manaPerSec;

    private float nextUpdate;

    public Purchaseables purchases;

    public Text manaText;
    public Text manaGain;

    public Text mageCount;
    public Text mageCost;
    public Text wizardCount;
    public Text wizardCost;
    public Text lichCount;
    public Text lichCost;
    // Start is called before the first frame update
    void Start()
    {
        mana = 1000;
        manaPerClick = 1;
        nextUpdate = .1f;
        purchases = new Purchaseables();

        mageCount.text = purchases.MageSummonCount.ToString();
        mageCost.text = purchases.MageSummonCost.ToString();
        wizardCount.text = purchases.WizardSummonCount.ToString();
        wizardCost.text = purchases.WizardSummonCost.ToString();
        lichCount.text = purchases.LichSummonCount.ToString();
        lichCost.text = purchases.LichSummonCost.ToString();
    }

    void Update()
    {
        manaText.text = (Math.Floor(mana)).ToString();
        manaGain.text = (Math.Floor(manaPerSec)).ToString();

        mageCount.text = purchases.MageSummonCount.ToString();
        wizardCount.text = purchases.WizardSummonCount.ToString();
        lichCount.text = purchases.LichSummonCount.ToString();
        
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
            case 2:
                SummonWizard();
                break;
            case 3:
                SummonLich();
                break;
            case 4:
                SummonMage();
                break;
            case 5:
                SummonMage();
                break;
            default:
                break;
        }
    }

    public void SummonMage()
    {
        int num = (purchases.MageSummonCost * (purchases.MageSummonCount * 2)) + (purchases.MageSummonCount * 5);
        if (num == 0) { num = purchases.MageSummonCost; }
        if (mana >= num)
        {
            purchases.MageSummonCount++;
            manaPerSec += 0.3f;
            mana -= num;
            
        }
        else
        {

        }

        num = (purchases.MageSummonCost * (purchases.MageSummonCount * 2)) + (purchases.MageSummonCount * 5);
        mageCost.text = num.ToString();
    }

    public void SummonWizard()
    {
        int num = (purchases.WizardSummonCost * (purchases.WizardSummonCount * 2)) + (purchases.WizardSummonCount * 5);
        if (num == 0) { num = purchases.WizardSummonCost; }
        if (mana >= num)
        {
            purchases.WizardSummonCount++;
            manaPerSec += 3.5f;
            mana -= num;

            
        }
        else
        {

        }

        num = (purchases.WizardSummonCost * (purchases.WizardSummonCount * 2)) + (purchases.WizardSummonCount * 5);
        wizardCost.text = num.ToString();
    }

    public void SummonLich()
    {
        int num = (purchases.LichSummonCost * (purchases.LichSummonCount * 2)) + (purchases.LichSummonCount * 5);
        if (num == 0) { num = purchases.LichSummonCost; }
        if (mana >= num)
        {
            purchases.LichSummonCount++;
            manaPerSec += 14.7f;
            mana -= num;

            
        }
        else
        {

        }

        num = (purchases.LichSummonCost * (purchases.LichSummonCount * 2)) + (purchases.LichSummonCount * 5);
        lichCost.text = num.ToString();

    }
}


