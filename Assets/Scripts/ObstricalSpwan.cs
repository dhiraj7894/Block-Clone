using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstricalSpwan : MonoBehaviour
{
    public Transform[] spwanPointForObstrical;
    public Transform[] spwanPontForColList, spwanPontForColObj;
    public GameObject obstrical, colList, colObj;

    private void Start()
    {
        ObstracleSpwan();
    }

    void  ObstracleSpwan()
    {
        for(int i=0;i<= spwanPointForObstrical.Length-1;i++)
        {
            Instantiate(obstrical, spwanPointForObstrical[i].position, Quaternion.identity);
        }

        for (int i = 0; i <= spwanPontForColList.Length - 1; i++)
        {
            Instantiate(colList, spwanPontForColList[i].position, Quaternion.identity);
        }

        for (int i = 0; i <= spwanPontForColObj.Length - 1; i++)
        {
            Instantiate(colObj, spwanPontForColObj[i].position, Quaternion.identity);
        }
    }
}
