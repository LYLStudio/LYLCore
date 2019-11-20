namespace LStudio.Core.Data
{
    using System;
    using System.Threading.Tasks;

    public interface ISaveAsync
    {
        Task<IResult> SaveAsync();
    }
}
