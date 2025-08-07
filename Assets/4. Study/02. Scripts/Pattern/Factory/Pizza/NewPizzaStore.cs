using UnityEngine;

public class NewPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type.Equals("Nomal"))
        {
            return new CheesePizza();
        }

        if (type.Equals("Special"))
        {
            return new BulgogiPizza();
        }

        return null;
    }
}
