using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Material collectedMat;
    public Transform CollectedPoolObject;
    public PlayerState playerState;
    public LevelState levelState;
    public GameObject particalPrefeb;





    public List<GameObject> colliderList;
    


    private void Awake()
    {
        instance = this;
    }





    public enum PlayerState { Stop, Move }
    public enum LevelState { NotFinished, Finished}

    public void CallMakeSphere()
    {
        foreach(GameObject obj in colliderList)
        {
            obj.GetComponent<CollectedObjController>().makeSphere();
        }
    }
}

