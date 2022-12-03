namespace Solution;

public class PriorityProvider : IPriorityProvider
{
    public int GetPriority(char itemType)
    {
        if (char.IsLetter(itemType))
        {
            if (char.IsLower(itemType) && itemType is >= 'a' and <= 'z')
            {
                // "+1" because we want the position in the alphabet, with a starting index of "1".
                return itemType - 'a' + 1;
            }
            else if (char.IsUpper(itemType) && itemType is >= 'A' and <= 'Z')
            {
                // "+1" because we want the position in the alphabet, with a starting index of "1".
                // "+26" because uppercase letters are considered to be *after* their lowercase versions.
                return itemType - 'A' + 1 + 26;
            }
        }
        
        throw new NotImplementedException();
    }
}