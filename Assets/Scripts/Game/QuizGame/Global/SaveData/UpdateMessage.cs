namespace ExampleGame.Message
{
    public struct UpdateCoinMessage
    {
        public int Coin { get; private set; }
        
        public UpdateCoinMessage(int coin)
        {
            Coin = coin;
        }
    }
    public struct UpdatePackSelection
    {
        public string Pack { get; private set; }

        public UpdatePackSelection(string pack)
        {
            Pack = pack;
        }
    }

    public struct UpdatePackUnlock
    {
        public string Pack { get; private set; }

        public UpdatePackUnlock(string pack)
        {
            Pack = pack;
        }
    }

    public struct UpdateLevelComplete
    {
        public string Level { get; private set; }

        public UpdateLevelComplete(string level)
        {
            Level = level;
        }
    }

    public struct UpdatePackComplete
    {
        public string Pack { get; private set; }

        public UpdatePackComplete(string pack)
        {
            Pack = pack;
        }
    }

    public struct UpdateLevelSelection
    {
        public string Level { get; private set; }

        public UpdateLevelSelection(string level)
        {
            Level = level;
        }
    }

    public struct UpdateTimer
    {
        public float TimeRemaining { get; private set; }
        public UpdateTimer(float time)
        {
            TimeRemaining = time;
        }
    }
}