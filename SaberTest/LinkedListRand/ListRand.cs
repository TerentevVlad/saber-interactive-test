
namespace LinkedListRand
{
    public class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;
        
        
        public void Serialize(FileStream s)
        {
            using (var writer = new BinaryWriter(s))
            {
                var enumerable = this.CreateEnumerable();
                Dictionary<ListNode, int> indexedNodes = IndexNodes();
                writer.Write(Count);
                
                foreach (var node in enumerable)
                {
                    writer.WriteNode(node, indexedNodes);
                }
            }
           
        }
        public void Deserialize(FileStream s)
        {
           
        }

        private Dictionary<ListNode, int> IndexNodes()
        {
            Dictionary<ListNode, int> nodeDictionary = new Dictionary<ListNode, int>(Count);

            ListNode currentNode = Head;
            int currentIndex = 0;
            
            while (currentNode != null)
            {
                nodeDictionary.Add(currentNode, currentIndex);
                
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return nodeDictionary;
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

        public static int GetIndex(this Dictionary<ListNode, int> indexedNodes, ListNode node)
        {
            int index = -1;
            if (node != null)
            {
                index = indexedNodes[node];
            }

            return index;
        }
    }


    public static class BinaryWriterExtension
    {
        public static void WriteNode(this BinaryWriter writer, ListNode node, Dictionary<ListNode, int> indexedNodes)
        {
            int currentId = indexedNodes.GetIndex(node);
            int nextId = indexedNodes.GetIndex(node.Next);
            int prevId = indexedNodes.GetIndex(node.Prev);
            int randId = indexedNodes.GetIndex(node.Rand);

            writer.Write(string.IsNullOrEmpty(node.Data) ? "" : node.Data);
            writer.Write(currentId);
            writer.Write(nextId);
            writer.Write(prevId);
            writer.Write(randId);
        }
    }
}
