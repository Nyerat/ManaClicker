using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickForMana : MonoBehaviour
{
    public float clickpower;

    public float manaTotal;
    public float mageCount;
    public Text manaDisplay;
    public Button manaButton;

    public float coolDownTimer;

    //Time Values
    public int periodLength;  //Seconds


    // Start is called before the first frame update
    void Start()
    {
        manaDisplay.text = manaTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        manaDisplay.text = manaTotal.ToString();
        
    }

    private void LateUpdate()
    {
        //Checks if there is any mages, then adds mana equal to mages
        if (mageCount >= 1)
        {
            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }
            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }

            if (coolDownTimer == 0)
            {
                manaTotal += mageCount;
                coolDownTimer = 1;
            }
        }
        
    }

    // Adds mana when clicked
    public void AddManaClick()
    {
        manaTotal += clickpower;
        Debug.Log(manaTotal);
    }

    public void BuyMage()
    {
        if (manaTotal >= 50)
        {
            manaTotal -= 50;
            mageCount++;
        }
        
    }

}
