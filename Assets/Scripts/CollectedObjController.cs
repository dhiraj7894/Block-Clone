using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjController : MonoBehaviour
{
    PlayerManager playerManager;
    public Transform Sphere;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.instance;
        Sphere = transform.GetChild(0);

        if(GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<Renderer>().material = playerManager.collectedMat; 
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CollectableObj"))
        {
            if (!playerManager.colliderList.Contains(collision.gameObject))
            {
                collision.gameObject.tag = "CollectedObj";
                collision.transform.parent = playerManager.CollectedPoolObject;
                playerManager.colliderList.Add(collision.gameObject);
                collision.gameObject.AddComponent<CollectedObjController>();
            }
        }
        if (collision.gameObject.CompareTag("Obstrical"))
        {
            DestroyTheObject();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectableList"))
        {
            other.transform.GetComponent<BoxCollider>().enabled = false;
            other.transform.parent = playerManager.CollectedPoolObject;

            foreach(Transform child in other.transform)
            {
                if (!playerManager.colliderList.Contains(child.gameObject))
                {
                    playerManager.colliderList.Add(child.gameObject);
                    child.gameObject.tag = "CollectedObj";
                    child.gameObject.AddComponent<CollectedObjController>();
                }
            }
        }
        if (other.gameObject.CompareTag("FinishLine"))
        {
            if(playerManager.levelState != PlayerManager.LevelState.Finished)
            {
                playerManager.levelState = PlayerManager.LevelState.Finished;
                playerManager.CallMakeSphere();
            }
            CameraFollow.instance.setCameraPos();
        }
    }
    void DestroyTheObject()
    {
        playerManager.colliderList.Remove(gameObject);

        GameObject partical = Instantiate(playerManager.particalPrefeb, transform.position, Quaternion.identity);
        partical.GetComponent<ParticleSystem>().startColor = playerManager.collectedMat.color;
        Destroy(partical,0.5f);
        Destroy(gameObject);
    }

    public void makeSphere()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        Sphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
        Sphere.gameObject.GetComponent<SphereCollider>().enabled = true;
        Sphere.gameObject.GetComponent<SphereCollider>().isTrigger = true;

        Sphere.gameObject.GetComponent<Renderer>().material = playerManager.collectedMat;
    }
    public void DropDown()
    {
        Sphere.gameObject.layer = 8;

        Sphere.gameObject.GetComponent<SphereCollider>().isTrigger = false;
        Sphere.gameObject.AddComponent<Rigidbody>();
        Sphere.GetComponent<Rigidbody>().useGravity = true;
    }

}
