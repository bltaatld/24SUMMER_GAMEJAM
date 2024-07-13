using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KunaiBehaviour : MonoBehaviour
{
    public static KunaiBehaviour kunaiBehaviour;
    [Header("UI Object")]
    [SerializeField] private GameObject KunaiViewHolder;
    [SerializeField] private GameObject KunaiViewPrefab;

    [Header("GameObject")]
    [SerializeField] private GameObject KunaiHolder;
    [SerializeField] private GameObject KunaiPrefab;
    [SerializeField] private GameObject LockRange;
    public HostageManager hostageManager;
    [Header("List")]
    [SerializeField] List<GameObject> KunaiViewList;
    [SerializeField] List<Kunai> KunaiList;

    [HideInInspector] public int numberOfKnifes;
    [HideInInspector] public bool isAllUse;
    #region PrivateValue
    private LockBehaviour lockBehaviour;
    private int index = 0;
    private bool isFade = true;
    private float currentTime;
    private float coolDown = 1f;
    #endregion

    // Update is called once per frame
    private void Awake()
    {
        hostageManager.UpdateHostageInfo();
        lockBehaviour = LockRange.GetComponent<LockBehaviour>();
        kunaiBehaviour = this;
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
        currentTime += Time.deltaTime;

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

            if (currentTime >= coolDown)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    AudioManager.instance.PlaySound(9);
                    KunaiList[index].isMoving = true;
                    KunaiView();
                }
            }
        }
        else
        {
            isAllUse = true;
        }
    }
    private void KunaiView()
    {
        KunaiList[index].isUse = false;
        index++;
        isFade = true;
        int viewIndex = KunaiViewList.Count - index;
        KunaiViewList[viewIndex].GetComponent<Image>().color = Color.black;
        Debug.Log("Knife Drop");
    }
}
