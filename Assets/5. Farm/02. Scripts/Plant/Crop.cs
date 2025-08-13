using System;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private string cropName;
    [SerializeField] public Sprite icon;

    public Action useAction;

    void Start()
    {
        useAction += Use;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Get();
        }
    }

    public void Get()
    {
        if (GameManager.Instance.item.CheckItemCount())
        {
            GameManager.Instance.item.GetItem(this);
            Debug.Log($"{cropName}을/를 획득 하였습니다.");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }

    public void Use()
    {
        Debug.Log($"{cropName}을/를 사용 하였습니다.");
    }
}
