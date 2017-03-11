using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{

    private static List<GameObject> childrenBlocks;
    private static GameObject parent;
    private static List<GameObject> sameBlocks;
    private static List<GameObject> equalityList;
    private static List<GameObject> destroyList;
    public static Sprite defaultBlock;
    private static GameObject currentScore;
    private static GameObject bestScore;
    private static List<GameObject> deletedList;

    // Use this for initialization
    void Start()
    {
        childrenBlocks = new List<GameObject>();
        sameBlocks = new List<GameObject>();
        equalityList = new List<GameObject>();
        destroyList = new List<GameObject>();
        deletedList = new List<GameObject>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("Default");

        defaultBlock = sprites[0];

        currentScore = GameObject.Find("CurrentScore");
        bestScore = GameObject.Find("BestScore");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void searchAndDestroy()
    {
        childrenBlocks.Clear();
        sameBlocks.Clear();
        equalityList.Clear();

        parent = GameObject.Find("Blocks");

        foreach (Transform child in parent.transform)
        {
            if (!child.GetComponent<Image>().sprite.name.Equals("blocks@2x"))
            {
                childrenBlocks.Add(child.gameObject);
            }
        }

        for (int i = 0; i < childrenBlocks.Count; i++)
        {
            for (int j = i + 1; j < childrenBlocks.Count; j++)
            {
                if (
                    childrenBlocks[i].GetComponent<Image>()
                        .sprite.name.Equals(childrenBlocks[j].GetComponent<Image>().sprite.name))
                {
                    sameBlocks.Add(childrenBlocks[i]);
                    sameBlocks.Add(childrenBlocks[j]);
                }
            }
        }

        sameBlocks = sameBlocks.Distinct().ToList();

        int sameBlockCounter = 0;

        for (int i = 0; i < sameBlocks.Count; i++)
        {
            for (int j = i + 1; j < sameBlocks.Count; j++)
            {
                if (areVerticalOrHorizontalNeighbors(sameBlocks[i], sameBlocks[j]))
                {
                    sameBlockCounter++;
                    equalityList.Add(sameBlocks[i]);
                    equalityList.Add(sameBlocks[j]);
                }
            }
        }

        if (sameBlockCounter >= 3)
        {
            equalityList = equalityList.Distinct().ToList();

            int equalityListCounter = 0;

            for (int i = 0; i < equalityList.Count; i++)
            {
                for (int j = 0; j < equalityList.Count; j++)
                {
                    for (int k = j + 1; k < equalityList.Count; k++)
                    {
                        if (equalityList[j].GetComponent<Image>().sprite.name == equalityList[k].GetComponent<Image>().sprite.name)
                        {
                            equalityListCounter++;
                            destroyList.Add(equalityList[j]);
                            destroyList.Add(equalityList[k]);
                        }
                    }

                    if (equalityListCounter >= 2)
                    {
                        destroyList = destroyList.Distinct().ToList();

                        for (int k = 0; k < destroyList.Count; k++)
                        {
                            Color myColor = new Color();
                            ColorUtility.TryParseHtmlString("#C2C2C2FF", out myColor);
                            destroyList[k].GetComponent<Image>().color = myColor;
                            destroyList[k].GetComponent<Image>().sprite = defaultBlock;
                        }


                        if (deletedList.Count == 0)
                        {
                            int currentScoreInt = int.Parse(currentScore.GetComponent<Text>().text);
                            int result = currentScoreInt + (destroyList.Count * destroyList.Count) / 2;
                            currentScore.GetComponent<Text>().text = result.ToString();

                            if (int.Parse(bestScore.GetComponent<Text>().text) < result)
                            {
                                bestScore.GetComponent<Text>().text = result.ToString();
                            }

                            deletedList = destroyList;
                        }
                    }
                    else
                    {
                        destroyList.Clear();
                        deletedList.Clear();
                    }

                    equalityListCounter = 0;
                }
            }
        }
        else
        {
            equalityList.Clear();
        }
    }

    public static bool areVerticalOrHorizontalNeighbors(GameObject g1, GameObject g2)
    {
        return (g1.GetComponent<RectTransform>().position.x == g2.GetComponent<RectTransform>().position.x ||
                        g1.GetComponent<RectTransform>().position.y == g2.GetComponent<RectTransform>().position.y)
                        && Mathf.Abs(g1.GetComponent<RectTransform>().position.x - g2.GetComponent<RectTransform>().position.x) <= 120
                        && Mathf.Abs(g1.GetComponent<RectTransform>().position.y - g2.GetComponent<RectTransform>().position.y) <= 120
                        && !g1.name.Equals(g2.name)
                        && g1.GetComponent<Image>().sprite.name.Equals(g2.GetComponent<Image>().sprite.name);
    }
}
