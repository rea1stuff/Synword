using Ardalis.GuardClauses;
using Synword.Domain.Entities.UserAggregate;

namespace Synword.Application.Validation.PlagiarismCheckValidation;

public class PlagiarismRequestValidation : RequestValidation, IPlagiarismRequestValidation
{
    public override bool IsValid(User user, string text, int price)
    {
        Guard.Against.Null(user, nameof(user));
        _user = user;
        
        SetConstraints();

        return MinSymbolLimitValidation(text) &&
               MaxSymbolLimitValidation(text, _constraints.PlagiarismCheckMaxSymbolLimit) &&
               IsEnoughCoins(price);
    }
}
