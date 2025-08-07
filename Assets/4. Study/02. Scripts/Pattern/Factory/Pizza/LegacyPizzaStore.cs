using UnityEngine;

public class LegacyPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type.Equals("Nomal"))
        {
            return new CheesePizza();
        }

        if (type.Equals("Special"))
        {
            return new PotatoPizza();
        }

        return null;
    }
}
