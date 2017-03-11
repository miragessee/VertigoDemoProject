using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPerfScript : MonoBehaviour
{
    public Transform currentScore;
    public Transform bestScore;
    private static List<GameObject> childrenBlocks;
    private static GameObject parent;

    // Use this for initialization
    void Start()
    {
        childrenBlocks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CurrentScore", int.Parse(currentScore.GetComponent<Text>().text));
        PlayerPrefs.SetInt("BestScore", int.Parse(bestScore.GetComponent<Text>().text));

        parent = GameObject.Find("Blocks");

        childrenBlocks.Clear();

        foreach (Transform child in parent.transform)
        {
            if (!child.GetComponent<Image>().sprite.name.Equals("blocks@2x"))
            {
                childrenBlocks.Add(child.gameObject);
            }
        }

        PlayerPrefs.SetInt("myList_count", childrenBlocks.Count);

        for (int i = 0; i < childrenBlocks.Count; i++)
        {
            PlayerPrefs.SetString("myList_" + i, childrenBlocks[i].name);
            PlayerPrefs.SetString("myList_Color" + i, childrenBlocks[i].GetComponent<Image>().sprite.name);
        }

        PlayerPrefs.Save();
    }
}
