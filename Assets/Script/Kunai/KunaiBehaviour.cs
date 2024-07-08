using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KunaiBehaviour : MonoBehaviour
{
    [Header("UI Object")]
    [SerializeField] private GameObject KunaiViewHolder;
    [SerializeField] private GameObject KunaiViewPrefab;

    [Header("GameObject")]
    [SerializeField] private GameObject KunaiHolder;
    [SerializeField] private GameObject KunaiPrefab;
    [SerializeField] private GameObject LockRange;

    [Header("List")]
    [SerializeField] List<GameObject> KunaiViewList;
    [SerializeField] List<Kunai> KunaiList;


    #region PrivateValue
    private LockBehaviour lockBehaviour;
    private int index = 0;
    private int numberOfKnifes;
    private bool isOverUse;
    private bool isFade = true;
    #endregion
    // Update is called once per frame
    private void Awake()
    {
        lockBehaviour = LockRange.GetComponent<LockBehaviour>();
        numberOfKnifes = lockBehaviour.numberOfLocks + 4;
    }
    private void Start()
    {
        for (int i = 0; i < numberOfKnifes; i++)
        {
            Vector2 knifePos = new Vector2(0, -4f);
            GameObject knife = Instantiate(KunaiPrefab, knifePos, Quaternion.identity, KunaiHolder.transform);

            GameObject knifeView = Instantiate(KunaiViewPrefab, Vector2.zero, Quaternion.identity, KunaiViewHolder.transform);

            KunaiViewList.Add(knifeView);
            Debug.Log("Object Add");
        }
        foreach (Kunai knife in KunaiHolder.GetComponentsInChildren<Kunai>())
        {
            KunaiList.Add(knife);
            Debug.Log("Knife Add");
        }
        for (int i = 1; i < KunaiList.Count; i++)
        {
            KunaiList[i].HideKunai();
        }

    }
    void Update()
    {
        if (index < KunaiList.Count)
        {
            if (index == 0)
            {
                KunaiList[index].EndShowKunai();
            }
            else if (isFade)
            {
                KunaiList[index].ShowKunai();
                isFade = false;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                KunaiList[index].isMoving = true;
                KunaiView();
            }
        }
        else if (!isOverUse)
        {
            isOverUse = true;
            Debug.Log("GameOver");
        }
    }
    private void KunaiView()
    {
        index++;
        isFade = true;
        int viewIndex = KunaiViewList.Count - index;
        KunaiViewList[viewIndex].GetComponent<Image>().color = Color.gray;
        Debug.Log("Knife Drop");
    }
}
