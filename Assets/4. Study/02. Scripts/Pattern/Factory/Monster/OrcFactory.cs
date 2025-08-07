using Pattern.Factory;
using UnityEngine;

public class OrcFactory : MonsterFactory
{
    protected override Monster CreateMonster(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Orc").AddComponent<Orc>();
                break;
            case "Warrior":
                return new GameObject("Orc").AddComponent<OrcWarrior>();
                break;
            case "Archer":
                return new GameObject("Orc").AddComponent<OrcArcher>();
                break;
            default:
                Debug.Log($"Unknown Monster Type : {type}");
                break;
        }
        return null;
    }
}
