ProductOfNumbers productOfNumbers = new ProductOfNumbers();
productOfNumbers.Add(3);        // [3]
productOfNumbers.Add(0);        // [3,0]
productOfNumbers.Add(2);        // [3,0,2]
productOfNumbers.Add(5);        // [3,0,2,5]
productOfNumbers.Add(4);        // [3,0,2,5,4]
Console.WriteLine(productOfNumbers.GetProduct(2)); // return 20. The product of the last 2 numbers is 5 * 4 = 20
Console.WriteLine(productOfNumbers.GetProduct(3)); // return 40. The product of the last 3 numbers is 2 * 5 * 4 = 40
Console.WriteLine(productOfNumbers.GetProduct(4)); // return 0. The product of the last 4 numbers is 0 * 2 * 5 * 4 = 0
productOfNumbers.Add(8);        // [3,0,2,5,4,8]
Console.WriteLine(productOfNumbers.GetProduct(2)); // return 32. The product of the last 2 numbers is 4 * 8 = 32 

public class ProductOfNumbers
{
    List<int> store;

    public ProductOfNumbers()
    {
        store = new List<int>();
    }

    public void Add(int num)
    {
        if (num == 0)
        {
            store.Clear();
        }
        else
        {
            if (store.Count == 0)
            {
                store.Add(num);
            }
            else
            {
                store.Add(store.Last() * num);
            }
        }
    }

    public int GetProduct(int k)
    {
        if (store.Count == 0)
        {
            return 0;
        }

        if (k > store.Count)
        {
            return 0;
        }

        if (store.Count == k)
        {
            return store.Last();
        }

        return store[store.Count - 1] / store[store.Count - k - 1];
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */