namespace Advent_of_Code_2015
{
    public interface IShopItem
    {
        int Max { get; }
        int Min { get; }
        int Armor { get; }
        int Cost { get; }
        int Damage { get; }
        string Name { get; }
    }
}