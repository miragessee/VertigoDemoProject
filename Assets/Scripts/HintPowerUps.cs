using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintPowerUps : MonoBehaviour
{

    public Transform StarScore;
    private static GameObject parent;
    public GameObject activePrefab;
    public GameObject passivePrefab;
    public Sprite confetti1;
    public Sprite confetti2;
    public Sprite confetti3;
    public Sprite confetti4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hintPowerUps()
    {
        StarScore.GetComponent<Text>().text = (int.Parse(StarScore.GetComponent<Text>().text) - 2).ToString();

        parent = GameObject.Find("NextBlock");

        if (parent.transform.childCount == 0)
        {
            int random = Random.Range(1, 5);

            if (random == 1 || random == 4)
            {
                float lucky = Random.Range(0f, 1f);

                if (lucky < 0.3f)
                {
                    if (random == 1)
                    {
                        random += Random.Range(1, 3);
                    }
                    else
                    {
                        random -= Random.Range(1, 3);
                    }
                }
            }

            if (random == 1)
            {
                GameObject gameObject = Instantiate(activePrefab, new Vector3(0, 4, 0), Quaternion.identity);
                gameObject.transform.SetParent(parent.transform);
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, -46, 0);

                int randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject.GetComponent<Image>().sprite = confetti4;
                }
            }
            else if (random == 2)
            {
                GameObject gameObject = Instantiate(activePrefab, new Vector3(-45, 4, 0), Quaternion.identity);
                gameObject.transform.SetParent(parent.transform);
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-45, -46, 0);
                GameObject gameObject1 = Instantiate(passivePrefab, new Vector3(0, 4, 0), Quaternion.identity);
                gameObject1.transform.SetParent(parent.transform);
                gameObject1.GetComponent<RectTransform>().localPosition = new Vector3(0, -46, 0);

                int randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject.GetComponent<Image>().sprite = confetti4;
                }

                randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti4;
                }
            }
            else if (random == 3)
            {
                GameObject gameObject = Instantiate(activePrefab, new Vector3(-45, 4, 0), Quaternion.identity);
                gameObject.transform.SetParent(parent.transform);
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-45, -46, 0);
                GameObject gameObject1 = Instantiate(passivePrefab, new Vector3(0, 4, 0), Quaternion.identity);
                gameObject1.transform.SetParent(parent.transform);
                gameObject1.GetComponent<RectTransform>().localPosition = new Vector3(0, -46, 0);
                GameObject gameObject2 = Instantiate(passivePrefab, new Vector3(37, 4, 0), Quaternion.identity);
                gameObject2.transform.SetParent(parent.transform);
                gameObject2.GetComponent<RectTransform>().localPosition = new Vector3(37, -46, 0);

                int randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject.GetComponent<Image>().sprite = confetti4;
                }

                randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti4;
                }

                randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti4;
                }
            }
            else if (random == 4)
            {
                GameObject gameObject = Instantiate(activePrefab, new Vector3(-45, 4, 0), Quaternion.identity);
                gameObject.transform.SetParent(parent.transform);
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-45, -46, 0);
                GameObject gameObject1 = Instantiate(passivePrefab, new Vector3(0, 4, 0), Quaternion.identity);
                gameObject1.transform.SetParent(parent.transform);
                gameObject1.GetComponent<RectTransform>().localPosition = new Vector3(0, -46, 0);
                GameObject gameObject2 = Instantiate(passivePrefab, new Vector3(37, 4, 0), Quaternion.identity);
                gameObject2.transform.SetParent(parent.transform);
                gameObject2.GetComponent<RectTransform>().localPosition = new Vector3(37, -46, 0);
                GameObject gameObject3 = Instantiate(passivePrefab, new Vector3(74, 4, 0), Quaternion.identity);
                gameObject3.transform.SetParent(parent.transform);
                gameObject3.GetComponent<RectTransform>().localPosition = new Vector3(74, -46, 0);

                int randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject.GetComponent<Image>().sprite = confetti4;
                }

                randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject1.GetComponent<Image>().sprite = confetti4;
                }

                randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject2.GetComponent<Image>().sprite = confetti4;
                }

                randomColor = Random.Range(1, 5);

                if (randomColor == 1)
                {
                    gameObject3.GetComponent<Image>().sprite = confetti1;
                }
                else if (randomColor == 2)
                {
                    gameObject3.GetComponent<Image>().sprite = confetti2;
                }
                else if (randomColor == 3)
                {
                    gameObject3.GetComponent<Image>().sprite = confetti3;
                }
                else if (randomColor == 4)
                {
                    gameObject3.GetComponent<Image>().sprite = confetti4;
                }
            }
        }
    }
}
