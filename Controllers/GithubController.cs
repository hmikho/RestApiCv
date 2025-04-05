using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Backend_Api.Models;

[Route("api/github")]
[ApiController]
public class GitHubController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public GitHubController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetGitHubRepos(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return BadRequest(new { message = "Användarnamnet kan inte vara tomt eller innehålla endast mellanslag." });
        }

        var url = $"https://api.github.com/users/{username}/repos";

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            return NotFound(new { message = "GitHub-användare hittades inte", error = errorMessage });
        }

        var json = await response.Content.ReadAsStringAsync();
        var repositories = JsonSerializer.Deserialize<List<GitHubRepo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (repositories == null || repositories.Count == 0)
        {
            return NotFound(new { message = "Inga repositories hittades för användaren." });
        }

        var result = repositories.Select(repo => new SimplifiedRepo
        {
            Name = repo.Name,
            Language = string.IsNullOrEmpty(repo.Language) ? "okänt" : repo.Language,
            Description = string.IsNullOrEmpty(repo.Description) ? "saknas" : repo.Description,
            Url = repo.Html_Url
        });

        return Ok(result);
    }
}
