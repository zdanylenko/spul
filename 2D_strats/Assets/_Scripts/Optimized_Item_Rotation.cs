using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimized_Item_Rotation : MonoBehaviour
{
    //levi heeft deze gemaakt niet ik (axel)

    [SerializeField] private bool RotateX = true, RotateY = true, RotateZ = true;

    [SerializeField] private float RotateTimer = 2f;
    private float _RotateTime;

    [SerializeField] private float RotateSpeedX = 5f, RotateSpeedY = 5f, RotateSpeedZ = 5f;

    private Vector3 _RotateSpeed = new Vector3();

    private void Start()
    {
        if (RotateX)
        {
            _RotateSpeed.x = RotateSpeedX;
        }
        else
        {
            _RotateSpeed.x = 0;
        }

        if (RotateY)
        {
            _RotateSpeed.y = RotateSpeedY;
        }
        else
        {
            _RotateSpeed.y = 0;
        }

        if (RotateZ)
        {
            _RotateSpeed.z = RotateSpeedZ;
        }
        else
        {
            _RotateSpeed.z = 0;
        }

        _RotateTime = RotateTimer;
    }

    private void Update()
    {
        _RotateTime -= Time.deltaTime;

        if (_RotateTime <= 0f)
        {
            _RotateSpeed *= -1;
            _RotateTime = RotateTimer;
        }

        transform.Rotate(_RotateSpeed.x * Time.deltaTime, _RotateSpeed.y * Time.deltaTime, _RotateSpeed.z * Time.deltaTime);
    }
}
