using Dapper;
using Microsoft.Extensions.Configuration;


namespace Blazor_Server.Data 
{
    public class AudioTable
    {
        public int PromptId { get; set; }
        public string Prompt { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsActivePrompt { get; set;}
    }

        public class AudioData : Interface
    {
        private readonly DapperContext _context;
        public AudioData( DapperContext context)
        {
          
            _context = context;
        }
        public async Task<List<AudioTable>> GetRandomPromptsFromDatabase()
        {
            var query = @"
        SELECT *
        FROM (
            SELECT *
            FROM AudioPrompts
            ORDER BY PromptId DESC
            OFFSET 0 ROWS
            FETCH NEXT @Count ROWS ONLY
        ) AS LastPrompts";

            using (var connection = _context.CreateConnection())
            {
                var prompts = await connection.QueryAsync<AudioTable>(query, new { Count = 10 });
                return prompts.ToList();
            }
        }

        public async Task InsertAudioPrompt(AudioTable audioPrompt)
        {
            var query = @"INSERT INTO AudioPrompts (Prompt, CreatedDate, IsActivePrompt) 
                          VALUES (@Prompt, @CreatedDate, @IsActivePrompt)";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, audioPrompt);
            }
        }

        public async Task<AudioTable> GetPromptById(int promptId)
        {
            var query = "SELECT * FROM AudioPrompts WHERE PromptId = @PromptId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<AudioTable>(query, new { PromptId = promptId });
            }
        }

        public async Task UpdateAudioPrompt(AudioTable audioPrompt)
        {
            var query = @"UPDATE AudioPrompts 
                  SET Prompt = @Prompt
                  WHERE PromptId = @PromptId";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, audioPrompt);
            }
        }

        public async Task DeleteAudioPrompt(int promptId)
        {
            var query = "DELETE FROM AudioPrompts WHERE PromptId = @PromptId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { PromptId = promptId });
            }
        }


    }
}
