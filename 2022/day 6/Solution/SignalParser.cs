namespace Solution;

public class SignalParser
{
    public static int DefaultStartChunkSize { get; set; } = 4;
    public static int DefaultMessageChunkSize { get; set; } = 14;

    public int FindUniqueChunk(string input, int chunkSize)
    {
        if (chunkSize > input.Length)
        {
            throw new ArgumentException("Chunk size must be smaller than total input length.");
        }
        
        for (var i = 0; i < input.Length - chunkSize; ++i)
        {
            var chunk = input.Substring(i, chunkSize);
            var set = chunk.ToHashSet();
            if (set.Count == chunkSize)
            {
                return i + chunkSize;
            }
        }

        return -1;
    }
}