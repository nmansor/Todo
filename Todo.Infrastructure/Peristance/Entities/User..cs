namespace Todo.Infrastructure.Peristance.Entities
{
    internal class User: BaseAuditEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
