using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkFunction : MonoBehaviour
{
    public GameObject HitboxR;

    public GameObject HitboxL;

    private MoveFunction _moveFunction;

    private bool doTick;
    private int ticks = 2;
    private int _ticks;
    private void Awake()
    {
        _moveFunction = GetComponent<MoveFunction>();
        _ticks = ticks;
    }

    // Update is called once per frame
    void Update()
    {
        Atk();

        if (doTick)
        {
            _ticks -= 1;

            if (_ticks <= 0)
            {
                HitboxL.SetActive(false);
                HitboxR.SetActive(false);
                _ticks = ticks;
                doTick = false;
            }
        }
    }

    void Atk()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            if (_moveFunction.isRight)
                HitboxR.SetActive(true);
            else
                HitboxL.SetActive(true);

            doTick = true;
        }
    }
}
