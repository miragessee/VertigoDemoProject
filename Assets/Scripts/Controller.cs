using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private GameObject cB1;
    private GameObject parent;
    private List<GameObject> children;
    public Sprite defaultBlock;
    public GameObject activePrefab;
    public GameObject passivePrefab;
    public Sprite confetti1;
    public Sprite confetti2;
    public Sprite confetti3;
    public Sprite confetti4;
    private static GameObject parentNext;
    public Button SkipButton;
    private List<GameObject> nextBlockGameObjects;

    // Use this for initialization
    void Start()
    {
        children = new List<GameObject>();
        nextBlockGameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
        }
        else
        {
            cB1 = GameObject.Find("active");

            if (cB1 == null)
            {
                cB1 = GameObject.Find("active(Clone)");
            }

            if (cB1 != null)
            {
                PassedGameObject.passed.Add(transform.gameObject);

                parent = GameObject.Find("CurrentBlock");
                parentNext = GameObject.Find("NextBlock");

                if (parentNext.transform.childCount > 0)
                {
                    nextBlockGameObjects.Clear();

                    var children2 = new List<GameObject>();
                    foreach (Transform child in parentNext.transform) children2.Add(child.gameObject);
                    children2.ForEach(child => nextBlockGameObjects.Add(child));
                }

                transform.GetComponent<Image>().color = Color.white;
                transform.GetComponent<Image>().sprite = cB1.GetComponent<Image>().sprite;

                children.Clear();

                foreach (Transform child in parent.transform)
                {
                    children.Add(child.gameObject);
                }

                for (int i = 0; i < children.Count; i++)
                {
                    if (i == children.Count - 1)
                    {
                        children[i].name = "passive";
                        children[i].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                        children[i].GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.MinSize;
                        children[i].GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
                    }
                    else if (children[i].name.Contains("active"))
                    {
                        children[i].name = "passive";
                        children[i].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                        children[i].GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.MinSize;
                        children[i].GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
                        children[i + 1].name = "active";
                        children[i + 1].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
                        children[i + 1].GetComponent<ContentSizeFitter>().horizontalFit =
                            ContentSizeFitter.FitMode.PreferredSize;
                        children[i + 1].GetComponent<ContentSizeFitter>().verticalFit =
                            ContentSizeFitter.FitMode.PreferredSize;
                        break;
                    }
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
        }
        else
        {
            if (eventData.eligibleForClick)
            {
                if (eventData.pointerEnter.gameObject.GetComponent<Image>().sprite.name.Equals(defaultBlock.name))
                {
                    cB1 = GameObject.Find("active");

                    if (cB1 == null)
                    {
                        cB1 = GameObject.Find("active(Clone)");
                    }

                    if (cB1 != null)
                    {
                        PassedGameObject.passed.Add(transform.gameObject);

                        parent = GameObject.Find("CurrentBlock");
                        transform.GetComponent<Image>().color = Color.white;
                        transform.GetComponent<Image>().sprite = cB1.GetComponent<Image>().sprite;

                        children.Clear();

                        foreach (Transform child in parent.transform)
                        {
                            children.Add(child.gameObject);
                        }

                        for (int i = 0; i < children.Count; i++)
                        {
                            if (i == children.Count - 1)
                            {
                                children[i].name = "passive";
                                children[i].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                                children[i].GetComponent<ContentSizeFitter>().horizontalFit =
                                    ContentSizeFitter.FitMode.MinSize;
                                children[i].GetComponent<ContentSizeFitter>().verticalFit =
                                    ContentSizeFitter.FitMode.MinSize;
                                break;
                            }
                            else if (children[i].name.Contains("active"))
                            {
                                children[i].name = "passive";
                                children[i].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                                children[i].GetComponent<ContentSizeFitter>().horizontalFit =
                                    ContentSizeFitter.FitMode.MinSize;
                                children[i].GetComponent<ContentSizeFitter>().verticalFit =
                                    ContentSizeFitter.FitMode.MinSize;
                                children[i + 1].name = "active";
                                children[i + 1].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
                                children[i + 1].GetComponent<ContentSizeFitter>().horizontalFit =
                                    ContentSizeFitter.FitMode.PreferredSize;
                                children[i + 1].GetComponent<ContentSizeFitter>().verticalFit =
                                    ContentSizeFitter.FitMode.PreferredSize;
                                break;
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    for (int i = 0; i < PassedGameObject.passed.Count; i++)
                    {
                        if (eventData.pointerEnter.gameObject.name == PassedGameObject.passed[i].name)
                        {
                            for (int j = PassedGameObject.passed.Count - 1; j > i; j--)
                            {
                                for (int z = 0; z < children.Count; z++)
                                {
                                    if (children[z].name.Contains("active"))
                                    {
                                        if (z == 0)
                                        {
                                            children[z].name = "passive";
                                            children[z].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                                            children[z].GetComponent<ContentSizeFitter>().horizontalFit =
                                                ContentSizeFitter.FitMode.MinSize;
                                            children[z].GetComponent<ContentSizeFitter>().verticalFit =
                                                ContentSizeFitter.FitMode.MinSize;
                                            break;
                                        }
                                        else
                                        {
                                            children[z].name = "passive";
                                            children[z].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                                            children[z].GetComponent<ContentSizeFitter>().horizontalFit =
                                                ContentSizeFitter.FitMode.MinSize;
                                            children[z].GetComponent<ContentSizeFitter>().verticalFit =
                                                ContentSizeFitter.FitMode.MinSize;
                                            children[z - 1].name = "active";
                                            children[z - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
                                            children[z - 1].GetComponent<ContentSizeFitter>().horizontalFit =
                                                ContentSizeFitter.FitMode.PreferredSize;
                                            children[z - 1].GetComponent<ContentSizeFitter>().verticalFit =
                                                ContentSizeFitter.FitMode.PreferredSize;
                                            break;
                                        }
                                    }
                                    else if (z == children.Count - 1)
                                    {
                                        children[children.Count - 1].name = "active";
                                        children[children.Count - 1].GetComponent<RectTransform>().sizeDelta =
                                            new Vector2(48, 48);
                                        children[children.Count - 1].GetComponent<ContentSizeFitter>().horizontalFit =
                                            ContentSizeFitter.FitMode.PreferredSize;
                                        children[children.Count - 1].GetComponent<ContentSizeFitter>().verticalFit =
                                            ContentSizeFitter.FitMode.PreferredSize;
                                        break;
                                    }
                                }

                                Color myColor = new Color();
                                ColorUtility.TryParseHtmlString("#C2C2C2FF", out myColor);
                                PassedGameObject.passed[j].GetComponent<Image>().color = myColor;
                                PassedGameObject.passed[j].GetComponent<Image>().sprite = defaultBlock;

                                PassedGameObject.passed.RemoveAt(j);
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#C2C2C2FF", out myColor);
            transform.GetComponent<Image>().color = myColor;
            transform.GetComponent<Image>().sprite = defaultBlock;

            var children = new List<GameObject>();
            foreach (Transform child in transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

            GameObject[] killEmAll = GameObject.FindGameObjectsWithTag("hammer");

            for (int i = 0; i < killEmAll.Length; i++)
            {
                Destroy(killEmAll[i].gameObject);
            }
        }
        else
        {

            int count = 0;

            for (int z = 0; z < children.Count; z++)
            {
                if (children[z].name.Contains("passive"))
                {
                    count++;
                }
            }

            if (count == children.Count)
            {
                ScoreManager2.searchAndDestroy();

                GameObject[] killEmAll = GameObject.FindGameObjectsWithTag("passive");

                for (int i = 0; i < killEmAll.Length; i++)
                {
                    Destroy(killEmAll[i].gameObject);
                }

                PassedGameObject.passed.Clear();

                if (parentNext.transform.childCount > 0)
                {
                    for (int i = 0; i < nextBlockGameObjects.Count; i++)
                    {
                        if (i == 0)
                        {
                            nextBlockGameObjects[i].name = "active";
                            nextBlockGameObjects[i].tag = "passive";
                        }
                        else
                        {
                            nextBlockGameObjects[i].name = "passive";
                            nextBlockGameObjects[i].tag = "passive";
                        }
                        nextBlockGameObjects[i].transform.SetParent(parent.transform);
                    }
                }
                else
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
                        GameObject gameObject = Instantiate(activePrefab, new Vector3(-45, 4, 0),
                            Quaternion.identity);
                        gameObject.transform.SetParent(parent.transform);
                        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-45, -46, 0);
                        GameObject gameObject1 = Instantiate(passivePrefab, new Vector3(0, 4, 0),
                            Quaternion.identity);
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
                        GameObject gameObject = Instantiate(activePrefab, new Vector3(-45, 4, 0),
                            Quaternion.identity);
                        gameObject.transform.SetParent(parent.transform);
                        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-45, -46, 0);
                        GameObject gameObject1 = Instantiate(passivePrefab, new Vector3(0, 4, 0),
                            Quaternion.identity);
                        gameObject1.transform.SetParent(parent.transform);
                        gameObject1.GetComponent<RectTransform>().localPosition = new Vector3(0, -46, 0);
                        GameObject gameObject2 = Instantiate(passivePrefab, new Vector3(37, 4, 0),
                            Quaternion.identity);
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
                        GameObject gameObject = Instantiate(activePrefab, new Vector3(-45, 4, 0),
                            Quaternion.identity);
                        gameObject.transform.SetParent(parent.transform);
                        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-45, -46, 0);
                        GameObject gameObject1 = Instantiate(passivePrefab, new Vector3(0, 4, 0),
                            Quaternion.identity);
                        gameObject1.transform.SetParent(parent.transform);
                        gameObject1.GetComponent<RectTransform>().localPosition = new Vector3(0, -46, 0);
                        GameObject gameObject2 = Instantiate(passivePrefab, new Vector3(37, 4, 0),
                            Quaternion.identity);
                        gameObject2.transform.SetParent(parent.transform);
                        gameObject2.GetComponent<RectTransform>().localPosition = new Vector3(37, -46, 0);
                        GameObject gameObject3 = Instantiate(passivePrefab, new Vector3(74, 4, 0),
                            Quaternion.identity);
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
            else
            {
                children.Clear();

                foreach (Transform child in parent.transform)
                {
                    children.Add(child.gameObject);
                }

                for (int z = 0; z < children.Count; z++)
                {
                    if (z == 0)
                    {
                        children[z].name = "active";
                        children[z].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
                        children[z].GetComponent<ContentSizeFitter>().horizontalFit =
                            ContentSizeFitter.FitMode.PreferredSize;
                        children[z].GetComponent<ContentSizeFitter>().verticalFit =
                            ContentSizeFitter.FitMode.PreferredSize;
                    }
                    else
                    {
                        children[z].name = "passive";
                        children[z].GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
                        children[z].GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.MinSize;
                        children[z].GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
                    }
                }

                for (int i = 0; i < PassedGameObject.passed.Count; i++)
                {
                    Color myColor = new Color();
                    ColorUtility.TryParseHtmlString("#C2C2C2FF", out myColor);
                    PassedGameObject.passed[i].GetComponent<Image>().color = myColor;
                    PassedGameObject.passed[i].GetComponent<Image>().sprite = defaultBlock;
                }
            }
        }
    }
}
