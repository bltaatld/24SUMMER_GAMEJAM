using System.Collections.Generic;
using UnityEngine;

public class KnifeInformation : MonoBehaviour
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
    private int numberOfKnifes = 1;
    private bool isMoving;
    private bool isOverUse;
    #endregion
    // Update is called once per frame
    private void Awake()
    {
        index = 0;
        numberOfKnifes = numberOfLocks + 4;
        isMoving = false;
    }
    private void Start()
    {
        for (int i = 0; i < numberOfKnifes; i++)
        {
            Vector2 knifePos = new Vector2(0, -3);
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
    }
    void Update()
    {
        if (index < KnifeList.Count)
        {
            if (Input.GetMouseButtonDown(0))
            {
                KnifeList[index].isMoving = true;
                index++;
            }
        }
        else
        {
            isOverUse = true;
        }
        Over(isOverUse);
    }
    private void Over(bool isOver)
    {
        if (isOver)
        {
            Debug.Log("GameOver");
            isOver = false;
        }

    }
}
