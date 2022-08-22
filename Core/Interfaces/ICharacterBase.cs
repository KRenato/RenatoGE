namespace Core.Interfaces
{
    public interface ICharacterBase : IMappable
    {
        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        void SetPosition(Coordinate coordinate);
    }
}