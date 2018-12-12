using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Timer : MonoBehaviour
{
    public Text MinutenEnSecondenTimerText;

    public float MiliSeconden = 0f;
    public float Seconden = 0f;
    public float Minuten = 0f;
    public float Uren = 0f;

    void Update()
    {

        if (MinutenEnSecondenTimerText != null)
        {
            MiliSeconden++;

            if (MiliSeconden >= 60f) //hier komen de seconden er bij
            {
                MiliSeconden = 0f;
                Seconden += 1f;
            }

            if (Seconden >= 60f) //hier komen de minuten er bij
            {
                Seconden = 0f;
                Minuten += 1f;

            }

            if (Minuten >= 60f) //hier komen de uren er bij
            {
                Minuten = 0f;
                Uren += 1;
            }


            MinutenEnSecondenTimerText.text = " " + Uren.ToString() + " : " + " " + Minuten.ToString() + " : " + " " + Seconden.ToString();

        }
    }
}
