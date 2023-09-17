public static class Extensions
{
    private const float Percent = 100;
    
    public static float Normalize(this int value) => value / Percent;
}