using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weaponObjs;
    public WeaponData[] weaponDatas;
    public WeaponDataGroup wDataGroup;

    public string currWeaponName;
    public int currWeaponDamage;
    public int currWeaponRange;

    void Start()
    {
        foreach (var data in weaponDatas)
        {
            Debug.Log($"{data.weaponName} / {data.attackDamage} / {data.attackRange}");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapon(2);
        }
    }

    private void SwapWeapon(int index)
    {
        foreach (var weapon in weaponObjs)
            weapon.SetActive(false);

        weaponObjs[index].SetActive(true);

        currWeaponName = weaponDatas[index].weaponName;
        currWeaponDamage = weaponDatas[index].attackDamage;
        currWeaponRange = weaponDatas[index].attackRange;

        currWeaponDamage = wDataGroup.wData[0].damageSystem.maxDamage;
    }
}
