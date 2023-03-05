namespace LinkedListRand;

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

    public static ListNodeIndexed ReadNode(this BinaryReader reader)
    {
        var readString = reader.ReadString();
        var readCurrentIndex = reader.ReadInt32();
        var readNextIndex = reader.ReadInt32();
        var readPrevIndex = reader.ReadInt32();
        var readRandIndex = reader.ReadInt32();

        return new ListNodeIndexed()
        {
            Data = readString,
            CurrentIndex = readCurrentIndex,
            NextIndex = readNextIndex,
            PrevIndex = readPrevIndex,
            RandIndex = readRandIndex
        };
    }
}