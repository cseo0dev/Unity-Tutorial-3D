using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outSideUI;
    [SerializeField] private GameObject fieldUI; // ���� UI
    [SerializeField] private GameObject HouseUI;
    [SerializeField] private GameObject animalUI;
    [SerializeField] private GameObject seedUI; // ������ UI
    [SerializeField] private GameObject inventoryUI;

    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButtons;

    private FieldManager.FieldState tempFieldState;

    void Awake()
    {
        seedButton.onClick.AddListener(OnSeedButton);
        harvestButton.onClick.AddListener(OnHarvestButton);

        for (int i = 0; i < plantButtons.Length; i++)
        {
            int j = i;
            plantButtons[i].onClick.AddListener(() => GameManager.Instance.field.SetPlant(j));
            // plantButtons[i].onClick.AddListener(() => GameManager.Instance.field.SetPlant(i)); // Ŭ���� �̽�
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            // ����ó��..
            //if (GameManager.Instance.field.fieldState != FieldManager.FieldState.None)
            //{
            //    if (inventoryUI.activeSelf) // �κ��丮 â�� ���� ���� ���
            //    {
            //        tempFieldState = GameManager.Instance.field.fieldState;
            //        GameManager.Instance.field.fieldState = FieldManager.FieldState.None;
            //    }
            //    else
            //    {
            //        GameManager.Instance.field.fieldState = tempFieldState;
            //    }
            //}
        }
    }

    private void OnSeedButton()
    {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Seed);
        seedUI.SetActive(true);
    }

    private void OnHarvestButton()
    {
        GameManager.Instance.field.SetState(FieldManager.FieldState.Harvest);
        seedUI.SetActive(false);
    }

    public void ActivateFieldUI(bool isActive)
    {
        fieldUI.SetActive(isActive);
    }
}
