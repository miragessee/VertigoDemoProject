using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    private static GameObject parent;
    private static GameObject parentCurrentBlocks;
    private static List<GameObject> childrenBlocks;
    private static List<GameObject> childrenBlocks2;
    public Transform finishPanel;

    // Use this for initialization
    void Start()
    {
        childrenBlocks = new List<GameObject>();
        childrenBlocks2 = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        parent = GameObject.Find("Blocks");
        parentCurrentBlocks = GameObject.Find("CurrentBlock");

        childrenBlocks.Clear();
        childrenBlocks2.Clear();

        foreach (Transform child in parent.transform)
        {
            if (!child.GetComponent<Image>().sprite.name.Equals("blocks@2x"))
            {
                childrenBlocks.Add(child.gameObject);
            }
        }

        if (childrenBlocks.Count >= 25)
        {
            finishPanel.gameObject.SetActive(true);
        }
        else
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Image>().sprite.name.Equals("blocks@2x"))
                {
                    childrenBlocks2.Add(child.gameObject);
                }
            }

            if (childrenBlocks2.Count < parentCurrentBlocks.transform.childCount)
            {
                finishPanel.gameObject.SetActive(true);
            }
        }
    }
}
