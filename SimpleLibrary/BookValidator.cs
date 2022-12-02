

using FluentValidation;

namespace SimpleLibrary
{
    internal class BookValidator : AbstractValidator<BookEntity>
    {
        public BookValidator()
        {
            RuleFor(book => book.LibraryId).NotEmpty();

            RuleFor(book => book.Title).NotEmpty().MinimumLength(1)
                .WithMessage("Please ensure that you have entered the book's title.");

            RuleFor(book => book.Author).NotEmpty().MinimumLength(1)
                .WithMessage("Please ensure that you have entered the book's author.");

            RuleFor(book => book.Year).NotEmpty().LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("You entered wrong year");
        }
    }
}
