namespace Task3
{

    public class BuffedEntity : Entity
    {

        public BuffedEntity(Int32 x, Int32 y, Int32 satiety) : base(x, y, satiety) { }

        public BuffedEntity() : base() { }

        public override void Move(Int32 deltaX, Int32 deltaY)
        {
            base.Move(deltaX, deltaY);
            base.Move(deltaX, deltaY);
        }

        public override void Eat(Int32 foodSize)
        {
            base.Eat(foodSize);
            base.Eat(foodSize);
        }

    }

}