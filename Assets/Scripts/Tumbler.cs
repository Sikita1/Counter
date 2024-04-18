using System;
using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public event Action Switching;

    public bool IsOn { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Turn();
            Switching?.Invoke();
        }
    }

    private void Turn()
    {
        if (IsOn)
            IsOn = false;
        else
            IsOn = true;
    }
}
