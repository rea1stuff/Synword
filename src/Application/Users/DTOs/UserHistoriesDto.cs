using Synword.Application.AppFeatures.PlagiarismCheck.DTOs;
using Synword.Application.AppFeatures.Rephrase.DTOs.RephraseResult;

namespace Synword.Application.Users.DTOs;

public class UserHistoriesDto
{
    public List<RephraseResultDto> RephraseHistories { get; set; }
    public List<PlagiarismCheckResultDto> PlagiarismCheckHistories { get; set; }
}
