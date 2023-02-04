using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsManager : MonoBehaviour
{
    public int currentSeeds;
    public TMPro.TextMeshProUGUI seedDisplayText;

    public GameObject rootPrefab;

    public List<GameObject> roots = new List<GameObject>();

    public void Start()
    {
        UpdateSeeds(5);
    }

    public void UpdateSeeds(int change)
    {
        currentSeeds += change;
        seedDisplayText.text = "Seeds: "+currentSeeds + " (Press E to Plant)";
    }

    public void Update()
    {
        if (PlayerMovementScript.instance.gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E) && currentSeeds > 0)
            {
                Vector3 newPosOfRoot = PlayerMovementScript.instance.transform.position;
                bool isFine = true;
                foreach (GameObject exsitingRoot in roots)
                {
                    if (Vector3.Distance(exsitingRoot.transform.position,newPosOfRoot)< 3)
                    {
                        isFine = false;
                    }
                }
                if (isFine)
                {
                    UpdateSeeds(-1);
                    GameObject newRoot = Instantiate(rootPrefab);
                    newRoot.transform.position = newPosOfRoot;
                    roots.Add(newRoot);
                }
            }
        }
    }
}
