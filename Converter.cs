public static class Converter
{
    public static string ToBinary(this int source)
    {
        if (source < 2)
        {
            return (source % 2).ToString();
        }

        return (source % 2).ToString() + ToBinary(source / 2);
    }

    public static string ToEightBitBinary(this string source)
    {
        var result = int.Parse(source).ToBinary();
        var resultCopy = result;
        for (int i = resultCopy.Length; i < 8; i++)
        {
            result += "0";
        }
        return result;
    }

    public static int ToDecimal(this string source)
    {
        int result = 0;

        for (int i = 0; i < source.Length; i++)
        {
            result += int.Parse(source[i].ToString()) * (int)Math.Pow(2, i);
        }

        return result;
    }
}