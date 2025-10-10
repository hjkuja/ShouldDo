using LanguageExt.Common;

namespace ShouldDo.Application.Validators.Interfaces;

public interface IValidator<in T> where T : struct
{
    public Task<Error[]> ValidateAsync(T item);
}
