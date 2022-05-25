namespace Store.Models
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDbContext _context;
        public OrderRepository(StoreDbContext context) => _context = context;

        public IQueryable<Order> Orders => _context.orders.Include(x => x.Lines).ThenInclude(l => l.Product);



        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
            {
                _context.orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
