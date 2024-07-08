using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeBehaviour : MonoBehaviour
{
    [Header("UI Object")]
    [SerializeField] private GameObject KnifeViewHolder;
    [SerializeField] private GameObject KnifeViewPrefab;

    [Header("GameObject")]
    [SerializeField] private GameObject KnifeHolder;
    [SerializeField] private GameObject KnifePrefab;

    [Header("List")]
    [SerializeField] List<GameObject> KnifeViewList;
    [SerializeField] List<Knife> KnifeList;
    [SerializeField] List<GameObject> LockList;

    [Header("Other")]
    [SerializeField] int numberOfLocks = 6;

    #region PrivateValue
    private int index;
    private int numberOfKnifes;
    private bool isOverUse;
    private bool isFade;
    #endregion
    // Update is called once per frame
    private void Awake()
    {
        index = 0;
        numberOfKnifes = numberOfLocks + 4;
        isFade = true;
    }
    private void Start()
    {
        for (int i = 0; i < numberOfKnifes; i++)
        {
            Vector2 knifePos = new Vector2(0, -4f);
            GameObject knife = Instantiate(KnifePrefab, knifePos, Quaternion.identity, KnifeHolder.transform);

            GameObject knifeView = Instantiate(KnifeViewPrefab, Vector2.zero, Quaternion.identity, KnifeViewHolder.transform);

            KnifeViewList.Add(knifeView);
            Debug.Log("Object Add");
        }
        foreach (Knife knife in KnifeHolder.GetComponentsInChildren<Knife>())
        {
            KnifeList.Add(knife);
            Debug.Log("Knife Add");
        }
        for (int i = 1; i < KnifeList.Count; i++)
        {
            KnifeList[i].HideKnife();
        }

    }
    void Update()
    {
        if (index < KnifeList.Count)
        {
            if (index == 0)
            {
                KnifeList[index].EndShowKnife();
            }
            else if (isFade)
            {
                KnifeList[index].ShowKnife();
                isFade = false;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                KnifeList[index].isMoving = true;
                SetKnife();
            }
        }
        else if (!isOverUse)
        {
            isOverUse = true;
            Debug.Log("GameOver");
        }
    }
    private void SetKnife()
    {
        index++;
        isFade = true;
        int viewIndex = KnifeViewList.Count - index;
        KnifeViewList[viewIndex].GetComponent<Image>().color = Color.gray;
        Debug.Log("Knife Drop");
    }
}
