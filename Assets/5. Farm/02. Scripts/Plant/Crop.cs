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
            Debug.Log($"{cropName}��/�� ȹ�� �Ͽ����ϴ�.");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�κ��丮�� ���� á���ϴ�.");
        }
    }

    public void Use()
    {
        Debug.Log($"{cropName}��/�� ��� �Ͽ����ϴ�.");
    }
}
