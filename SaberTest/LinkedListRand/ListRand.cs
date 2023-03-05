
namespace LinkedListRand
{
    public class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;
        
        public void Serialize(FileStream s)
        {
            Console.WriteLine("Open: " + s.Name);
        }
        public void Deserialize(FileStream s)
        {
            
        }
    }
}
