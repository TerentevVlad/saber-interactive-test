using LinkedListRand;

public static class ListRandExtension
{
    public static IEnumerable<ListNode> CreateEnumerable(this ListRand list)
    {
        List<ListNode> listNodes = new List<ListNode>();

        ListNode currentNode = list.Head;
        while (currentNode != null)
        {
            listNodes.Add(currentNode);
            currentNode = currentNode.Next;
        }

        return listNodes;
    }

    public static int GetIndex(this Dictionary<ListNode, int> indexedNodes, ListNode node)
    {
        int index = -1;
        if (node != null)
        {
            index = indexedNodes[node];
        }

        return index;
    }

    public static void Print(this ListRand listRand)
    {
        Console.WriteLine($"Count {listRand.Count}");
        Console.WriteLine($"Head {listRand.Head.Data}");
        Console.WriteLine($"Tail {listRand.Tail.Data}");

        foreach (var listNode in listRand.CreateEnumerable())
        {
            var data = listNode.Data;
            var nextData = listNode.Next != null ? listNode.Next.Data : "null";
            var prevData = listNode.Prev != null ? listNode.Prev.Data : "null";
            var randData = listNode.Rand != null ? listNode.Rand.Data : "null";

            Console.WriteLine($"Data: {data} NextData: {nextData} PrevData: {prevData} RandData:{randData}");
        }
    }
}