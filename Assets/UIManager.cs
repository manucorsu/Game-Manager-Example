using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ChangeSceneBtnPressed(string s)
    {
        GameManager.Instance.ChangeScene(s);
    }
}
