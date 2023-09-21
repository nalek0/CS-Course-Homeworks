namespace Task3
{
    
    public class Entity
    {
        
        private Int32 _x;

        private Int32 _y;

        private Int32 _satiety;

        public Int32 X { get => _x; }
        
        public Int32 Y { get => _y; }
        
        public Int32 Satiety { get => _satiety; }

        public Entity(Int32 x, Int32 y, Int32 satiety)
        {
            this._x = x;
            this._y = y;
            this._satiety = satiety;
        }

        public Entity()
        {
            this._x = 0;
            this._y = 0;
            this._satiety = 0;
        }

        public virtual void Move(Int32 deltaX, Int32 deltaY)
        {
            _x += deltaX;
            _y += deltaY;
            _satiety -= 1;
        }

        public virtual void Eat(Int32 foodSize)
        {
            _satiety += foodSize;
        }

    }

}