using Blazor_Server.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity;

namespace Blazor_Server.Pages
{
    public class PromptsModel : PageModel
    {
        private readonly Interface _audioData;

        public PromptsModel(Interface audioData)
        {
            _audioData = audioData;
        }

        public List<AudioTable> Prompts { get; set; }

        public async Task OnGetAsync()
        {
            Prompts = await _audioData.GetRandomPromptsFromDatabase();
        }
    }
}
