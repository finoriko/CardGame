namespace CardFramework
{
    public class Player
    {
        #region Property
        public string Name { get; set; }
        public CardsGame Game { get; set; }
        public Hand Hand { get; set; }
        #endregion

        public Player(string name, CardsGame game)
        {
            Name = name;
            Game = game;
            Hand = new Hand();
        }
    }
}