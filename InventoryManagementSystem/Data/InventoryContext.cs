using InventoryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data {
    public class InventoryContext : DbContext {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) {

        }
    }
}
