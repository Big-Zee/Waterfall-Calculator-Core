namespace WaterFallCalculator
{
    public class CalculationOrder
    {
        private static int currentItem = 0;

        public void JumpToNextTask()
        {
            currentItem++;
            if (currentItem > 2) currentItem = 0;
        }

        public int GetCurrentItem()
        {
            return currentItem;
        }
    }
}
