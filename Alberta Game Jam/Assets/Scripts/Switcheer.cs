using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcheer : MonoBehaviour
{
    public void FlipY()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }
}
