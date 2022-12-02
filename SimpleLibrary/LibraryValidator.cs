using FluentValidation;

namespace SimpleLibrary
{
    internal class LibraryValidator : AbstractValidator<LibraryEntity>
    {
        public LibraryValidator()
        {
            RuleFor(lib => lib.LibTitle).NotEmpty().MinimumLength(3)
                .WithMessage("Please make sure you enter a correct library title.");

            RuleFor(lib => lib.Id).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
