using JwtAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_JwtAuthTest.Faculty.JwtAuth
{
    /// <summary>
    /// https://stackoverflow.com/a/61602061/6725889
    /// </summary>
    public class DisposableScopedContextWrapper : IDisposable
    {
        private readonly IServiceScope _scope;
        public DgJwtAuthDbContext Context { get; }

        public DisposableScopedContextWrapper(IServiceScope scope)
        {
            _scope = scope;
            Context = _scope.ServiceProvider.GetService<DgJwtAuthDbContext>();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }

}
