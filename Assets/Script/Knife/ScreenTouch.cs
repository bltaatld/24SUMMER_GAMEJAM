using System.Collections.Generic;
using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    [Header("UI Object")]
    [SerializeField] private GameObject KnifeViewHolder;
    [SerializeField] private GameObject KnifeViewPrefab;

    [Header("GameObject")]
    [SerializeField] private GameObject KnifeHolder;
    [SerializeField] private GameObject KnifePrefab;

    [Header("List")]
    [SerializeField] List<Knife> KnifeList;
    [SerializeField] List<GameObject> KnifeViewList;
    [SerializeField] List<GameObject> LockList;

    [Header("Other")]
    [SerializeField] int index;
    [SerializeField] int numberOfLocks;
    // Update is called once per frame
    private void Awake()
    {
        index = 0;
        numberOfLocks = 0;
    }
    private void Start()
    {
        for (int i = 0; i < numberOfLocks + 4; i++)
        {
            Vector2 vec = new Vector2(0, -3);
            GameObject knifeView =
                Instantiate(KnifeViewPrefab, vec, Quaternion.identity, KnifeHolder.transform);
            KnifeViewList.Add(knifeView);
        }
        foreach (Knife knife in KnifeHolder.GetComponentsInChildren<Knife>())
        {
            KnifeList.Add(knife);
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            KnifeList[index].KnifeMove(true);
            index++;
        }
    }
    void GetKnife()
    {

    }
}
