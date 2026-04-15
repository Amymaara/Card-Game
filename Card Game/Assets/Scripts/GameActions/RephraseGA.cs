public class RephraseGA : GameAction
{
    public int FallbackAmount { get; private set; }

    public RephraseGA(int fallbackAmount)
    {
        FallbackAmount = fallbackAmount;
    }
}