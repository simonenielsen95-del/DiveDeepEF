using DiveDeepEF.Models.Bookings;

namespace DiveDeepEF.Persistence
{
    public class BasketItemRepository
    {
        private static readonly List<BasketItem> items = new();

        public static List<BasketItem> GetAll()
        {
            return items;
        }
        public static void Add(BasketItem item)
        {
            items.Add(item);
        }
        public static void Remove(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
            }
        }

    }
}
