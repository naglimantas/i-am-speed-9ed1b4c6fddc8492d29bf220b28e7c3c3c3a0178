using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class LapCounter : MonoBehaviour
{
    public GameObject winEffect;
    public GameObject loseEffect;

    //laps
    public int[] laps;
    private void OnTriggerEnter(Collider other)
    {
        //^1 gauna pirma nuo galo raide, atemi 48 nes ant ascii table 1 yra 49
        int index = Convert.ToInt32(other.gameObject.name[^1].ToString());
        //print(index - 48);
        print(index);
        laps[index] += 1;

        if (laps[index] == 3)
        {
            if (other.gameObject.name.Contains("Player"))
            {
                winEffect.SetActive(true);
            }
            else 
            {
                loseEffect.SetActive(true);
            }

        }
    }
}
