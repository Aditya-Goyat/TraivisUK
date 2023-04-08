using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UserInfo : MonoBehaviour
{
    public string UserName;
    public string EmailID;

    public static UserInfo instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
