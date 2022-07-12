using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Services.Documents;

public interface IDocxService
{
    public void Save(IFormFile file, string path);
    public string GetAllText(string path);
}