using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_Stats : MonoBehaviour
{
    [SerializeField] private Text NameText;
    
    [SerializeField] private Text HealthText;
    [SerializeField] private Text CostText;
    [SerializeField] private Sprite sprite_for_in_the_circle;

    [SerializeField] private GameObject Show_Damage_Stats_Button;
    [SerializeField] private Text DamageText;
    [SerializeField] private Text AttackRangeText;
    [SerializeField] private Text AttackSpeedText;

    [SerializeField] private GameObject Placeholder_Circle_sprite;
    [SerializeField] private GameObject Level_Button;
    [SerializeField] private GameObject object_stats_Card;

    private string Unit_Name;
    private float Unit_Damage;
    private float Unit_Health;
    private float Unit_Cost;

    private void Start()
    {
        //Unit_Name = GetComponent<Units>().name;
        //Unit_Health = GetComponent<Units>().Hp;
        //Unit_Damage = GetComponent<attack>().
        //koppel de damage var aan de de damage var van een ander script etc...

     

        Placeholder_Circle_sprite.GetComponent<SpriteRenderer>().sprite = sprite_for_in_the_circle;
        NameText.text = "Name:" + "" + NameText.ToString();
        DamageText.text = "Damage:" + " " + DamageText.ToString();
        HealthText.text = "Health:" + " " + HealthText.ToString();
        CostText.text = "Cost:" + " " + CostText.ToString();
       
    }

    public void Back()
    {
        object_stats_Card.SetActive(false);
        Level_Button.SetActive(true);
    }
}
