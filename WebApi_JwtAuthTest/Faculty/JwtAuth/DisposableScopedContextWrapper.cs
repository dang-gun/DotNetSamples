using JwtAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace DGAuthServer
{
    /// <summary>
    /// <see cref="DgJwtAuthDbContext">DgJwtAuthDbContext</see>
    /// 를 풀링하기위한 래퍼
    /// </summary>
    /// <remarks>
    /// DgJwtAuthUtils는 싱글톤으로 돌기 때문에 
    /// DbContext는 별도로 분리해야 되서 구현된 랩퍼다.
    /// <para><see href="https://stackoverflow.com/a/61602061/6725889"/>DisposableScopedContextWrapper</para>
    /// </remarks>
    public class DisposableScopedContextWrapper : IDisposable
    {
        private readonly IServiceScope _scope;
        public DgJwtAuthDbContext Context { get; }

        public DisposableScopedContextWrapper(IServiceScope scope)
        {
            _scope = scope;
            Context = _scope.ServiceProvider.GetService<DgJwtAuthDbContext>()!;
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }

}
