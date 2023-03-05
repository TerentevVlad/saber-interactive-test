using LinkedListRand;


var node0 = new ListNode() { Data = null };
var node1 = new ListNode() { Data = "2_tst: /n {g}" };
var node2 = new ListNode() { Data = "3_tst: + {g/t} ] / " };

node0.Next = node1;
node1.Next = node2;
node2.Next = null;

node0.Prev = null;
node1.Prev = node0;
node2.Prev = node1;


node0.Rand = null;
node1.Rand = node0;
node2.Rand = node2;

var list = new ListRand()
{
    Head = node0,
    Tail = node2,
    Count = 5
};


list.Serialize(File.Open("SerializedList.txt", FileMode.OpenOrCreate));

