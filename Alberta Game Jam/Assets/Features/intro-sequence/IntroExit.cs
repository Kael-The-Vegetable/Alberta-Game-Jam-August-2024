using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroExit : MonoBehaviour
{
    public void ChangeScene(int buildID)
    {
        GameManager.ChangeScene(buildID);
    }
}
