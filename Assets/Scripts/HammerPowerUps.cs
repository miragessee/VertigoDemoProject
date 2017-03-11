using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerPowerUps : MonoBehaviour
{

    private static GameObject parent;
    private static List<GameObject> childrenBlocks;
    public GameObject hammerPrefab;
    public Transform StarScore;

    // Use this for initialization
    void Start()
    {
        childrenBlocks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hammerPowerUps()
    {
        parent = GameObject.Find("Blocks");

        childrenBlocks.Clear();

        foreach (Transform child in parent.transform)
        {
            if (!child.GetComponent<Image>().sprite.name.Equals("blocks@2x"))
            {
                childrenBlocks.Add(child.gameObject);
            }
        }

        if (childrenBlocks.Count > 0)
        {

            StarScore.GetComponent<Text>().text = (int.Parse(StarScore.GetComponent<Text>().text) - 3).ToString();

            for (int i = 0; i < childrenBlocks.Count; i++)
            {
                GameObject gameObject = Instantiate(hammerPrefab, new Vector3(50, -50, 0), Quaternion.identity);
                gameObject.transform.SetParent(childrenBlocks[i].transform);
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(50, -50, 0);
                gameObject.transform.localScale = Vector3.one;
            }
        }
    }
}
