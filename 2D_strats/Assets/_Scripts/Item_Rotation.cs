using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Rotation : MonoBehaviour
{
    [SerializeField] private float Max_RotateSpeed_X;
    [SerializeField] private float Max_RotateSpeed_Y;
    [SerializeField] private float Max_RotateSpeed_Z;

    private Vector3 rotateSpeed = new Vector3();

    [SerializeField] private bool retreat = false;
    private float retreat_timer = 0f;
    [SerializeField] private float Retreat_Switch_Time = 1;
    [SerializeField] private int whichrotatespeed = 0;

    private void Start()
    {

        switch (whichrotatespeed)
        {

            case 0:
                rotateSpeed.x = Max_RotateSpeed_X;
                break;
            case 1:
                rotateSpeed.y = Max_RotateSpeed_Y;
                break;
            case 2:
                rotateSpeed.z = Max_RotateSpeed_Z;
                break;
        }
    }

    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(rotateSpeed.x * Time.fixedDeltaTime, rotateSpeed.y * Time.fixedDeltaTime, rotateSpeed.z * Time.fixedDeltaTime, 0);

        if (retreat == true)
        {
            retreat_timer += Time.deltaTime;
        }

        if (retreat_timer >= Retreat_Switch_Time)
        {
            rotateSpeed.x *= -1;
            rotateSpeed.y *= -1;
            rotateSpeed.z *= -1;

            retreat_timer = 0f;
        }


    }

}
