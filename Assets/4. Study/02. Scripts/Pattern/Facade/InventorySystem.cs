using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public void AddItem(string itemName)
    {
        Debug.Log($"{itemName} ȹ��");
    }

    public void HasItem(string itemName)
    {
        Debug.Log($"{itemName} ����");
    }

    public void RemoveItem(string itemName)
    {
        Debug.Log($"{itemName} ����");
    }
}
