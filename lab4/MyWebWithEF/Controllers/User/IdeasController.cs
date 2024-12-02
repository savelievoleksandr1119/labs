using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MyWebWithEF.Controllers.User.Base
{
    public class IdeasController : UserApiController
    {
        private readonly IdeaService _ideaService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IdeasController(IdeaService ideaService, ApplicationDbContext context, IMapper mapper)
        {
            _ideaService = ideaService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdeaDto>>> GetIdeas()
        {
            var ideas = await _ideaService.GetAllIdeasAsync();
            var ideaDtos = _mapper.Map<List<IdeaDto>>(ideas);
            return Ok(ideaDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaDto>> GetIdea(int id)
        {
            var idea = await _ideaService.GetIdeaByIdAsync(id);
            if (idea == null)
            {
                return NotFound();
            }

            var ideaDto = _mapper.Map<IdeaDto>(idea);
            return Ok(ideaDto);
        }
    }
}
