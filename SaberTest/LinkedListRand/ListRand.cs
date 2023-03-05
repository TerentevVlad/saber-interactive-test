
using System.Diagnostics;

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
            using (var reader = new BinaryReader(s))
            {
                Count = reader.ReadInt32();

                List<ListNodeIndexed> readNodes = new List<ListNodeIndexed>(); 
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    readNodes.Add(reader.ReadNode());
                }
                
                Dictionary<int, ListNode> indexedNodes = new Dictionary<int, ListNode>();
                foreach (var node in readNodes)
                {
                    var listNode = new ListNode
                    {
                        Data = node.Data
                    };
                    indexedNodes.Add(node.CurrentIndex, listNode);
                }
                
                foreach (var readNode in readNodes)
                {
                    var currentNode = indexedNodes[readNode.CurrentIndex];
                    if (readNode.NextIndex == -1)
                    {
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = indexedNodes[readNode.NextIndex];
                    }

                    if (readNode.PrevIndex == -1)
                    {
                        Head = currentNode;
                    }
                    else
                    {
                        currentNode.Prev = indexedNodes[readNode.PrevIndex];
                    }

                    if (readNode.RandIndex != -1)
                    {
                        currentNode.Rand = indexedNodes[readNode.RandIndex];
                    }
                }

            }
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
}
