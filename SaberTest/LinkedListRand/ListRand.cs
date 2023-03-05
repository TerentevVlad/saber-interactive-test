
namespace LinkedListRand
{
    public class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;
        
        
        public void Serialize(FileStream s)
        {
            var enumerable = this.CreateEnumerable();
            foreach (var node in enumerable)
            {
                Console.WriteLine(node.Data);
            }
        }
        public void Deserialize(FileStream s)
        {
           
        }
    }

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
    }


    public static class BinaryWriterExtension
    {
        public static void WriteNode(this BinaryWriter writer)
        {
            
        }
    }
}
