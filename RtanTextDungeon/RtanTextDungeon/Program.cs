namespace RtanTextDungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(Define.PlayerClass.Worrior);
            Shop shop = new Shop();
            Dungeon dungeon = new Dungeon();
            dungeon.EnterGame(player, shop);
        }
    }
}
