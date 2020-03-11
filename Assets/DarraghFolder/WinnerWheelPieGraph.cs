using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerWheelPieGraph : MonoBehaviour
{
    public float[] values;
    public Color[] wedgeColours;

    public Image WedgePrefab;

    // Start is called before the first frame update
    void Start()
    {
        MakeWheel();
    }

    void MakeWheel()
    {
        float total = 0f;
        float zRotation = 0f;

        for (int i = 0; i < values.Length; i++)
        {
            total += values[i];
        }

        for (int i = 0; i < values.Length; i++)
        {
            Image newWedge = Instantiate(WedgePrefab);
            newWedge.transform.SetParent(transform, false);
            newWedge.color = wedgeColours[i];
            newWedge.fillAmount = values[i] / total;
            newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
            zRotation -= newWedge.fillAmount * 360;
        }
    }

}
