public class ShiftMeterGA : GameAction
{
    public int Amount { get; private set; }
    public CardType CardType { get; private set; }

    public ShiftMeterGA(int amount)
    {
        Amount = amount;
    }
}