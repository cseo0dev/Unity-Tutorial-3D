using System.Collections;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    IEnumerator Start()
    {
        PizzaStore pizzaStore = null;
        Pizza pizza = null;

        pizzaStore = new LegacyPizzaStore();
        pizza = pizzaStore.OrderPizza("Nomal");
        Debug.Log($"�ֹ��� {pizza} ���Խ��ϴ�.");

        yield return new WaitForSeconds(1f);
        pizza = pizzaStore.OrderPizza("Special");
        Debug.Log($"�ֹ��� {pizza} ���Խ��ϴ�.");

        yield return new WaitForSeconds(1f);

        pizzaStore = new NewPizzaStore();
        pizza = pizzaStore.OrderPizza("Nomal");
        Debug.Log($"�ֹ��� {pizza} ���Խ��ϴ�.");

        yield return new WaitForSeconds(1f);
        pizza = pizzaStore.OrderPizza("Special");
        Debug.Log($"�ֹ��� {pizza} ���Խ��ϴ�.");
    }
}
