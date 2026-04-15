public class BossPressureGA : GameAction
{
    public int Amount { get; private set; }

    public BossPressureGA(int amount)
    {
        Amount = amount;
    }
}