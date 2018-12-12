using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Damage_Stats : MonoBehaviour
{
    [SerializeField] private GameObject Name_text;
    [SerializeField] private GameObject Cost_text;
    [SerializeField] private GameObject Health_text;
    [SerializeField] private GameObject DamageType_text;

    [SerializeField] private GameObject Open_Damage_Stats_Button;



    public void Open_Damage_Stats()
    {
        Name_text.SetActive(false);
        Cost_text.SetActive(false);
        Health_text.SetActive(false);
        DamageType_text.SetActive(false);

        Open_Damage_Stats_Button.SetActive(true);

    }

    public void Close_Damage_Stats()
    {
        Name_text.SetActive(true);
        Cost_text.SetActive(true);
        Health_text.SetActive(true);
        DamageType_text.SetActive(true);

        Open_Damage_Stats_Button.SetActive(false);

    }
}
