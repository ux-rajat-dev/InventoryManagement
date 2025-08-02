using InventoryManagement.Interface;
using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly InventoryDbContext _context;

        public SupplierService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierQueryModel>> GetAllAsync()
        {
            return await _context.Suppliers
                .Select(s => new SupplierQueryModel
                {
                    SupplierId = s.SupplierId,
                    Name = s.Name,
                    ContactEmail = s.ContactEmail,
                    PhoneNumber = s.PhoneNumber,
                    Address = s.Address
                })
                .ToListAsync();
        }

        public async Task<SupplierQueryModel> GetByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return null;

            return new SupplierQueryModel
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                ContactEmail = supplier.ContactEmail,
                PhoneNumber = supplier.PhoneNumber,
                Address = supplier.Address
            };
        }

        public async Task<bool> CreateAsync(SupplierCommandModel model)
        {
            var supplier = new Supplier
            {
                Name = model.Name,
                ContactEmail = model.ContactEmail,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, SupplierCommandModel model)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            supplier.Name = model.Name;
            supplier.ContactEmail = model.ContactEmail;
            supplier.PhoneNumber = model.PhoneNumber;
            supplier.Address = model.Address;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
