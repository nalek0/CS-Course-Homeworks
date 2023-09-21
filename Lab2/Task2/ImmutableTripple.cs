namespace Task2
{

    public sealed class ImmutableTripple
    {

        public Int32 FirstValue { get; }

        public Int32 SecondValue { get; }

        public Int32 ThirdValue { get; }

        public ImmutableTripple(Int32 first, Int32 second, Int32 third)
        {
            FirstValue = first;
            SecondValue = second;
            ThirdValue = third;
        }

        public ImmutableTripple ChangeFirst(Int32 newValue)
        {
            return new ImmutableTripple(newValue, SecondValue, ThirdValue);
        }

        public ImmutableTripple ChangeSecond(Int32 newValue)
        {
            return new ImmutableTripple(FirstValue, newValue, ThirdValue);
        }

        public ImmutableTripple ChangeThird(Int32 newValue)
        {
            return new ImmutableTripple(FirstValue, SecondValue, newValue);
        }

        public override string ToString() =>
            "(" + FirstValue + ", " + SecondValue + ", " + ThirdValue + ")";

    }

}