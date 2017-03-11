using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    public Transform finishPanel;
    private static GameObject parent;
    public Sprite defaultBlock;
    public Transform currentScore;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void restart()
    {
        parent = GameObject.Find("Blocks");

        currentScore.GetComponent<Text>().text = "0";

        foreach (Transform child in parent.transform)
        {
            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#C2C2C2FF", out myColor);
            child.gameObject.GetComponent<Image>().color = myColor;
            child.gameObject.GetComponent<Image>().sprite = defaultBlock;
        }

        finishPanel.gameObject.SetActive(false);
    }
}
