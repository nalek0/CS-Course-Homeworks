using System.Xml.XPath;

namespace Task5
{
    
    public sealed class HeightsList
    {

        private List<int> _heights;

        public List<int> Heights { get => _heights; }

        public HeightsList(List<int> heights)
        {
            this._heights = heights;
        }

        public HeightsList(int[] heights)
        {
            this._heights = new List<int>(heights.Length);
            this._heights.AddRange(heights);
        }

        public int GetWaterAmount()
        {
            int result = 0;
            int maxHeight = _heights.Max();
            int leftMaxIndex = _heights.FindIndex(maxHeight.Equals);
            int rightMaxIndex = _heights.FindLastIndex(maxHeight.Equals);
            int currentHeight = 0;

            for (int i = 0; i < leftMaxIndex; i++)
            {
                int height = _heights[i];
                currentHeight = Math.Max(currentHeight, height);
                result += currentHeight - height;
            }

            currentHeight = 0;

            for (int i = _heights.Count - 1; i >= rightMaxIndex; i--)
            {
                int height = _heights[i];
                currentHeight = Math.Max(currentHeight, height);
                result += currentHeight - height;
            }

            for (int i = leftMaxIndex; i < rightMaxIndex; i++)
            {
                int height = _heights[i];
                result += maxHeight - height;
            }
            
            return result;
        }

    }

}