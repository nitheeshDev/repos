namespace Blazor_Server.Data
{
    public interface Interface
    {
        public Task<List<AudioTable>> GetRandomPromptsFromDatabase();

        public Task InsertAudioPrompt(AudioTable audioPrompt);

        public Task<AudioTable> GetPromptById(int promptId);

        public Task UpdateAudioPrompt(AudioTable audioPrompt);

        public Task DeleteAudioPrompt(int promptId);
    }
}
