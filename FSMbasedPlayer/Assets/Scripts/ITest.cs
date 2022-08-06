using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITest : MonoBehaviour
{
    public KeyCode k1 = KeyCode.A;
    public KeyCode k2 = KeyCode.S;
    public KeyCode k3 = KeyCode.D;
    public KeyCode k4 = KeyCode.F;
    public KeyCode k5 = KeyCode.Q;
    public KeyCode k6 = KeyCode.W;
    public KeyCode k7 = KeyCode.E;
    public KeyCode k8 = KeyCode.R;
    public int frame = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Down()
    {
        CheckDown(k1);
        CheckDown(k2);
        CheckDown(k3);
        CheckDown(k4);
        CheckDown(k5);
        CheckDown(k6);
        CheckDown(k7);
        CheckDown(k8);
    }

    private void Pressing()
    {
        CheckPressing(k1);
        CheckPressing(k2);
        CheckPressing(k3);
        CheckPressing(k4);
        CheckPressing(k5);
        CheckPressing(k6);
        CheckPressing(k7);
        CheckPressing(k8);
    }

    private void Up()
    {
        CheckUp(k1);
        CheckUp(k2);
        CheckUp(k3);
        CheckUp(k4);
        CheckUp(k5);
        CheckUp(k6);
        CheckUp(k7);
        CheckUp(k8);
    }

    private void CheckDown(KeyCode key)
    {
        if(Input.GetKeyDown(key)) Debug.Log(string.Format("{0} | frame: {1}", key.ToString(), frame));
    }

    private void CheckPressing(KeyCode key)
    {
        if(Input.GetKey(key)) Debug.Log(string.Format("{0} | frame: {1}", key.ToString(), frame));
    }

    private void CheckUp(KeyCode key)
    {
        if(Input.GetKeyUp(key)) Debug.Log(string.Format("{0} | frame: {1}", key.ToString(), frame));
    }
}
