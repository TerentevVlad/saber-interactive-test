using LinkedListRand;


var node0 = new ListNode() { Data = "000" };
var node1 = new ListNode() { Data = "111" };
var node2 = new ListNode() { Data = "222" };
var node3 = new ListNode() { Data = "333" };
var node4 = new ListNode() { Data = "444" };

node0.Next = node1;
node0.Prev = null;
node0.Rand = node4;

node1.Next = node2;
node1.Prev = node0;
node1.Rand = node2;

node2.Next = node3;
node2.Prev = node1;
node2.Rand = node2;

node3.Next = node4;
node3.Prev = node2;
node3.Rand = node0;

node4.Next = null;
node4.Prev = node3;
node4.Rand = node2;







node1.Rand = node0;
node2.Rand = node2;
node3.Rand = node1;
node4.Rand = node4;




var list = new ListRand()
{
    Head = node0,
    Tail = node4,
    Count = 3
};




list.Serialize(File.Open("SerializedList.txt", FileMode.Create));

var newlist = new ListRand();
newlist.Deserialize(File.Open("SerializedList.txt", FileMode.Open));
newlist.Print();