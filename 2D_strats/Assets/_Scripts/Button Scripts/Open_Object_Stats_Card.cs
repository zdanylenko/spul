using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Object_Stats_Card : MonoBehaviour
{
    [SerializeField] private GameObject Level_Button;
    [SerializeField] private GameObject object_stats_Card;
    [SerializeField] private GameObject Close_Damage_Stats;

    public void OnButtonClick()
    {
        Close_Damage_Stats.SetActive(false);
        Level_Button.SetActive(false);
        object_stats_Card.SetActive(true);
    }

}



